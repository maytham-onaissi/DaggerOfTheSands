using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChangeInteractable : MonoBehaviour
{

    [SerializeField] private int level;
    public void LoadNextSceneInteractable()
    {
        FindObjectOfType<LevelLoader>().LoadLevel(level);
    }
}
