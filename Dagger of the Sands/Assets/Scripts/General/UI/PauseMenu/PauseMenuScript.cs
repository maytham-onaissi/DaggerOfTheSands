using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{

    [SerializeField] public bool GameIsPaused = false;
    [SerializeField] public bool disablePauseScreen;
    [SerializeField] public GameObject pauseMenuUI; 
    [SerializeField] public GameObject optionsMenuUI;
    [SerializeField] public GameObject healthBarUI;
    [SerializeField] public GameObject manaBarUI;
    public PlayerController playerController;
    public DontDestroy playerHandler;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        playerHandler = FindObjectOfType<DontDestroy>();
    }
    // Update is called once per frame
    void Update()
    {
        DisablePauseScreen();
        if (Input.GetKeyDown(KeyCode.Escape) && !disablePauseScreen)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }    
    }

    private void DisablePauseScreen()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            disablePauseScreen = true;
        }
        else
        {
            disablePauseScreen = false;
        }
    }

    public void Resume()
    {
        healthBarUI.SetActive(true);
        manaBarUI.SetActive(true);
        pauseMenuUI.SetActive(false);

        if (optionsMenuUI.active == true)
            optionsMenuUI.SetActive(false);

        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        healthBarUI.SetActive(false);
        manaBarUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMainMenu()
    {
        playerController.SavePlayer();
        FindObjectOfType<LevelLoader>().LoadLevel(0);
        healthBarUI.SetActive(false);
        manaBarUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
        Destroy(playerHandler.gameObject);
    }

    public void OptionsMenu()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
    }                                  

    public void Back()
    {
        pauseMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
    }

}
