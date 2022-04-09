using UnityEngine;

public class Attack : MonoBehaviour
{

    [Header("Classes")]
    [SerializeField] PlayerController playerController;

    [Header("Specifications")]
    [SerializeField] public int damage;
    [SerializeField] public float attackRange;
    [SerializeField] public Transform attackPoint;
    [SerializeField] public LayerMask enemyLayer;
    [SerializeField] public float attackRate;

    [SerializeField] private float attackCooldown;
    private float cooldownTimer = Mathf.Infinity;

    private float nextAttackTime = 0;

    private void Awake()
    {
        damage = playerController.playerStatus.currentDamage;
    }

    private void Update()
    {

        if (!playerController.isGamePaused)
        {
            AttackAnimation();
        }

    }

    private void AttackAnimation()
    {
        if (playerController.playerInputScript.attackInput && cooldownTimer > attackCooldown)
        {
            playerController.anim.SetBool("Attack", true);

            if (!playerController.playerSpaceDetection.IsGrounded())
            {
                playerController.anim.SetBool("isGrounded", false);
                playerController.anim.SetBool("DoubleJump", false);
            }
        }
        else
        {
            playerController.anim.SetBool("Attack", false);
        }
        cooldownTimer += Time.deltaTime;
    }

    public void AttackAction()
    {
        MeleeAttack();
    }
    private void MeleeAttack()
    {
        //Attack Effects.
        AttackEffects();

        //Deteck enemies in range. 
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        cooldownTimer = 0;

        Debug.Log("Attacking");

        //Damage enemies.
        foreach (Collider2D enemy in hitEnemies)
        {
            if(enemy.GetComponent<EnemyHealth>() != null)
                enemy.GetComponent<EnemyHealth>().TakeDamage(damage);

            if(enemy.GetComponent<NonCombatHealth>() != null)
                enemy.GetComponent<NonCombatHealth>().TakeDamage(damage);

            if(enemy.GetComponent<BossHealth>() != null)
                enemy.GetComponent<BossHealth>().TakeDamage(damage);

            playerController.mana.RegenMana();
        }

    }

    private void AttackEffects()
    {
        if (playerController.playerSpaceDetection.IsGrounded() || playerController.rigidBody.velocity.y != 0)
        {
            //Attack audio clip.
            FindObjectOfType<AudioManager>().PlaySound("Attack");
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
