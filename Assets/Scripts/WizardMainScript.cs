using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardMainScript : MonoBehaviour {

    public int currentStage;
    public Material materialToChange;

	// Use this for initialization
	void Start () {
        ApplyGradient(40);
	}
	
	// Update is called once per frame
	void Update () {
		switch (currentStage)
        {
            case 1:
                transform.FindChild("Shield").GetComponent<SpriteRenderer>().color = ColorManager.instance.PURPLE;
                break;
            case 2:
                transform.FindChild("Shield").GetComponent<SpriteRenderer>().color = ColorManager.instance.ORANGE;
                break;
            case 3:
                transform.FindChild("Shield").GetComponent<SpriteRenderer>().color = ColorManager.instance.GREEN;
                break;
        }
        if (currentStage == 4)
        {
            GameObject.Find("You").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("Win").GetComponent<SpriteRenderer>().enabled = true;
            MusicManager.instance.PlaySound(MusicManager.instance.victory, true);
            FlashScreen(5);
            ApplyGradient(40);
            CameraManager.instance.CameraPositionIndex++;
            Time.timeScale /=  30;
            Time.fixedDeltaTime /= 30;
            currentStage++;
        }
	}
    public void ApplyGradient(int bottom)
    {
        
        //materialToChange.SetInt("Bottom", bottom);
        SpriteRenderer[] tempList = FindObjectsOfType<SpriteRenderer>();
        GameObject.Find("PaintedSky").GetComponent<SpriteRenderer>().sharedMaterial.SetInt("_Bottom", bottom);
        foreach (SpriteRenderer i in tempList)
        {
            //if (i.material == materialToChange)
            {
                i.sharedMaterial.SetInt("_Bottom", bottom);
            }
        }
    }
    public void FlashScreen(float time)
    {
        if (FindObjectOfType<FlashScript>() != null)
            FindObjectOfType<FlashScript>().Flash(time);
    }
    public void ShowMouse()
    {
        GameObject.Find("Mouse").GetComponent<SpriteRenderer>().enabled = true;
    }
    
}
