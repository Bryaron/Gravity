using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour {

    [Header("Information")]
    public int playerId = 0;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject != null){
            //Destroy(gameObject);
            Debug.Log("Chocaste con algo: Disminuyendo velocidad");
        }

        if (collision.CompareTag("Edges")){
            //gameObject.SetActive(false);
            ExplosionManager.instance.Explosion(transform.position);
            gameObject.SetActive(false);
            Debug.Log("Saliste de la ruta de escape, Eliminandote");
        }
    }
}
