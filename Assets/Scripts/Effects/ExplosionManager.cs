using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour {

    public static ExplosionManager instance;
    [Header("Configuration")]
    public  float spawnRadius;
    public  int amount;

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }

        else{
            instance = this;
        }
    }

    public void Explosion(Vector2 centerPosition) {
        for (int i = 0; i < amount; i++) {
            Vector2 randomPosition = centerPosition + Random.insideUnitCircle * spawnRadius;
            GameObject explosion = ObjectPooler.instance.GetPoolObject("Explosion");
            explosion.transform.position = randomPosition;
            explosion.SetActive(true);
        }
    }
}
