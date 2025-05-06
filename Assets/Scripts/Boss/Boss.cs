using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Boss : MonoBehaviour { // Coded by kiko

    public Transform Transform;
    public static Transform userTransform;
    
    [Header("Speed")]
    public float speedOfMovement = 5.0f; 
    private float aktualSpeed; 

    [Header("Stamina")]
    public float maxStamina = 100.0f;
    public float staminaIncrease = 10.0f;
    public float staminaDecrease = 10.0f;
    public float aktualStamina;
    public bool isSprinting;
     
    [Header("Other")]
    public Rigidbody2D rigidBody; // Fyzika telesa (bude sa cez to interagovať s hráčom)
    private Vector2 movement; // Smer pohybu


    private void Awake()
    {
        userTransform = Transform;
    }

    void Start() {
        aktualStamina = maxStamina;
        aktualSpeed = speedOfMovement;
    }
    
    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal"); 
        movement.y = Input.GetAxisRaw("Vertical"); 
        movement = movement.normalized;
    }

    void FixedUpdate() {
        
        if (isSprinting && aktualStamina > 0 && movement != Vector2.zero) {
            
            aktualStamina -= staminaDecrease * Time.deltaTime;
            
        } else if (aktualStamina < maxStamina) {
            
            aktualSpeed = speedOfMovement;
            aktualStamina += staminaIncrease * Time.deltaTime;
            
        }
        
        rigidBody.MovePosition(rigidBody.position + movement * (aktualSpeed * Time.fixedDeltaTime));
        
    }
}

//        x horizontal  y vertical