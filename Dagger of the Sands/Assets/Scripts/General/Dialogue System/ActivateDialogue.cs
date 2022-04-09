using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferentDialogues : MonoBehaviour
{
    [SerializeField] private DialogueManager[] dialogueManager;
    
    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeDialogue()
    {
        foreach (DialogueManager dialogue in dialogueManager)
        {
            while (!dialogue.isDialogueDone)
            {
                dialogue.DisplayNextSentence();
            }
        }
    }

}
