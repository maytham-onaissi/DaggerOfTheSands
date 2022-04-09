using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Classes")]
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject healthUI;

    [Header("Specifications")]
    [SerializeField] public int healAmount;
    [SerializeField] public int manaConsumption;
    
    [Header("Health")]
    //[Range(6,10)]
    [SerializeField] public float totalHealth;
    [SerializeField] public float currentHealth;
    [SerializeField] public bool isFlaskAquired = false;

    [Header("Death")]
    private bool dead;


    [Header("VFX")]
    [SerializeField] private ParticleSystem healEffect;
    [SerializeField] private ParticleSystem hurtEffect;

    [Header("Invulerability")]
    public static bool invulnerable;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;


    private void Awake()
    {
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

            //AudioManager.instance.PlaySound(hurtSound);
        }
        else
        {
            if (!dead)
            {

                MiniDeathJump();
                
                foreach (Behaviour component in gameObject.GetComponents<Behaviour>()) 
                {
                    if (component != gameObject.GetComponent<BoxCollider2D>())
                        component.enabled = false;
                }

                GetComponent<Animator>().enabled = true;


                playerController.anim.SetBool("Die", true);

                //FindObjectOfType<LevelManager>().Restart();
                dead = true;
               //AudioManager.instance.PlaySound(deathSound);
            }
        }

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

    public void MiniDeathJump()
    {
        playerController.rigidBody.velocity = new Vector2(playerController.rigidBody.velocity.x, playerController.Jump.jumpForce / 2);
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
        healthUI.GetComponent<HealthUI>().IncreaseTotalHealth();
    }
        
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }


}
