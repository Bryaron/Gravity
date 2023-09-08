using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    [Header("Information")]
    public Rigidbody2D rb;
    public float movementX;
    public float movementY;

    [Header("Configuration")]
    public Rigidbody2D enemy;
    public float speed;
    public float rotationSpeed;
    public float maxSpeed; 
    [Tooltip("Asignar multiplicador de la gravedad inicial")] public float gravity;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravity;
    }
    
    private void OnMove(InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate() {
        //Rotación del jugador
        rb.rotation -= movementX * rotationSpeed;
        //Aumento de velocidad
        speed = Mathf.Clamp(speed + movementY, 1.5f, maxSpeed);
        //Movimiento del jugador
        //rb.velocity = new Vector2(movementX, movementY) * speed;
        rb.velocity = transform.up * speed;
    }
}

/* Notas :
GravityScale normal del jugador: 1

Primer golpe: aumentar a 1.5f

Segundo golpe: aumentar a 2f

Tercer golpe: aumentar a 3f

Cuarto golpe: aumentar a 4f

Quinto golpe: aumentar a 8f
 */