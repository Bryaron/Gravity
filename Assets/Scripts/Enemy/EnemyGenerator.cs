using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

    [Header("Information")]
    [SerializeField] private float minX, maxX, minY, maxY;

    [Header("Configuration")]
    [Tooltip("Rango en el cual se generan enemigos"+" Si esta vacio se usara el punto de este GameObject")]
    [SerializeField] private Transform[] points;
    [SerializeField] private GameObject[] enemys;
    [SerializeField] private  float enemyTime;
    
    
    private float Timer;

    private void Start() {
        //Por Defecto
        if (points == null || points.Length == 0) {
            //Transform como unico punto inicial
            points = new Transform[1];
            points[0] = transform;
        }

        maxX = points.Max(point => point.position.x);
        minX = points.Min(point => point.position.x);
        maxY = points.Max(point => point.position.y);
        minY = points.Min(point => point.position.y);
    }

    private void Update() {
        Timer += Time.deltaTime;

        if (Timer >= enemyTime) {
            Timer = 0;
            MakeEnemy();
        }
    }

    private void MakeEnemy() {
        //Para una futura funcion de seleccionar enemigo en especifico 
        int numeroEnemigo = Random.Range(0, enemys.Length);

        Vector2 posicionAleatoria = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        //Trayendo un GameObject aleatorio con el mismo tag
        GameObject enemy2 = ObjectPooler.instance.GetRandomPoolObjec("Enemy");
        enemy2.transform.position = posicionAleatoria;
        enemy2.SetActive(true);
    }

}
