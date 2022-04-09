using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform spawnPoint;
    [SerializeField] CircleCollider2D circleCollider;
    [SerializeField] bool inRange;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(RespawnPlayer());
    }

    public IEnumerator RespawnPlayer()
    {
        if (player.GetComponent<Health>().dead && inRange)
        {
            yield return new WaitForSeconds(1f);

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
