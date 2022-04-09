using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoss : MonoBehaviour
{
    [SerializeField] BossHealth boss;
    // Start is called before the first frame update
    void Start()
    {
        boss = FindObjectOfType<BossHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boss.isDead)
            Destroy(gameObject);
    }
}
