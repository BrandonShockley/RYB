using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBombScript : MonoBehaviour {

    public float rainRange;
    public float rainHeight;
    public float rainCooldown;

    public int circleBalloonNumber;
    public int circleRadius;

    public Transform redBalloon;
    public Transform blueBalloon;
    public Transform yellowBalloon;

    public float cooldown;
    private float cooldownTimeRemaining;

    private List<GameObject> balloonCircle;

    private void Start()
    {
        transform.FindChild("RotatorWheel").GetComponent<Rigidbody2D>().angularVelocity = 50;
    }
    private void Update()
    {
        if (FindObjectOfType<WizardMainScript>().currentStage == 1 || FindObjectOfType<WizardMainScript>().currentStage == 2)
        {
                if (balloonCircle == null)
                balloonCircle = new List<GameObject>();
            List<GameObject> removal = new List<GameObject>();
            foreach (GameObject i in balloonCircle)
                if (i == null)
                    removal.Add(i);
            foreach (GameObject i in removal)
                balloonCircle.Remove(i);
            cooldownTimeRemaining -= Time.deltaTime;
            if (balloonCircle.Count < circleBalloonNumber && cooldownTimeRemaining < 0)
            {
                cooldownTimeRemaining = cooldown;
                int rand = Random.Range(1, 4);
                GameObject balloon;
                Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + circleRadius, 0);
                switch (rand)
                {
                    case 1:
                        balloon = Instantiate<Transform>(redBalloon, transform.FindChild("RotatorWheel")).gameObject;
                        balloon.transform.position = spawnPosition;
                        balloonCircle.Add(balloon);
                        break;
                    case 2:
                        balloon = Instantiate<Transform>(blueBalloon, transform.FindChild("RotatorWheel")).gameObject;
                        balloon.transform.position = spawnPosition;
                        balloonCircle.Add(balloon);
                        break;
                    case 3:
                        balloon = Instantiate<Transform>(yellowBalloon, transform.FindChild("RotatorWheel")).gameObject;
                        balloon.transform.position = spawnPosition;
                        balloonCircle.Add(balloon);
                        break;
                }
            }
        }
        else if (FindObjectOfType<WizardMainScript>().currentStage == 3)
        {
            transform.FindChild("RotatorWheel").gameObject.SetActive(false);
            cooldownTimeRemaining -= Time.deltaTime;
            if (cooldownTimeRemaining < 0)
            {
                int rand = Random.Range(1, 4);
                GameObject balloon;
                float randomDropX = Random.Range(transform.position.x - rainRange / 2, transform.position.x + rainRange / 2);
                switch (rand)
                {
                    case 1:
                        balloon = Instantiate<Transform>(redBalloon, new Vector3(randomDropX, transform.position.y + rainHeight, transform.position.z), new Quaternion()).gameObject;
                        break;
                    case 2:
                        balloon = Instantiate<Transform>(blueBalloon, new Vector3(randomDropX, transform.position.y + rainHeight, transform.position.z), new Quaternion()).gameObject;
                        balloonCircle.Add(balloon);
                        break;
                    default:
                        balloon = Instantiate<Transform>(yellowBalloon, new Vector3(randomDropX, transform.position.y + rainHeight, transform.position.z), new Quaternion()).gameObject;
                        break;
                }
                balloon.gameObject.AddComponent<Rigidbody2D>();
                cooldownTimeRemaining = rainCooldown;
                
            }
        }
    }
}
