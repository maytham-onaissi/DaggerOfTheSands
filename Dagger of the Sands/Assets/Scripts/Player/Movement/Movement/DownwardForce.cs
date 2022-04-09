using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownwardForce : MonoBehaviour
{

    [Header("Classes")]
    [SerializeField] PlayerController playerController;

    // Update is called once per frame
    void Update()
    {
        if(!playerController.isGamePaused)
        {
            if (!playerController.WallSlide.wallSliding)
                DownwardForceMovement();
        }
    }

    private void DownwardForceMovement()
    {
        playerController.anim.SetFloat("yVelocity", playerController.rigidBody.velocity.y);
    }

}
