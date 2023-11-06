using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static event Action OnPlayerDeath;
    public static event Action OnPlayerHit;
    public GameObject GameOverScreen;

    private void OnEnable() {
        OnPlayerDeath += ShowGameOverScreen;
    }

    private void OnDisable() {
        OnPlayerDeath -= ShowGameOverScreen;
    }

    private void Awake() {
        GameOverScreen.SetActive(false);
    }

    public void PlayerKilled() {
        OnPlayerDeath?.Invoke();
    }

    private void ShowGameOverScreen() {
        //Muestra GameOverScreen
        GameOverScreen.SetActive(true);
    }

    public void PlayerHitted() {
        OnPlayerHit?.Invoke();
    }
}
