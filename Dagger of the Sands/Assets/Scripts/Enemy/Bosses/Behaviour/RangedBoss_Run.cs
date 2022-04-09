using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBoss_Run : StateMachineBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackCooldown;
    private float cooldownTimer = Mathf.Infinity;
    Transform player;
    Rigidbody2D rigidBody;
    BossFlip bossFlip;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossFlip = animator.GetComponent<BossFlip>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidBody = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target = new Vector2(player.position.x, rigidBody.position.y);
        Vector2 newPos = Vector2.MoveTowards(rigidBody.position, target, speed * Time.fixedDeltaTime);
        rigidBody.MovePosition(newPos);
        bossFlip.LookAtPlayer();

        if (Vector2.Distance(player.position, rigidBody.position) <= attackRange)
        {
            if (cooldownTimer > attackCooldown)
            {
                cooldownTimer = 0;
                animator.SetTrigger("Attack");
            }
        }

        cooldownTimer += Time.deltaTime;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
