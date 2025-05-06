using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int xp;
    public int mana;
    public static Transform Transform;
    private void Start()
    {
        Transform = transform;
    }
}