using System.Collections;
using UnityEngine;

public class SerpentFangs : MonoBehaviour
{
    [Header("Classes")]
    [SerializeField] PlayerController playerController;
    [SerializeField] ActivateNewDialogue activateNewDialogue;

    [Header("Specifications")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private int manaConsumption;
    private float cooldownTimer = Mathf.Infinity;
    public bool secondGemAquired = false;
    public bool secondGemEmbedded = false;

    [Header("Projectile Specifications")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] projectiles;

    private void Awake()
    {
        activateNewDialogue = FindObjectOfType<ActivateNewDialogue>();     
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.isGamePaused)
        {
            ActionButton();
        }
    }

    private void ActionButton()
    {
        if (playerController.playerInputScript.serpentFangsInput && cooldownTimer > attackCooldown && secondGemEmbedded)
        {
            if (playerController.mana.canSpendMana(manaConsumption))
            {
                playerController.anim.SetBool("SerpentFangs", true);

                if (!playerController.playerSpaceDetection.IsGrounded())
                {
                    playerController.anim.SetBool("isGrounded", false);
                    playerController.anim.SetBool("DoubleJump", false);
                }

            }
        }
        else
        {
            playerController.anim.SetBool("SerpentFangs", false);
        }

        cooldownTimer += Time.deltaTime;
    }

    public void Attack()
    {
        FindObjectOfType<AudioManager>().PlaySound("SerpentFangs");
        playerController.mana.SpendMana(manaConsumption);
        cooldownTimer = 0;

        //pooling
        projectiles[FindProjectile()].transform.position = firePoint.position;
        projectiles[FindProjectile()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

    }

    public IEnumerator SecondGemAcquire()
    {
        yield return new WaitForSeconds(5f);

        secondGemAquired = true;

        if (playerController.serpentStep.thirdGemAquired)
            playerController.notifyText.text = "Second Gem acquired, Talk to Jabber Ibn Hayyan";

        if (!playerController.serpentStep.thirdGemAquired)
            playerController.notifyText.text = "Second Gem acquired, Talk to Sindbad";

        if (playerController.serpentStep.thirdGemAquired && !activateNewDialogue.isNewDialogue)
            activateNewDialogue.isNewDialogue = true;

        yield return new WaitForSeconds(3f);

        playerController.notifyText.text = "";
    }

    public void SecondGemAcquired()
    {
        StartCoroutine(SecondGemAcquire());
    }

    public void SecondGemEmbedded()
    {
        StartCoroutine(SecondGemEmbed());
    }

    public IEnumerator SecondGemEmbed()
    {
        yield return new WaitForSeconds(5f);

        secondGemEmbedded = true;

        playerController.notifyText.text = "Second Gem embedded, press F to fire a projectile";

        yield return new WaitForSeconds(3f);

        playerController.notifyText.text = "";
    }
    private int FindProjectile()
    {
        for (int i = 0; i < projectiles.Length; i++)
        {
            if (!projectiles[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
