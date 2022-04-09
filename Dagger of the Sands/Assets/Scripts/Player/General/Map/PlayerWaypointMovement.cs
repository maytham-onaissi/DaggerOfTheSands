using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaypointMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigidbody;
    [SerializeField] public float speed;
    [SerializeField] private float jumpForce;
    private float horizontalMovement;    

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump(jumpForce);
    }

    private void Movement()
    {

        horizontalMovement = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(horizontalMovement * speed, rigidbody.velocity.y);
    }

    private void Jump(float _jump)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, _jump);
        }
    }
}
