using UnityEngine;

public abstract class Hero : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public float movementSpeed;

    public float minDistanceFromPlayer;
    public float maxDistanceFromPlayer;

    public bool isIdealDistance { get { float f = _distanceFromPlayer; return f > minDistanceFromPlayer && f < maxDistanceFromPlayer; } }

    protected float _distanceFromPlayer { get { return Vector2.Distance(Boss.Transform.position, transform.position); } }
    protected Vector2 _directionToPlayer { get { return (Boss.Transform.position - transform.position).normalized; } }
    private Rigidbody rb;

    public float maxStamina;
    public float actionStaminaCost;
    [Header("Hero specific values")]
    private float _stamina;


    void FixedUpdate()
    {
        _stamina = Mathf.Clamp(_stamina + Time.fixedDeltaTime, 0, maxStamina);
        if (_stamina > actionStaminaCost && isIdealDistance)
        {
            Action();
            _stamina -= actionStaminaCost;
        }
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

        if (health == 0)
            Destroy(gameObject); // gameOver
    }
}
