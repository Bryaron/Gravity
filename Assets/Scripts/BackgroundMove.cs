using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour {

    [Header("Configuration")]
    [SerializeField] private Vector2 SpeedMove;
    private Vector2 offset;
    private Material material;
    private Rigidbody2D playerRB;

    private void Awake() {
        material = GetComponent<SpriteRenderer>().material;
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void Update() {
        offset = new Vector2((playerRB.velocity.x * 0.1f),(playerRB.velocity.y * 0.1f)) * SpeedMove * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
