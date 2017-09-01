using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimVisualizerScript : MonoBehaviour {

    JumpScript jumpScript;
    LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
        jumpScript = GetComponentInParent<JumpScript>();
        lineRenderer = GetComponent<LineRenderer>();
        if (jumpScript == null)
            enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!jumpScript.IsJumping && Input.GetMouseButton(0))
        {
            lineRenderer.enabled = true;
            Vector2 jumpDirectionVector = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.parent.position).normalized;
            GenerateLinePoints(jumpDirectionVector * jumpScript.jumpVelocity);//Gonna need to tidy this up
        }
        else
            lineRenderer.enabled = false;
	}

    private void GenerateLinePoints(Vector3 velocity)
    {
        Vector3 gravity = Physics.gravity;
        Vector3[] points = new Vector3[lineRenderer.numPositions];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = (velocity * i * .05f)/* + (.5f * gravity * i * i * .05f)*/;
        }
        lineRenderer.SetPositions(points);
    }
}
