using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputActionAsset Inputactions;

    private InputAction m_moveAction;
    private InputAction m_jumpAction;

    private Vector2 m_moveAmt;
    public Rigidbody2D m_rigidbodyb;

    public float moveSpeed;
    public float jumpPower;

    private Vector2 _moveDirection;
    private bool _isJumping = false;

    [Header("Inputs Used")]
    public InputActionReference move;
    public InputActionReference jump;

    public void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        m_rigidbodyb.position = new Vector2(m_rigidbodyb.position.x + (_moveDirection.x * moveSpeed), m_rigidbodyb.position.y);


        // Working with side only movement
        //rb.position = new Vector2(rb.position.x + (_moveDirection.x * moveSpeed), rb.position.y);

        //working with vertical movement
        //rb.position = new Vector2(rb.position.x + (_moveDirection.x * moveSpeed), rb.position.y + (_moveDirection.y * moveSpeed));
    }

    private void OnEnable()
    {
        //_isJumping = true;
        //jump.action.started += Jump;
    }
    private void OnDisable()
    {
        //_isJumping = false;
        //jump.action.started -= Jump;
    }
    private void Jump(InputAction.CallbackContext obj)
    {
        m_rigidbodyb.position = new Vector2(m_rigidbodyb.position.x + (_moveDirection.x * moveSpeed), m_rigidbodyb.position.y + (1f * jumpPower));
    }
}
