using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MeteorMove : MonoBehaviour {

    [Header("Information")]
    public Rigidbody2D rb;
    public float angle;
    [Header("Configuration")]
    public Transform target;
    public float speed = 1f;
    public int meteorOption = 1;
    private Vector2 direction;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        // Obtener el componente Transform del objeto player para tenerlo por defecto
        if (target == null) {
            // No se ha asignado un target, buscar el objeto Player
            GameObject player = GameObject.FindWithTag("Player");
            target = player.transform; 
        }
    }
    
    private void Awake() {
        //Se usa para directionalMeteor()
        direction = target.position - transform.position;
    }
    
    private void FixedUpdate() {
        switch (meteorOption) {
            case 1: Meteor();
            break;
            case 2: SemiDirectedMeteor();
            break;
            case 3: DirectedMeteor();
            break;
            case 4: DirectionalMeteor();
            break; 
        }

    }

    //Comportamiento de meteoritos
    private void Meteor() {
        rb.velocity = Vector2.down * speed;
    }

    private void SemiDirectedMeteor() {
        if (transform.position.y > target.position.y) {
            //Avanzando hacia el jugador
            rb.velocity = (target.position - transform.position).normalized * speed;
            //Sacando el angulo mediante un cateto opuesto y el adyacente
            AngularDirection();
        } else {
            // Deja de seguir al jugador y sigue girando dependiendo.
            rb.velocity = Vector2.down * speed; 
            AdjustRotation();
        }
    }

    private void DirectedMeteor() {
        rb.velocity = (target.position - transform.position).normalized * speed;
        AngularDirection();
    }

    private void DirectionalMeteor() {
        
        rb.velocity = direction.normalized * speed;
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

    private void AngularDirection() {
        angle = Mathf.Atan2(transform.position.x - target.position.x, target.position.y - transform.position.y) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}
