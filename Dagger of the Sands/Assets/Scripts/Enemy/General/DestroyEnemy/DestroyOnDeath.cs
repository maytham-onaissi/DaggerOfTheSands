using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDeath : MonoBehaviour
{
    [SerializeField] private float delay;
    [SerializeField] private Transform enemyObject;
    public bool canDestroy;
    // Update is called once per frame
    void Update()
    {
        if (enemyObject.GetComponent<EnemyHealth>() != null)
            canDestroy = enemyObject.GetComponent<EnemyHealth>().isDead;

        if (enemyObject.GetComponent<NonCombatHealth>() != null)
            canDestroy = enemyObject.GetComponent<NonCombatHealth>().isDead;

        if(canDestroy)
            Invoke("DestroyEnemy", delay);

        
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
