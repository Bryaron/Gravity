using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMove : MonoBehaviour
{
    [Header("Information")]
    public Rigidbody2D rb;
    public float angle;
    [Header("Configuration")]
    public Transform target;
    public float speed;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        //Sacando el angulo mediante un cateto opuesto y el adyacente
        angle = Mathf.Atan2(transform.position.x - target.position.x, target.position.y - transform.position.y) * Mathf.Rad2Deg;
        rb.rotation = angle;
        //Avanzando hacia el jugador
        rb.velocity = (target.position - transform.position).normalized * speed;
    }
}
