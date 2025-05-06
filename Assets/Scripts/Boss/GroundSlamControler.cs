using UnityEngine;

public class GroundSlamControler : MonoBehaviour
{
    public float GroundSlamRadius;
    public LayerMask enemyLayerMask;

    public int damage;
    public Collider2D[] enemies;
    private bool CanAttack = false;


    void Start()
    {

    }

    void Update()
    {
        if (CanAttack)
        {
            enemies = Physics2D.OverlapCircleAll(GetSwingPosition(), GroundSlamRadius, enemyLayerMask); // Toto nejde ... stale to je null
            CanAttack = false;
            if (enemies != null)
            {
                foreach (Collider2D enemy in enemies)
                {
                    Debug.Log("deal damage to ");
                    enemy.GetComponentInParent<Hero>().EditHealth(-damage);
                }
            }
        }
    }


    public void StartGroundSlam()
    {
        CanAttack = true;
    }

    public Vector2 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    public Vector2 GetSwingPosition()
    {
        return (Vector2)transform.position + (GetMousePosition() - (Vector2)transform.position).normalized;
    }
    /*private void OnDrawGizmosSelected()
    {
        Handles.color = Color.blue;
        Handles.DrawWireDisc(GetSwingPosition(), Vector3.forward, GroundSlamRadius);
    }*/
}

