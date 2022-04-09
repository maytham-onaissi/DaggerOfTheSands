using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStuck : MonoBehaviour
{
    private float checkTime = 0.001f;
    private Vector2 oldPos;
    [SerializeField] private PlayerWaypointMovement playerWaypoint;

    private void Update()
    {
        CheckPosition();
    }

    private void CheckPosition()
    {
        if (checkTime <= 0)
        {
            oldPos = transform.position;
            checkTime = 0.001f;
        }
        else
        {
            checkTime -= Time.deltaTime;
        }

        if (Vector2.Distance(transform.position, oldPos) < 0.1f)
        {
            playerWaypoint.speed = 0f;
        }
        else
        {
            playerWaypoint.speed = 2f;
        }
    }

}
