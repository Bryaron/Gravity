using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fade : MonoBehaviour {

    [Header("Information")]
    public float fadeTime = 1;
    [SerializeField] SpriteRenderer spriteRenderer;

    private void Start() {
        FadeOut();
    }

    [ContextMenu("FadeIn")]
    public void FadeIn() {
        spriteRenderer.DOFade(1, fadeTime).OnComplete(()=> {
            Debug.Log("Mostrar pantalla de derrota");
        });
    }
    
    [ContextMenu("FadeOut")]
    public void FadeOut() {
        spriteRenderer.DOFade(0, fadeTime).OnComplete(()=> StartGame()).OnStart(()=> {
            Debug.Log("Inicializando el juego");
        });
    }

    private void StartGame() {
        Debug.Log("Empezo el juego");
    }
}
