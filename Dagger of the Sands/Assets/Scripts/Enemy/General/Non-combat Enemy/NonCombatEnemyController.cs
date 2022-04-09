using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonCombatEnemyController : MonoBehaviour
{
    [Header("Classes")]
    [SerializeField] public NonCombatHealth nonCombatHealth;

    [Header("General")]
    public Animator anim;
    public Rigidbody2D rb;
    public BoxCollider2D boxCollider;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
