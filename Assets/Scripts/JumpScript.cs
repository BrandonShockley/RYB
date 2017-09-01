using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour {


    public float jumpVelocity;
    public float jumpTime;
    public float slowMotionCoefficient;

    private float jumpTimer;

    private float baseFixedDeltaTime;
    private float baseTimeScale;

    private bool isJumping = false;
    //When other code calls IsJumping, its asking for the state of isJumping
    public bool IsJumping
    {
        get
        {
            return isJumping;
        }
    }

    public bool canJump = false;

    new private Rigidbody2D rigidbody;
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        if (rigidbody == null)
            enabled = false;
        else
        {
            baseFixedDeltaTime = Time.fixedDeltaTime;
            baseTimeScale = Time.timeScale;
        }
	}
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor")
            canJump = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Balloon" || collision.collider.tag == "Floor")
            canJump = true;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Balloon" || collision.collider.tag == "Floor")
            canJump = true;
    }
    

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButton(0) && !isJumping)
        {
            Time.timeScale = baseTimeScale / slowMotionCoefficient;
            Time.fixedDeltaTime = baseFixedDeltaTime / slowMotionCoefficient;
        }
        else
        {
            Time.timeScale = baseTimeScale;
            Time.fixedDeltaTime = baseFixedDeltaTime;
        }
        if (Input.GetMouseButtonUp(0) && canJump)
        {
            Jump();
        }

        jumpTimer -= Time.deltaTime;
        if (isJumping && jumpTimer < 0)
        {
            isJumping = false;
            ResetVelocity();
        }
	}

    private void Jump()
    {
        Vector2 jumpDirectionVector = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position).normalized;
        rigidbody.velocity = jumpDirectionVector * jumpVelocity;
        isJumping = true;
        canJump = false;
        jumpTimer = jumpTime;
    }
    private void ResetVelocity()
    {
        rigidbody.velocity = Vector2.zero;
    }
}
