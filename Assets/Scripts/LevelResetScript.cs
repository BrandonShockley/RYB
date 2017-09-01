using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelResetScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.position.y > transform.position.y)
        {
            BalloonManager.instance.ActivateBalloons();
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().color = Color.white;
            if (FindObjectOfType<FlashScript>() != null)
                FindObjectOfType<FlashScript>().Flash(1);
        }
    }
}
