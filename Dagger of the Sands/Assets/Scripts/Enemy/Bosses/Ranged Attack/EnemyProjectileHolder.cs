using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileHolder : MonoBehaviour
{
    [SerializeField] private Transform enemy;

    private void Update()
    {
        transform.rotation = enemy.rotation;
        Destroy();
    }

    private void Destroy()
    {
        if (enemy == null)
            Destroy(gameObject);
    }
}
