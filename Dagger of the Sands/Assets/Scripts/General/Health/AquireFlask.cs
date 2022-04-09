using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AquireFlask : MonoBehaviour
{
    private Health health;
    [SerializeField] private float textDuration;
    [SerializeField] private Text acquireText;

    // Start is called before the first frame update
    void Start()
    {
        health = FindObjectOfType<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


  
}
