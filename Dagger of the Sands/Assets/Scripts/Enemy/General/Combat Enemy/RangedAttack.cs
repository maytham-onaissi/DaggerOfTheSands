using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    [Header("Attack Specifications")]
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Transform firePoints;
    [SerializeField] private GameObject[] fireBalls;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float range; 
    [SerializeField] private float colliderDistance;
    [SerializeField] private float attackCooldown;
    private float cooldownTimer = Mathf.Infinity;
    
    private Animator anim;



    // Start is called before the first frame update
    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        //if (Input.GetKeyDown(KeyCode.F))
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("Attack");
            }
        }
    }

    private void Attack()
    {
        cooldownTimer = 0;
        fireBalls[FindFireBall()].transform.position = firePoints.position;
        fireBalls[FindFireBall()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private int FindFireBall()
    {
        for (int i = 0; i < fireBalls.Length; i++)
        {
            if (!fireBalls[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    private bool PlayerInSight()
    {
        // "boxCollider.bounds.center + transform.right * range" is used to determine the range of the box
        // and multiplying it with "transform.localScale.x" to make it flip according to the transform movement.
        // for multiplying by "colliderDistance" the box position is determined and it was added due to the multiplication that happened in
        // "new Vector3(boxCollider.bounds.size.x * range", because range is being in both places, which results in the box moving away from 
        // the transform while increasing its size, therefore colliderDistance is used here. 
        
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 
            0, Vector2.left, 0, playerLayer);


        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
}
