using UnityEngine;
public class SummonMinions : Ability
{
    public GameObject MinionPrefab;
    public override void UseAbility()
    {
        base.UseAbility();

        Object.Instantiate(MinionPrefab, Boss.Transform.position, Quaternion.identity);
    }
    
    
}
