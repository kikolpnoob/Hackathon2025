using System;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public List<Ability> ownedAbilities = new List<Ability>();
    public List<Ability> allAbilities = new List<Ability>();

    public int mana;
    public int maxMana;
    
    private void Update()
    {
        if (ownedAbilities.Count > 0)
        {
            if ( Input.GetKeyDown((KeyCode.Alpha1)) && mana >= ownedAbilities[0].manaCost)
            {
                mana -= ownedAbilities[0].manaCost;
                ownedAbilities[0].UseAbility();
            }
        }
        
        if (ownedAbilities.Count > 1)
        {
            if ( Input.GetKeyDown((KeyCode.Alpha1)) && mana >= ownedAbilities[1].manaCost)
            {
                mana -= ownedAbilities[1].manaCost;
                ownedAbilities[1].UseAbility();
            }
        }
        
        if (ownedAbilities.Count > 2)
        {
            if ( Input.GetKeyDown((KeyCode.Alpha1)) && mana >= ownedAbilities[2].manaCost)
            {
                mana -= ownedAbilities[2].manaCost;
                ownedAbilities[2].UseAbility();
            }
        }
    }
    
}
