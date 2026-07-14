using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private PlayerInput playerInput;
    private InputAction moveAction;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
       
    }
    private void Start()
    {


    }
    private void Update()
    {
       
        moveInput = moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
      
        Vector3 movementVector =
            (transform.right * moveInput.x + transform.forward * moveInput.y).normalized;

        Vector3 moveVelocity = movementVector * moveSpeed;

        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}