using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelEndScript : MonoBehaviour {

    public bool isBossThing;
	// Use this for initialization
	void Start () {
        //CameraManager.instance.CameraPositionIndex++;
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && collider.GetComponent<SpriteRenderer>().color == transform.parent.GetComponent<SpriteRenderer>().color)
        {
            Vector3 playerPosition = collider.transform.position;
            CameraManager.instance.CameraPositionIndex++;
            collider.transform.position = new Vector3(playerPosition.x, this.transform.parent.transform.position.y + 1f, playerPosition.z);
            collider.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            if (isBossThing)
            {
                GameObject.Find("EvilWizard").GetComponent<WizardBombScript>().enabled = true;
                MusicManager.instance.PlaySound(MusicManager.instance.bossMusic, true);
            }
            //Physics2D.IgnoreCollision(transform.parent.GetComponent<BoxCollider2D>(), collider, true);
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player" && collider.GetComponent<SpriteRenderer>().color == transform.parent.GetComponent<SpriteRenderer>().color)
            Physics2D.IgnoreCollision(transform.parent.GetComponent<BoxCollider2D>(), collider, false);
    }

}
