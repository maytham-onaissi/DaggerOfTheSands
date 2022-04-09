using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Classes")]
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject healthUI;

    [Header("Parent Object")]
    [SerializeField] GameObject playerHandler;

    [Header("Specifications")]
    [SerializeField] public int healAmount;
    [SerializeField] public int manaConsumption;
    
    [Header("Health")]
    //[Range(6,10)]
    [SerializeField] public float totalHealth;
    [SerializeField] public float currentHealth;
    [SerializeField] public bool isFlaskAquired = false;

    [Header("Death")]
    public bool dead;


    [Header("VFX")]
    [SerializeField] private ParticleSystem healEffect;
    [SerializeField] private ParticleSystem hurtEffect;

    [Header("Invulerability")]
    public static bool invulnerable;

    [Header("Components")]
    [SerializeField] private List<Behaviour> components;


    private void Awake()
    {
        foreach (Behaviour component in gameObject.GetComponents<Behaviour>())
        {
                components.Add(component);

            if (component == GetComponent<BoxCollider2D>())
                    components.Remove(component);

            if (component == GetComponent<Animator>())
                components.Remove(component);

        }

        totalHealth = playerController.playerStatus.totalHealth;
        playerController.playerStatus.currentHealth = totalHealth;
        currentHealth = playerController.playerStatus.currentHealth;
        dead = false;
    }

    private void Update()
    {
        if (playerController.playerInputScript.healInput && playerController.mana.canSpendMana(manaConsumption) && isFlaskAquired)
        {
            if (currentHealth != totalHealth)
            {
                heal(healAmount);
            }
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            TakeDamage(1);
        }

    }

    public void TakeDamage(float _Damage)
    {
        if (invulnerable) return;

        playerController.playerStatus.currentHealth = Mathf.Clamp(playerController.playerStatus.currentHealth - _Damage, 0, totalHealth);
        currentHealth = playerController.playerStatus.currentHealth;
        hurtEffect.Play();
        healthUI.GetComponent<HealthUI>().SetHealUI();

        if (currentHealth > 0)
        {
            //Hurt animation.
            playerController.anim.SetTrigger("Hurt");

        }
        else
        {
            if (!dead)
            {

                StartCoroutine(Die());
            }
        }

    }

    public IEnumerator Die()
    {
        foreach (Behaviour component in components)
        {
            component.enabled = false;
        }

        //Death animation.
        playerController.anim.SetBool("Die", true);

        yield return new WaitForSeconds(1f);

        dead = true;
    }

    public IEnumerator FlaskAcquire()
    {

        yield return new WaitForSeconds(6f);

        isFlaskAquired = true;
        playerController.notifyText.text = "Flask of Rejuvenation acquired; Press G to heal";

        yield return new WaitForSeconds(3f);

        playerController.notifyText.text = "";
    }

    public void FlaskAcquired()
    {
        StartCoroutine(FlaskAcquire());
    }

    public void heal(float _value)
    {
        playerController.playerStatus.currentHealth = Mathf.Clamp(playerController.playerStatus.currentHealth + _value, 1, totalHealth);
        currentHealth = playerController.playerStatus.currentHealth;
        playerController.mana.SpendMana(manaConsumption);
        healEffect.Play();
        healthUI.GetComponent<HealthUI>().SetHealUI();
    }

    public void increaseTotalHealth(float _value)
    {
        playerController.playerStatus.totalHealth = Mathf.Clamp(playerController.playerStatus.totalHealth + _value, totalHealth, 10);
        heal(_value);
        healthUI.GetComponent<HealthUI>().ReturnToFullHealth();
    }
        
    public void ReturnToFullHealth(float _value)
    {
        playerController.playerStatus.currentHealth = Mathf.Clamp(playerController.playerStatus.currentHealth + _value, 1, totalHealth);
        currentHealth = playerController.playerStatus.currentHealth;
        healthUI.GetComponent<HealthUI>().SetHealUI();

    }
    public void ReturnFullHealthUI()
    {
        ReturnToFullHealth(totalHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }


}
