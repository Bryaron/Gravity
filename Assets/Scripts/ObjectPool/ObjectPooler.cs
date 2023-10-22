using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem {
    public GameObject objectToPool;
    public int amountToPool;
}

public class ObjectPooler : MonoBehaviour {

    [Header("Information")]
    public static ObjectPooler instance;
    public List<ObjectPoolItem> itemsToPool;
    public List<GameObject> instancedObjects;
    public List<GameObject> instancedObjectsWithTag;
    
    private void Awake() {
        instance = this;
    }

    private void Start() {
        instancedObjects = new List<GameObject>();
        instancedObjectsWithTag = new List<GameObject>();

        foreach (ObjectPoolItem item in itemsToPool) {
            for (int i = 0; i < item.amountToPool; i++) {
                GameObject go = Instantiate(item.objectToPool);
                go.SetActive(false);
                instancedObjects.Add(go);
            }
        }
    }

    public GameObject GetPoolObject(string tag) {

        for (int i = 0; i < instancedObjects.Count; i++) {
            if (!instancedObjects[i].activeInHierarchy && instancedObjects[i].CompareTag(tag)) {
                return instancedObjects[i];
            }
        }

        foreach (ObjectPoolItem item in itemsToPool) {
            if(item.objectToPool.CompareTag(tag)) {
                GameObject go = Instantiate(item.objectToPool);
                go.SetActive(false);
                instancedObjects.Add(go);
                return go;
            }
        }
        return null;
    }

    /* Devuelve on GameObject aleatorio con el tag que quieras del pool de objetos  */
    /* Se crea bastantes GameObjects si es que no se destruyec(disable) los enemigos */
    public GameObject GetRandomPoolObjec(string tag) {

        //Añadiendo distintos objetos instanciados que tengan el mismo tag
        //Solo la primera vez

        if(instancedObjectsWithTag.Count == 0) {
            foreach (GameObject item in instancedObjects) {
                if (item.CompareTag(tag)) {
                    instancedObjectsWithTag.Add(item);
                }
            }
        }        
        
        int randomNumber = Random.Range(0, instancedObjectsWithTag.Count);
        
        if (!instancedObjectsWithTag[randomNumber].activeInHierarchy && instancedObjectsWithTag[randomNumber].CompareTag(tag)) {
            return instancedObjectsWithTag[randomNumber];
        }

        if(instancedObjectsWithTag[randomNumber].CompareTag(tag)) {
            GameObject go = Instantiate(instancedObjectsWithTag[randomNumber]);
            go.SetActive(false);
            instancedObjectsWithTag.Add(go);
            return go;
        }
        return null;
    }
}
