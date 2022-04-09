using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [Header("Classes")]
    [SerializeField] public Jump Jump;
    [SerializeField] public Mana mana;
    [SerializeField] public Attack attack;
    [SerializeField] public Health health;
    [SerializeField] public WallSlide WallSlide;
    [SerializeField] public DoubleJump doubleJump;
    [SerializeField] public SerpentStep serpentStep;
    [SerializeField] public PlayerStatus playerStatus;
    [SerializeField] public SerpentFangs serpentFangs;
    [SerializeField] public DownwardForce downwardForce;
    [SerializeField] public JumpController jumpController;
    [SerializeField] public PauseMenuScript pauseMenuScript;
    [SerializeField] public PlayerInputScript playerInputScript;
    [SerializeField] public HorizontalMovement horizontalMovement;
    [SerializeField] public AnimationController animationController;
    [SerializeField] public ParticleEffectScript particleEffectScript;
    [SerializeField] public PlayerSpaceDetection playerSpaceDetection;

    [Header("General")]
    public Animator anim;
    public Rigidbody2D rigidBody;
    public BoxCollider2D boxCollider;

    [Header("Objects")]
    [SerializeField] public TMPro.TMP_Text notifyText;
    [SerializeField] public TMPro.TMP_Text notifyTextTwo;
    [SerializeField] public GameObject notifyPlayer;

    [Header("Specifications")]
    public int currentScene;
    public bool isGamePaused;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenuScript.GameIsPaused)
        {
            isGamePaused = pauseMenuScript.GameIsPaused;
        }
        else
        {
            isGamePaused = pauseMenuScript.GameIsPaused;
        }
    }

    public void NotifyPlayer()
    {
        notifyPlayer.SetActive(true);
        notifyTextTwo.text = "Press E to interact";
    }

    public void DeNotifyPlayer()
    {
        notifyPlayer.SetActive(false);
        notifyTextTwo.text = "";
    }

    public int GetCurrentScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void SavePlayer()
    {
        Debug.Log("Saving");
        SavingSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SavingSystem.LoadPlayer();

        currentScene = data.level;
        playerStatus.currentHealth = data.health;
        playerStatus.currentMana = data.mana;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }



}
