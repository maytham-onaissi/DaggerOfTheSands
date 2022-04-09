using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
    private PlayerController playerHandler; 

    void Awake()
    {
        playerHandler = FindObjectOfType<PlayerController>();
        playerHandler.transform.position = transform.position;
    }
}
