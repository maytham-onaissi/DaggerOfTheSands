using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonCombatHealth : MonoBehaviour
{

    [Header("Classes")]
    [SerializeField] NonCombatEnemyController nonCombatEnemyController;
    [SerializeField] GameObject patrol;

    [Header("Specifications")]
    [SerializeField] public int maxHealth;
    [SerializeField] public float speed;
    public bool isDead;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        isDead = false;
    }

    private void Update()
    {
        StartCoroutine(DisableScript());
    }

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;

        //Hurt animation.
        nonCombatEnemyController.anim.SetTrigger("Hurt");

        if(currentHealth > 0)
            nonCombatEnemyController.anim.SetBool("Die", false);

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        //Die animation.
        nonCombatEnemyController.anim.SetBool("Die", true);
        isDead = true;
    }

    IEnumerator DisableScript()
    {
        if (isDead)
        {
            //Disable script.
            GetComponent<BoxCollider2D>().enabled = false;

            nonCombatEnemyController.rb.bodyType = RigidbodyType2D.Dynamic;

            patrol.GetComponent<NonCombatPatrol>().enabled = false;

            yield return new WaitForSeconds(1);

            this.enabled = false;

        }
    }
}
