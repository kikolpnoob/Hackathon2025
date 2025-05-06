using UnityEngine;

[System.Serializable]
public class Ability
{
    public string name;
    public string description;
    public int manaCost;
    public bool isActive;
    public virtual void UseAbility() { }
}
