using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public GameObject cameraHolder;

    public InputActionAsset inputActions;

    private InputAction m_moveAction;
    private InputAction m_jumpAction;
    private InputAction m_pauseActionPlayer;
    private InputAction m_pauseActionUi;

    private Vector2 m_moveAmt;
    private Rigidbody2D m_rigidbodyb;

    [SerializeField]
    public LayerMask groundMask;

    public float moveSpeed = 5;
    public float jumpPower = 5;
    public float jumpTimeHoldable;

    public GameObject PauseDisplay;

    private void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
    }
    private void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        m_moveAction = InputSystem.actions.FindAction("Move");
        m_jumpAction = InputSystem.actions.FindAction("Jump");

        m_rigidbodyb = GetComponent<Rigidbody2D>();

        m_pauseActionPlayer = InputSystem.actions.FindAction("Player/Menu");
        m_pauseActionUi = InputSystem.actions.FindAction("UI/Menu");
    }

    private void Update()
    {
        m_moveAmt = m_moveAction.ReadValue<Vector2>();

        Debug.DrawRay(this.transform.position, Vector2.down * 1.0f, Color.red);
        if (m_jumpAction.IsPressed() && Groundcheck())
        {
            Jump();
        }

        DisplayPause();
    }

    public void Jump()
    {
        m_rigidbodyb.AddForceAtPosition(new Vector2(0, jumpPower), Vector2.up, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        Walking();
    }
    public void Walking()
    {
        m_rigidbodyb.position = new Vector2(m_rigidbodyb.position.x + (m_moveAmt.x * moveSpeed), m_rigidbodyb.position.y);
    }
    public bool Groundcheck()
    {
        RaycastHit2D hit;

        hit = Physics2D.Raycast(this.transform.position, Vector2.down, 0.8f, groundMask);
        Debug.DrawRay(this.transform.position, Vector2.down * 1.0f, Color.red);
        
        return hit;
    }

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
}
