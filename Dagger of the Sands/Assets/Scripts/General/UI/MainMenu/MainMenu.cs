using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    [SerializeField] public LevelLoader levelLoader;
    [SerializeField] public PlayerPreserve playerPreserve;
    private PlayerController playerController;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void PlayGame()
    {
        levelLoader.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
        playerController.LoadPlayer();
        //Instantiate
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
