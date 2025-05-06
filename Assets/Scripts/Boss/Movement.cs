using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{ // Coded by kiko

    private Rigidbody2D rb;
    public static Transform userTransform;
    
    [Header("Speed")]
    public float speed = 5.0f; 
     
    [Header("Other")]
    public Rigidbody2D rigidBody; // Fyzika telesa (bude sa cez to interagovať s hráčom)
    private Vector2 moveDir; // Smer pohybu


    private void Awake()
    {
        userTransform = transform;
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update() {
        moveDir.x = Input.GetAxisRaw("Horizontal"); 
        moveDir.y = Input.GetAxisRaw("Vertical"); 
        moveDir = moveDir.normalized;
    }

    void FixedUpdate() {

        rb.AddForce(moveDir * speed * rb.mass);
    }
}

//        x horizontal  y vertical