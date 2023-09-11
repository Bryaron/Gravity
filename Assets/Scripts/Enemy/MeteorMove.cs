using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMove : MonoBehaviour {

    [Header("Information")]
    public Rigidbody2D rb;
    public float angle;
    [Header("Configuration")]
    public Transform target;
    public float speed = 1f;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate() {
        FallingMeteor();
    }

    //Comportamiento de meteoritos
    private void FallingMeteor() {
        if (transform.position.y > target.position.y) {
            //Avanzando hacia el jugador
            rb.velocity = (target.position - transform.position).normalized * speed;
            //Sacando el angulo mediante un cateto opuesto y el adyacente
            angle = Mathf.Atan2(transform.position.x - target.position.x, target.position.y - transform.position.y) * Mathf.Rad2Deg;
            rb.rotation = angle;
        } else {
            // Deja de seguir al jugador y sigue girando dependiendo.
            rb.velocity = Vector2.down * speed; 
            AdjustRotation();
        }
    }

    //Otras funciones que apoyan
    private void AdjustRotation() {
        if (rb.rotation > 0f) {
            rb.rotation -= 1f;
        } 
        else {
            rb.rotation += 1f;
        }
    }
}
