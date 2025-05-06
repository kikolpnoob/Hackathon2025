using UnityEngine;

public class BossMovement : MonoBehaviour
{
     [Header("Movement Settings")]
    public float maxSpeed = 5f;
    public float acceleration = 30f;
    public float deceleration = 20f;

    private Rigidbody2D rb;
    private Vector2 movementInput;
    private Vector2 currentVelocity;
    private Vector2 smoothVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearDamping = 0f;
    }

    private void Update()
    {
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        if (movementInput.magnitude > 1)
        {
            movementInput.Normalize();
        }
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 targetVelocity = movementInput * maxSpeed;
        
        if (movementInput.magnitude > 0)
        {
            currentVelocity = Vector2.Lerp(
                currentVelocity, 
                targetVelocity, 
                acceleration * Time.fixedDeltaTime
            );
        }
        else
        {
            currentVelocity = Vector2.Lerp(
                currentVelocity, 
                Vector2.zero, 
                deceleration * Time.fixedDeltaTime
            );
        }
        rb.linearVelocity = currentVelocity;
    }
}
