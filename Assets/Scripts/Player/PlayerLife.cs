using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour {

    [Header("Information")]
    public Rigidbody2D rb;
    [Tooltip("Asignar multiplicador de la gravedad inicial")] public float gravity;
    [SerializeField] private int hitsTaken = 0;
    public List<Sprite> sprites;
    private SpriteRenderer spriteRenderer;

    private void OnEnable() {
        GameManager.OnPlayerHit += increaseGravity;
        GameManager.OnPlayerHit += changeSprite;
    }

    private void OnDisable() {
        GameManager.OnPlayerHit -= increaseGravity;
        GameManager.OnPlayerHit -= changeSprite;
    }

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravity;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject != null){
            //Destroy(gameObject);
            Debug.Log("Chocaste con algo: Disminuyendo velocidad");
            //Aumentando la gravedad
            FindObjectOfType<GameManager>().PlayerHitted();
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

    private void changeSprite() {
        if (hitsTaken <= 3){
            spriteRenderer.sprite = sprites[hitsTaken];
            Debug.Log("Cambiarndo sprite "+ hitsTaken);
        }
    }

    private void increaseGravity(){
        hitsTaken++;

        if(hitsTaken == 1) {
            gravity += 1.5f;
        }
        else if(hitsTaken == 2 || hitsTaken == 3) {
            gravity += 1f; 
        }
        else if(hitsTaken >= 4 && hitsTaken <= 6) {
            gravity += 2f;
        }
        else  {
            gravity += 1.5f;
        }
        //Mostrando y actualizando gravedad
        rb.gravityScale = gravity;
        gravity = rb.gravityScale;
    }
}
