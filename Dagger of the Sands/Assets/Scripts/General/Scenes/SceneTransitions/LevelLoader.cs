using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
     
    [Header("Loading Screen")]
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider slider;
    [SerializeField] private Text progressText;

    [Header("Classes")]
    [SerializeField] private PlayerController playerController;


    private void Start()
    {
        if (loadingScreen == null)
            Debug.LogError("Variable not assigened in " + SceneManager.GetActiveScene().name);
    }
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {

        //the progress of operation //Keeps current scene active while loading the new scene. 
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;
            progressText.text = progress * 100 + "%"; 

            yield return null;
        }

        if (operation.isDone)
            playerController.SavePlayer();
        
    }
}
