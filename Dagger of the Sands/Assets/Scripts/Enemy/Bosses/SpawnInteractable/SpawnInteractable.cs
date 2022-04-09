using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInteractable : MonoBehaviour
{
    [SerializeField] private GameObject interactableObject;
    [SerializeField] private BossHealth bossHealth;

    
    private void Update()
    {
        if (bossHealth.isDead)
        {
            interactableObject.transform.position = transform.position; 
            interactableObject.SetActive(true);
        }
    }

}
