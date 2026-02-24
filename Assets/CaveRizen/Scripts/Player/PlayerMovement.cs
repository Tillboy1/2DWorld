using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public GameObject cameraHolder;

    private Vector2 m_moveAmt;
    private bool isjumpHeld; // Clicking jump
    private bool isHeldJump; // holding jump
    private bool isOnGround;
    private bool canJumpAgain = true;

    public Rigidbody2D rb;

    [SerializeField]
    public LayerMask groundMask;

    public float moveSpeed = 5;
    public float jumpPower = 5;
    public float jumpTimeHoldable;

    public GameObject PauseDisplay;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        canJumpAgain = true; 
    }

    private void Update()
    {

        Debug.DrawRay(this.transform.position, Vector2.down * 1.0f, Color.red);
        
        Jump();
        //DisplayPause();
    }

    public void Jump()
    {
        isOnGround = Groundcheck(0f);
        // if is the jump button held
        if (isjumpHeld)
        {
            // and if the player is on ground
            if (isOnGround)
            {
                // can the player jump again, thisis the lock.
                if (canJumpAgain)
                {
                    rb.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
                    canJumpAgain = false;
                    StartCoroutine(DelayedJump());
                }
            }
            else if(isHeldJump)
            {
                rb.AddForce(new Vector2(0, jumpPower));
            }

        }
    }

    private void FixedUpdate()
    {
        if(this.gameObject.GetComponent<PlayerStats>().currentlyDead == false)
        {
            Walking();
        }
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        m_moveAmt = context.ReadValue<Vector2>();
    }

    public void JumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isHeldJump = true;
        }
        if (context.performed)
        {
            isHeldJump = false;
        }
        isjumpHeld = context.ReadValue<float>() > 0;
    }

    public void Walking()
    {
        rb.position = new Vector2(rb.position.x + (m_moveAmt.x * moveSpeed), rb.position.y);
    }

    public bool Groundcheck(float Length)
    {
        RaycastHit2D hit;

        hit = Physics2D.Raycast(this.transform.position, Vector2.down, Length, groundMask);
        Debug.DrawRay(this.transform.position, Vector2.down, Color.red);
        
        return hit;
    }

    /*
    private void DisplayPause()
    {
        if (m_pauseActionPlayer.WasPressedThisFrame())
        {
            PauseDisplay.SetActive(true);
            inputActions.FindActionMap("Player").Disable();
            inputActions.FindActionMap("UI").Enable();
        }
        else if (m_pauseActionUi.WasPressedThisFrame())
        {
            PauseDisplay.SetActive(false);
            inputActions.FindActionMap("Player").Enable();
            inputActions.FindActionMap("UI").Disable();
        }
    }
    */

    IEnumerator DelayedJump()
    {
        yield return new WaitForSeconds(.15f);
        canJumpAgain = true;
    }
}
