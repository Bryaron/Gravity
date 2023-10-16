using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour {

    [Header("Information")]
    [SerializeField]private float lifeTime = 5f;

    private void Start() {
        StartCoroutine(DestroyAfterTime());
    }

    //Utilizo el clase ExplosionManager para generar las explosiones
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            ExplosionManager.instance.Explosion(transform.position);
            gameObject.SetActive(false);
        }
    }

    IEnumerator DestroyAfterTime() {
        yield return new WaitForSeconds(lifeTime);
        ExplosionManager.instance.Explosion(transform.position);
        gameObject.SetActive(false);
    }
}
