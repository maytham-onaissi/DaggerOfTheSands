using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] bool inRange;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RespawnPlayer();
    }

    public  void RespawnPlayer()
    {
        if (player.GetComponent<Health>().dead && inRange)
        {
            player.position = transform.position;

            foreach (Behaviour component in player.gameObject.GetComponents<Behaviour>())
            {
                component.enabled = true;
            }

            player.GetComponent<Health>().dead = false;
            player.GetComponent<Health>().ReturnFullHealthUI();
            player.GetComponent<PlayerController>().anim.SetBool("Die", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        inRange = false;
    }
}
