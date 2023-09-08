using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour {

    [Header("Information")]
    public GameObject explosion;
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            ExplosionManager.instance.Explosion(transform.position);
            gameObject.SetActive(false);

        }
    }
}