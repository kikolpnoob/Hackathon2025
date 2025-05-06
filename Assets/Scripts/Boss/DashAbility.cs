using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "Abilities/Dash")]
public class DashAbility : Ability
{
    public Rigidbody2D rb;
    public float dashVel;
    public override void UseAbility()
    {
        base.UseAbility();
        
        rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * dashVel;
    } 
}
