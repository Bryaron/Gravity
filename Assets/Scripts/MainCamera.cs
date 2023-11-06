using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class MainCamera : MonoBehaviour {

    [Header("Information")]
    [SerializeField] private Transform player;
    [SerializeField] private float distance = 3f;

    private void OnEnable() {
        GameManager.OnPlayerHit += MoveCameraUp;
    }

    private void OnDisable() {
        GameManager.OnPlayerHit -= MoveCameraUp;
    }

    private void Update() {
        FollowPlayer2D();
    }

    private void FollowPlayer2D() {
        var playerPosition = player.position;
        playerPosition.x = transform.position.x;
        playerPosition.z = transform.position.z;

        //transform.position = playerPosition;
        transform.position = new Vector3(transform.position.x, playerPosition.y + distance, transform.position.z);
    }
    private void MoveCameraUp() {
        StartCoroutine(Lerp(distance, distance + 0.5f, 2f));
    }

    IEnumerator Lerp(float start, float target, float lerpDuration){
        float timeElapsed = 0f;

        while (timeElapsed < lerpDuration ) {
            distance = Mathf.Lerp(start, target, timeElapsed / lerpDuration);
            Debug.Log(distance);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

}
