using UnityEngine;
using UnityEngine.Serialization;

public class Boss : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int xp;
    public int mana;
    public static Transform Transform;
    
    public float meeleAttackRadius;
    public Vector2 hitDirection;
    public LayerMask enemyLayerMask;
    
    public int damage; // TODO: ...

    public float delay = 1;
    public bool CanAttack = true;
    public float timer = 0;
    
    public Collider2D[] enemies;


    
    private void Start()
    {
        Transform = transform;
    }
    
    private void Update()
    {
        if (!CanAttack)
        {
            while (timer < delay)
            {
                timer += Time.deltaTime;
            }
            
            CanAttack = true;
            timer = 0;
        }
        
        if (Input.GetMouseButtonDown(0) && CanAttack)
        {
            enemies = Physics2D.OverlapCircleAll(GetSwingPosition(), meeleAttackRadius, enemyLayerMask); // Toto nejde ... stale to je null
            Debug.Log("ADD");
            CanAttack = false;
            if (enemies != null)
            {
                foreach (Collider2D enemy in enemies)
                {
                    //TODO: Ubere Demage 
                    Debug.Log("Uberam damage");
                }
            }
        }
    }
    public Vector2 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public Vector2 GetSwingPosition()
    {
        return (Vector2)transform.position + (GetMousePosition() - (Vector2)transform.position).normalized;
    }
}