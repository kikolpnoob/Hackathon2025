using UnityEngine;

public class Knight : Hero
{
    // public float 
    public Collider2D damageCol;
    private void Start()
    {
        damageCol.gameObject.SetActive(false);
    }
    protected override void Action()
    {
        base.Action();
        // var cols = Physics2D.OverlapBox();
    }
}