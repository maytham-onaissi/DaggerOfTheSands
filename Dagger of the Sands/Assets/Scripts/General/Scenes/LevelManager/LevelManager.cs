using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void Restart()
    {
        //Restart the scene.
        FindObjectOfType<LevelLoader>().LoadLevel(SceneManager.GetActiveScene().buildIndex);

        //Restart 

        //Save player initial position when game starts.

        //Resposition player to initial position.

    }
}
