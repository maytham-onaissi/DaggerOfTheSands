using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivation : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject newDialogue;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.serpentFangs.secondGemAquired || playerController.serpentStep.thirdGemAquired)
            newDialogue.SetActive(true);
    }
}
