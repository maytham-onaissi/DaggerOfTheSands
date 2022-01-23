using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float downwardForce;
    float horizontalInput;

    [Header("General")]
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider; 
    private Animator anim;

    [Header("Layer Masks")]
    [SerializeField] private LayerMask groundLayer;

    [Header("Jump")]
    [SerializeField] private float jumpPower;

    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound; 
    [SerializeField] private AudioClip meleeSound; 

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        HorziontalMovement();
        Jump(jumpPower);
    }

    private void HorziontalMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector2(horizontalInput * movementSpeed, rigidBody.velocity.y);

        if(horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        anim.SetBool("Run", horizontalInput != 0);

    }

    private void Jump(float _jumpPower)
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, _jumpPower);
            anim.SetTrigger("Jump");
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
