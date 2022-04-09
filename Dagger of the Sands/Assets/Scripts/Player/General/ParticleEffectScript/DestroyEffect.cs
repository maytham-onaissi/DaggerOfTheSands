using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    [SerializeField] private float destroyTime;
    void Start()
    {
        Destroy(gameObject, destroyTime); 
    }

}
