using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{

    [Header("Classes")]
    [SerializeField] EnemyController enemyController;
    [SerializeField] Health playerHealth;

    [Header("Specifications")]
    [SerializeField] private int Damage;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTime = Mathf.Infinity;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        cooldownTime += Time.deltaTime;

        //Attack only when player is in sight.
        if (PlayerInSight())
        {
            enemyController.enemyPatrol.enabled = false;

            if (cooldownTime >= attackCooldown)
            {
                //Attack
                cooldownTime = 0;
                enemyController.anim.SetTrigger("Attack");
            }
        }
        else
        {
            enemyController.enemyPatrol.enabled = true;
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
        }

        return hit.collider != null;
    }


    public void DamagePlayer()
    {
        if (PlayerInSight())
        {
            playerHealth.TakeDamage(Damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
}
