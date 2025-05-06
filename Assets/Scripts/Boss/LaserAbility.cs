using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "Abilities/LaserAbility")]
public class LaserAbility : Ability
{
    public override void UseAbility()
    {
        base.UseAbility();

        Boss.Transform.GetComponent<LaserBeamController>().StartLaser();
    }
}
