using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashScript : MonoBehaviour {

    private float flashDuration;
    private float elapsedTime;

	// Use this for initialization
	void Start () {
        flashDuration = 0;
        elapsedTime = flashDuration;
	}
	
	// Update is called once per frame
	void Update () {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (elapsedTime < flashDuration)
        {
            elapsedTime += Time.deltaTime;
            Color color = spriteRenderer.color;
            color.a = Mathf.Cos(elapsedTime / flashDuration * Mathf.PI);
            spriteRenderer.color = color;
        }
        else if (spriteRenderer.color.a != 0)
        {
            Color color = spriteRenderer.color;
            color.a = 0;
            spriteRenderer.color = color;
        }
	}

    public void Flash(float duration)
    {
        flashDuration = duration;
        elapsedTime = 0;
    }
}
