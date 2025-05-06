using UnityEngine;

public abstract class Hero : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public float movementSpeed;
    public float minDistanceFromPlayer;
    public float maxDistanceFromPlayer;

    [Header("Hero specific values")]
    private float stamina;


    protected void MoveToTarget()
    {
        
    }
    protected void Action()
    {
        
    }
}
