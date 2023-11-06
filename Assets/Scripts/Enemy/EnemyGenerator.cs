using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;

public class EnemyGenerator : MonoBehaviour {

    [Header("Information")]
    [SerializeField] private float minX, maxX, minY, maxY;

    [Header("Configuration")]
    [Tooltip("Rango en el cual se generan enemigos"+" Si esta vacio se usara el punto de este GameObject")]
    [SerializeField] public Transform[] points;
    [SerializeField] private GameObject[] enemys;
    [SerializeField] private  float enemyTime;
    [SerializeField] private Transform player;
    
    
    private float Timer;
    private float distance;   
    private void Start() {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        distance = transform.position.y - player.position.y;

        //Por Defecto
        if (points == null || points.Length == 0) {
            //Transform como unico punto inicial
            points = new Transform[1];
            points[0] = transform;
        }
    }

    private void Update() {

        FollowPlayer();
        CalculatePoints();
        Timer += Time.deltaTime;
        if (Timer >= enemyTime) {
            Timer = 0;
            MakeEnemy();
        }
    }

    private void FollowPlayer(){
        transform.position = new Vector3(0, player.position.y + distance ,0); 
    }

    private void CalculatePoints() {
        maxX = points.Max(point => point.position.x);
        minX = points.Min(point => point.position.x);
        maxY = points.Max(point => point.position.y);
        minY = points.Min(point => point.position.y);
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


    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        foreach (var point in points) {
            Gizmos.DrawSphere(point.position, 0.1f);
        }
    }
}

[CustomEditor(typeof(EnemyGenerator))]
    public class EnemyCustomEditor : Editor {
        public void OnSceneGUI() {
            var enemyObj = (EnemyGenerator)target;
            for (int i = 0; i < enemyObj.points.Count(); i++) {
                var point = enemyObj.points[i];
                var nextPoint = enemyObj.points[(i + 1) % enemyObj.points.Count()];

                if (point == null) continue;
                if (nextPoint == null) continue;

                Handles.color = Color.white;
                Handles.DrawDottedLine(point.position, nextPoint.position, 5f);

                EditorGUI.BeginChangeCheck();
                var newPos = Handles.PositionHandle(point.position, point.rotation);
                if(EditorGUI.EndChangeCheck()) {
                    Undo.RecordObject(point, "Move Point");
                    point.position = newPos;
                }

                point.position = newPos;
            }
        }
    }
