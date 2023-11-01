using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour{
    [SerializeField] private GameObject[] levelParts;
    [SerializeField] private  float minDistance;
    [SerializeField] private Transform finalPoint;
    [SerializeField] private int initialAmount;
    private Transform player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < initialAmount; i++) {
            GeneratePartLevel();
        }
    }

    private void Update() {
        if (Vector2.Distance(player.position, finalPoint.position) < minDistance) {
            //Generar Nivel
            GeneratePartLevel();
        }
    }

    private void GeneratePartLevel() {
        int randomNumber = Random.Range(0, levelParts.Length);
        GameObject level = Instantiate(levelParts[randomNumber], finalPoint.position, Quaternion.identity);
        //Punto final
        finalPoint = SearchEndPoint(level, "FinalPoint");
    }

    private Transform SearchEndPoint(GameObject levelPart, string tag) {
        Transform point = null;

        foreach (Transform location in levelPart.transform) {
            if(location.CompareTag(tag)){
                point = location;
                break;
            }
        }
        return point;
    }
}
