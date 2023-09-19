using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour {

    [Header("Information")]
    public Rigidbody2D rb;
    [Tooltip("Asignar multiplicador de la gravedad inicial")] public float gravity;
    public int hitsTaken = 0;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravity;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject != null){
            //Destroy(gameObject);
            Debug.Log("Chocaste con algo: Disminuyendo velocidad");
            //Aumentando la gravedad
            hitsTaken++;
            switch (hitsTaken) {
                case 1: gravity = 2.5f;
                break;
                case 2: gravity = 3.5f;
                break;
                case 3: gravity = 4.5f;
                break;
                case 4: gravity = 6.5f;
                break;
                case 5: gravity = 8.5f;
                break;
                case 6: gravity = 10.5f;
                break;
            }
            //Mostrando y actualizando gravedad
            rb.gravityScale = gravity;
            gravity = rb.gravityScale;

        }

        if (collision.CompareTag("Edges")){
            //gameObject.SetActive(false);
            ExplosionManager.instance.Explosion(transform.position);
            gameObject.SetActive(false);
            Debug.Log("Saliste de la ruta de escape, Eliminandote");
            /*
            Buscando al GameManager en escena para usar su funcion
            que verifica mi evento OnPlayerDeath
             */
            FindObjectOfType<GameManager>().PlayerKilled();
        }
    }
}
