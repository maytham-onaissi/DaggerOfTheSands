using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateNewDialogue : MonoBehaviour
{
    [SerializeField] public bool isNewDialogue;
    [SerializeField] public GameObject newDialogue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isNewDialogue)
            newDialogue.SetActive(true);
    }
}
