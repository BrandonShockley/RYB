using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseShowThing : MonoBehaviour {
    private float timer;
    public float showTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<SpriteRenderer>().enabled == true)
        {
            timer += Time.deltaTime;
        }
        if (timer > showTime)
        {
            ToggleExistance();
            timer = 0;
        }
	}
    public void ToggleExistance()
    {
        if (GetComponent<SpriteRenderer>().enabled == true)
            GetComponent<SpriteRenderer>().enabled = false;
        else
            GetComponent<SpriteRenderer>().enabled = false;
    }
}
