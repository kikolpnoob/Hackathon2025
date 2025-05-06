using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Hero : MonoBehaviour
{
    [HideInInspector] public int health;
    public int maxHealth;
    public float movementSpeed;

    public float minDistanceFromPlayer;
    public float maxDistanceFromPlayer;

    public bool isIdealDistance { get { float f = _distanceFromPlayer; return f > minDistanceFromPlayer && f < maxDistanceFromPlayer; } }

    protected float _distanceFromPlayer { get { return Vector2.Distance(Boss.Transform.position, transform.position); } }
    protected Vector2 _directionToPlayer { get { return (Boss.Transform.position - transform.position).normalized; } }
    protected Rigidbody2D rb;

    public bool isUsingAction;

    public float actionStaminaCost;
    [Tooltip("100 stamina per second")]
        int maxStamina = 100;
    [Header("Hero specific values")]
    float _stamina;


    void Awake()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (isUsingAction)
            return;
        _stamina = Mathf.Clamp(_stamina + Time.fixedDeltaTime * 100, 0, maxStamina);
        if (_stamina > actionStaminaCost && isIdealDistance)
        {
            Action();
            _stamina -= actionStaminaCost;
        }
        MoveToPreferredDistance();
    }


    protected void MoveToPreferredDistance()
    {
        float dist = _distanceFromPlayer;
        if (dist < minDistanceFromPlayer)
            rb.AddForce(-_directionToPlayer * movementSpeed * rb.mass);
        else if (dist > maxDistanceFromPlayer)
            rb.AddForce(_directionToPlayer * movementSpeed * rb.mass);
    }
    protected virtual void Action()
    {
        // hero specific
    }

    public void EditHealth(int value)
    {
        health = Mathf.Clamp(health + value, 0, maxHealth);

        Debug.Log(health);
        if (health == 0)
            Destroy(gameObject); // gameOver
    }
}
