using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardMoveScript : MonoBehaviour {

    public float speed;

    public Vector2 position1;
    public Vector2 position2;
    private Vector2 targetPosition;

    private Rigidbody2D rigidBody;

    void Start()
    {
        targetPosition = position2;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 currentToTargetVector = targetPosition - (Vector2)transform.position;
        if (currentToTargetVector.magnitude < .1)
        {
            if (targetPosition.Equals(position1))
                targetPosition = position2;
            else
                targetPosition = position1;
        }
        rigidBody.velocity = currentToTargetVector.normalized * speed;
    }
}
