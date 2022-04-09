using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{


    [Header("Classes")]
    [SerializeField] EnemyController enemyController;
    [SerializeField] GameObject patrol;

    [Header("Specifications")]
    [SerializeField] public int maxHealth;
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
        enemyController.anim.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        //Die animation.
        enemyController.anim.SetBool("Die", true);
        isDead = true;
    }

    IEnumerator DisableScript()
    {
        if (isDead)
        {
            //Disable script.
           // yield return new WaitForSeconds(1);

            enemyController.rb.bodyType = RigidbodyType2D.Dynamic;

            GetComponent<BoxCollider2D>().enabled = false;

            enemyController.enemyCombat.enabled = false;

            //patrol.GetComponent<EnemyPatrol>().enabled = false;
            enemyController.enemyPatrol.enabled = false;

            yield return new WaitForSeconds(2);

            Destroy(enemyController.enemyHandler);
            //this.enabled = false;
        }
    }

}
