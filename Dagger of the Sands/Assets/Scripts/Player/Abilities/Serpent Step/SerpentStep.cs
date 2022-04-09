using System.Collections;
using UnityEngine;

public class SerpentStep : MonoBehaviour
{
    [Header("Classes")]
    [SerializeField] PlayerController playerController;
    [SerializeField] ActivateNewDialogue activateNewDialogue;


    [Header("Dash")]
    [SerializeField] public float dashSpeed;
    [SerializeField] private float initialDashTime;
    [SerializeField] private int layerMaskIgnore;
    public int direction;
    public bool isDashing;
    public bool thirdGemAquired = false;
    public bool thirdGemEmbedded = false;
    private float dashTime;


    [Header("Animation")]
    public const string run = "Run";
    const string serpentStep = "Dash";
    public const string idle = "Idle";

    [Header("SFX")]
    [SerializeField] AudioClip dashAudio;

    // Start is called before the first frame update
    void Start()
    {
        isDashing = false;
        dashTime = initialDashTime;
        activateNewDialogue = FindObjectOfType<ActivateNewDialogue>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!playerController.isGamePaused && thirdGemEmbedded)
            Dash();
    }

    private void Dash()
    {
        if (direction == 0)
        {
            if (playerController.playerInputScript.serpentStepInput)
            {
                Physics2D.IgnoreLayerCollision(8, layerMaskIgnore, true);
                //FindObjectOfType<AudioManager>().PlaySound("SerpentStep");

                if (playerController.playerInputScript.horizontalInput > 0)
                {
                    playerController.anim.SetBool("Dash", true);
                    FindObjectOfType<AudioManager>().PlaySound("SerpentStep");
                    direction = 1;
                }
                else if (playerController.playerInputScript.horizontalInput < 0)
                {
                    playerController.anim.SetBool("Dash", true);
                    FindObjectOfType<AudioManager>().PlaySound("SerpentStep");
                    direction = 2;
                }
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                playerController.anim.SetBool("Dash", false);

                direction = 0;

                dashTime = initialDashTime;

                Physics2D.IgnoreLayerCollision(8, layerMaskIgnore, false);

                playerController.rigidBody.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 1)
                {
                    playerController.rigidBody.velocity = Vector2.right * dashSpeed;
                }
                else if (direction == 2)
                {
                    playerController.rigidBody.velocity = Vector2.left * dashSpeed;
                }
            }
        }
    }

    public IEnumerator ThirdGemAcquire()
    {
        yield return new WaitForSeconds(5f);

        thirdGemAquired = true;

        if (playerController.serpentFangs.secondGemAquired)
            playerController.notifyText.text = "Third Gem acquired; talk to Jabber Ibn Hayyan";

        if (!playerController.serpentFangs.secondGemAquired)
            playerController.notifyText.text = "Third Gem acquired; talk to Sindbad";

        if (playerController.serpentFangs.secondGemAquired && !activateNewDialogue.isNewDialogue)
            activateNewDialogue.isNewDialogue = true;

        yield return new WaitForSeconds(3f);

        playerController.notifyText.text = "";
    }

    public void ThirdGemAcquired()
    {
        StartCoroutine(ThirdGemAcquire());

    }

    public void ThirdGemEmbedded()
    {
        StartCoroutine(ThirdGemEmbed());
    }

    public IEnumerator ThirdGemEmbed()
    {
        yield return new WaitForSeconds(5f);

        thirdGemEmbedded = true;

        playerController.notifyText.text = "Third Gem Embedded; press Left Shift to dash a short distance";

        yield return new WaitForSeconds(3f);

        playerController.notifyText.text = "";
    }

}

