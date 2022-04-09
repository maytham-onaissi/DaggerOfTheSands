using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonCombatPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftPos;
    [SerializeField] private Transform rightPos;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    private bool movingLeft;
    private Vector3 initScale;


    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftPos.position.x)
                MoveInDirection(-1);
            else
            {
                //Change direction.
                ChangeDirection();
            }

        }
        else
        {
            if (enemy.position.x <= rightPos.position.x)
                MoveInDirection(1);
            else
            {
                //Change direction.
                ChangeDirection();
            }

        }
    }

    private void MoveInDirection(int _direction)
    {
        //MovementAnimation.
        enemy.GetComponent<NonCombatEnemyController>().anim.SetBool("Run", true);

        //Set Idle time to zero when moving in direction. 
        idleTimer = 0;

        //Make enemy face direction.
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);

        //Move in that direction.
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * movementSpeed, enemy.position.y, enemy.position.z);
    }

    private void ChangeDirection()
    {
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }
}
