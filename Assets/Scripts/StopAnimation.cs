using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnimation : MonoBehaviour{

    [Header("Information")]
    public Animator animator;
    private void Start() {
        animator = GetComponent<Animator>();
        Invoke("StopAnim", 5f);
    }

    private void StopAnim() {
        animator.enabled = false;
    }

    
}
