using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    private Queue<string> sentences;
    [SerializeField] public TMPro.TMP_Text nameText;
    [SerializeField] public TMPro.TMP_Text dialogueText;
    [SerializeField] public GameObject dialogueCanvas;
    [SerializeField] public GameObject dialogueHandler;
    [SerializeField] public GameObject moreDialogue;
    public static bool stopDialogue;
    public bool isDialogueDone = false;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        sentences = new Queue<string>();
        stopDialogue = false;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            DisplayNextSentence();
        }

        DestroyHandler();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversation with: " + dialogue.name);
        sentences.Clear();

        nameText.text = dialogue.name;

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        //Prevents the appearence of a new sentence when the previous one has not finished yet.
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        Debug.Log(sentence);   

    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    private void EndDialogue()
    {
        isDialogueDone = true;
        dialogueCanvas.SetActive(false);
    }

    private void DestroyHandler()
    {
        if (isDialogueDone)
        {
            if (moreDialogue != null)
                moreDialogue.SetActive(true);

            if (dialogueHandler != null)
                Destroy(dialogueHandler);

            playerController.DeNotifyPlayer();      
            
        }
    }
}
