using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{

    [HideInInspector] public LayerMask layerMask;
    [HideInInspector] public float speed;
    [HideInInspector] public int damage;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.linearVelocity = transform.up * speed;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if ((layerMask.value & (1 << other.gameObject.layer)) != 0) // if layerMask contains triggerEnter objects layer
        {
            other.GetComponentInParent<Boss>()?.EditHealth(-damage);
            other.GetComponentInParent<Hero>()?.EditHealth(-damage);

            Destroy(gameObject);
        }
    }
}