using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEffect : MonoBehaviour
{
    [SerializeField] private GameObject dustCloud;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Ground"))
            Instantiate(dustCloud, transform.position, dustCloud.transform.rotation);
    }
}
