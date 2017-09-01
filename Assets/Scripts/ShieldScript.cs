using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<SpriteRenderer>().color == GetComponent<SpriteRenderer>().color)
            {
                GetComponentInParent<WizardMainScript>().currentStage++;
            }
            collision.gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(collision.transform.position.x - transform.position.x, collision.transform.position.y - transform.position.y).normalized * 7;
        }
    }
}
