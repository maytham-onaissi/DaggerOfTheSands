using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [Header("Classes")]
    private PlayerController playerController;

    [Header("Specifications")]
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    [SerializeField] private float resetTime;
    [SerializeField] private int damage;
    Rigidbody2D rigidBody;
    [SerializeField] BoxCollider2D boxCollider;
    bool hit;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifeTime += Time.deltaTime;
        if (lifeTime > resetTime)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;

        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }

            anim.SetTrigger("Explode");
    }

    public void ActivateProjectile()
    {
        gameObject.SetActive(true);
        lifeTime = 0;
        hit = false;
        boxCollider.enabled = true; 
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
