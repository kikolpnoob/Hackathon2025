using System;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "Abilities/Dash")]
public class DashAbility : Ability
{
    private Rigidbody2D rb;
    public float dashVel;
    

    public override void UseAbility()
    {
        base.UseAbility();
        
        rb.linearVelocity = GetMouseDirection() * dashVel;
        
        Debug.Log(GetMouseDirection() * dashVel);
    }

    public Vector2 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public Vector2 GetMouseDirection()
    {
        return (GetMousePosition() - (Vector2)Boss.Transform.position).normalized;
    }
}
