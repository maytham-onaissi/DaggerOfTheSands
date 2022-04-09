using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossGateInteractable : MonoBehaviour
{
    private bool isInRange;
    [SerializeField] UnityEvent InteractionIn;
    [SerializeField] UnityEvent InteractionOut;


    void Update()
    {
        if (isInRange)
        {
            InteractionIn.Invoke();
        }
        else
        {
            InteractionOut.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("In range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("is not In range");
        }
    }

}
