using UnityEngine;

public class Ability : ScriptableObject
{
    public string name;
    public string description;
    public int manaCost;
    public bool isActive;

    public virtual void UseAbility()
    {
        // Tu niečo bude...
    }
}
