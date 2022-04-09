using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatesFunctionality : MonoBehaviour
{

    private Animator anim;
    private BoxCollider2D boxCollider;
    [SerializeField] private GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeIn()
    {
        StartCoroutine(ChangeStateIn());
    }

    public void ChangeOut()
    {
        StartCoroutine(ChangeStateOut());
    }

    public IEnumerator ChangeStateIn()
    {
        yield return new WaitForSeconds(1);

        anim.enabled = true;
        boxCollider.isTrigger = false;

        yield return new WaitForSeconds(3);

        //Start boss 
        boss.SetActive(true);
    } 

    public IEnumerator ChangeStateOut()
    {
        anim.SetTrigger("PlayerOut");

        yield return new WaitForSeconds(1);

        gameObject.SetActive(false);
    }



}
