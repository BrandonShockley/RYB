using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationControlScript : MonoBehaviour {

    private Rigidbody2D rigidBody2D;
    private Animator animator;

	// Use this for initialization
	void Start () {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float direction = Mathf.Atan2(rigidBody2D.velocity.y, rigidBody2D.velocity.x) * Mathf.Rad2Deg;
        if (Mathf.Approximately(rigidBody2D.velocity.magnitude, 0))
            animator.CrossFade("Idle", 0);
        else if (direction > 45 && direction < 135)
            animator.CrossFade("Up", 0);
        else if (direction > 135 || direction < -135)
            animator.CrossFade("Left", 0);
        else if (direction > -135 && direction < -45)
            animator.CrossFade("Down", 0);
        else if (direction < 45 && direction > -45)
            animator.CrossFade("Right", 0);
	}
}
