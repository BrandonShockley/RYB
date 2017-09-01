using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScript : MonoBehaviour {
    public bool isActive = true;
	// Use this for initialization
	void Start () {

	}
    private void OnEnable()
    {
        isActive = true;
    }

    // Update is called once per frame
    void Update () {
        if (!isActive && GetComponent<Rigidbody2D>() != null)
            Destroy(gameObject);
        else if (!isActive && transform.parent != null && transform.parent.name == "RotatorWheel")  
            Destroy(gameObject);
        else if (!isActive)
        {
            BalloonManager.instance.AddInactiveBalloon(gameObject);
            gameObject.SetActive(false);
        }

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Color color = GetComponent<SpriteRenderer>().color;
            collision.GetComponent<SpriteRenderer>().color = ColorManager.instance.CombineColors(collision.GetComponent<SpriteRenderer>().color, color);
            collision.gameObject.GetComponent<JumpScript>().canJump = true;
            isActive = false;
            MusicManager.instance.PlaySound(MusicManager.instance.bubblePop, false);
        }
    }
    
}
