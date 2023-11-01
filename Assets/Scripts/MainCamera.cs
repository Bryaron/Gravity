using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    [Header("Information")]
    [SerializeField] private Transform player;

    private void Update() {
        FollowPlayer2D();
    }

    private void FollowPlayer2D() {
        var playerPosition = player.position;
        playerPosition.x = transform.position.x;
        playerPosition.z = transform.position.z;

        transform.position = playerPosition;

        //transform.position = new Vector3(transform.position.x, playerPosition.y + 3f, transform.position.z);
    }
}
