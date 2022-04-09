using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPosController : MonoBehaviour
{
    [SerializeField] private Canvas HPBar;
    //[SerializeField] private Transform playerScale;
     private Transform oldParent;
    private Vector3 canvasScale;
    // Start is called before the first frame update
    void Awake()
    {
        //canvasScale = playerScale.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playerScale.localScale);
        //transform.localScale = Vector3.one;
        ChangeScale();
    }

    void ChangeScale()
    {
        oldParent = transform.parent;
        transform.parent = null;
        transform.localScale = Vector3.one;
        transform.parent = oldParent;
    }
}
