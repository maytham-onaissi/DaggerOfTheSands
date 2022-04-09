using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectScript : MonoBehaviour
{

    [Header("Classes")]
    [SerializeField] PlayerController playerController;

   // [Header("Particle Effects")]
   // [SerializeField] public Transform groundEffect;

    // Start is called before the first frame update
    void Start()
    {
        //groundEffect.GetComponent<ParticleSystem>().enableEmission = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if(collision.tag == "Ground")
           // groundEffect.GetComponent<ParticleSystem>().Play();

    }
}
