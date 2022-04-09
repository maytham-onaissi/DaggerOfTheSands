using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputScript : MonoBehaviour
{
    [Header("Classes")]
    [SerializeField] PlayerController playerController;

    [Header("Horizontal Input")]
    public float horizontalInput;

    [Header("Downward force Input")]
    public bool downwardForceInput;

    [Header("Jump Input")]
    public bool jumpInput;
    public bool stilljumpingInput;
    public bool notjumpingInput;

    [Header("Double Jump Input")]
    public bool doubleJumpInput;
    public bool notDoubleJumpingInput;

    [Header("Serpent Fangs Input")]
    public bool serpentFangsInput;

    [Header("Serpent Step Input")]
    public bool serpentStepInput;
    
    [Header("Attack Input")]
    public bool attackInput;
    
    [Header("heal Input")]
    public bool healInput;

    [Header("Wall slide jump Input")]
    public bool wallSlideJumpInput;

    [Header("Map system Input")]
    public bool mapInput;
    public bool notMapInput;

    void Start()
    {
        //Debug.Log("Input Script");
    }

    // Update is called once per frame
    private void Update()
    {
        if (!playerController.isGamePaused)
        {
            MapInput();
            HealInput();
            AttackInput();
            JumpingInput();
            DoubleJumpInput();
            SerpentStepInput();
            SerpentFangsInput();
            WallSlideJumpInput();
            DownwardForceInputInput();
            HorizontalMovementInput();
        }
    }

    //---------------------------------------------------
    //Horizontal movement Input.
    //---------------------------------------------------
    private void HorizontalMovementInput()
    {
        //Cache the horzionatl input. 
        horizontalInput = Input.GetAxis("Horizontal");
    }

    //---------------------------------------------------
    //Downward force Input.
    //---------------------------------------------------
    private void DownwardForceInputInput()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            downwardForceInput = true;
        }
        else { downwardForceInput = false; }
    }


    //---------------------------------------------------
    //Jump Input.
    //---------------------------------------------------
    private void JumpingInput()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { 
            jumpInput = true; } 
        else { jumpInput = false; }

        if (Input.GetKey(KeyCode.Space)) {
            stilljumpingInput = true; } 
        else { stilljumpingInput = false; }

        if (Input.GetKeyUp(KeyCode.Space)) {
            notjumpingInput = true; } 
        else { notjumpingInput = false; }

    }

    //---------------------------------------------------
    //Double jump Input.
    //---------------------------------------------------
    private void DoubleJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            doubleJumpInput = true;
        }
        else { doubleJumpInput = false; }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            notDoubleJumpingInput = true;
        }
        else { notDoubleJumpingInput = false; }

    }

    //---------------------------------------------------
    //Serpent Fangs Input.
    //---------------------------------------------------
    private void SerpentFangsInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            serpentFangsInput = true;
        }
        else { serpentFangsInput = false; }
    }

    //---------------------------------------------------
    //Serpent Step Input.
    //---------------------------------------------------
    private void SerpentStepInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            serpentStepInput = true;
        }
        else { serpentStepInput = false; }
    }

    //---------------------------------------------------
    //Attack Input.
    //---------------------------------------------------
    private void AttackInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            attackInput = true;
        }
        else { attackInput = false; }
    }

    //---------------------------------------------------
    //Wall slide jump Input.
    //---------------------------------------------------
    private void WallSlideJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            wallSlideJumpInput = true;
        }
        else { wallSlideJumpInput = false; }
    }

    //---------------------------------------------------
    //Heal Input.
    //---------------------------------------------------
    private void HealInput()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            healInput = true;
        }
        else { healInput = false; }
    }

    //---------------------------------------------------
    //Map Input.
    //---------------------------------------------------
    private void MapInput()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            mapInput = true;
        }
        else { mapInput = false; }

        if (Input.GetKeyUp(KeyCode.M))
        {
            notMapInput = true;
        }
        else { notMapInput = false; }


    }
}
