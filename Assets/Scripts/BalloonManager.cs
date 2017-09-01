using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonManager : MonoBehaviour {
    //Chaching an instance to the manager
    private static BalloonManager s_Instance = null;
    public static BalloonManager instance
    {
        get
        {
            if (s_Instance == null)
            {
                s_Instance = FindObjectOfType<BalloonManager>();
            }
            //If still null, create a new instance
            if (s_Instance == null)
            {
                GameObject obj = new GameObject("BalloonManager");
                s_Instance = obj.AddComponent<BalloonManager>();
                Debug.Log("Could not locate a BalloonManager instance. A new one was generated automatically.");
            }
            return s_Instance;
        }
    }

    private List<GameObject> inactiveBalloons;
    private void Start()
    {
        inactiveBalloons = new List<GameObject>();
    }

    public void AddInactiveBalloon(GameObject balloon)
    {
        inactiveBalloons.Add(balloon);
    }
    public void ActivateBalloons()
    {
        foreach (GameObject i in inactiveBalloons)
            i.SetActive(true);
        inactiveBalloons = new List<GameObject>();
    }
}
