using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Projectile : MonoBehaviour
{

    [Header("General")]
    [SerializeField] private BoxCollider2D boxCollider;
    private Animator anim;

    [Header("Specifications")]
    [SerializeField] private float speed;
    [SerializeField] private float disableTime;
    [SerializeField] private int damage;
    [SerializeField] private LayerMask enemyLayer;
    private float duration;
    private float direction;
    private bool hit;
    private bool isGamePaused;
    [SerializeField] private PlayerController playerController;

    [Header("VFX")]
    private GameObject hitEffect;
    private ParticleSystem travelEffect;
    private Transform travelPosition;
    private Transform hitPosition;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGamePaused = playerController.isGamePaused;

        if (!isGamePaused)
        {
            Travel();
            lifeTime();
        }
        OnHit();
    }

    private void Travel()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);
    }

    private void lifeTime()
    {

        duration += Time.deltaTime;
        if (duration > disableTime)
        {
            gameObject.SetActive(false);
            Debug.Log("dead");
        }

    }

    private void OnHit()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(transform.position, boxCollider.bounds.size, 0, enemyLayer);
        

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<EnemyHealth>() != null && !hit)
                enemy.GetComponent<EnemyHealth>().TakeDamage(damage);

            if (enemy.GetComponent<NonCombatHealth>() != null && !hit)
                enemy.GetComponent<NonCombatHealth>().TakeDamage(damage);

            if (enemy.GetComponent<BossHealth>() != null && !hit)
               enemy.GetComponent<BossHealth>().TakeDamage(damage);

            boxCollider.enabled = false;
            hit = true;
            //anim.SetTrigger("Hit");

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(boxCollider.bounds.center, boxCollider.bounds.size);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        hit = true;
        boxCollider.enabled = false;

      //  if (collision.gameObject.tag == "Enemy")
       // {
         //   anim.SetTrigger("Hit");

            /*if (collision.gameObject.GetComponent<EnemyHealth>() != null)
                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);

            if (collision.gameObject.GetComponent<NonCombatHealth>() != null)
            {
                collision.gameObject.GetComponent<NonCombatHealth>().TakeDamage(damage);

            }*/
                Debug.Log("Hit " + collision.gameObject.name);  
        //}

    }

    public void SetDirection(float _direction)
    {
        duration = 0;
        direction = _direction;
        gameObject.SetActive(true);
        boxCollider.enabled = true;
        hit = false;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
}
