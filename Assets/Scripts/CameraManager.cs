using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    //Chaching an instance to the manager
    private static CameraManager s_Instance = null;
    public static CameraManager instance
    {
        get
        {
            if (s_Instance == null)
            {
                s_Instance = FindObjectOfType<CameraManager>();
            }
            //If still null, create a new instance
            if (s_Instance == null)
            {
                GameObject obj = new GameObject("CameraManager");
                s_Instance = obj.AddComponent<CameraManager>();
                Debug.Log("Could not locate a CameraManager instance. A new one was generated automatically.");
            }
            return s_Instance;
        }
    }

    public delegate void CameraPositionIndexChangeAction(int index);
    public event CameraPositionIndexChangeAction OnCameraPositionIndexChange;

    public Vector2[] cameraPositions;
    private int cameraPositionIndex;
    public int CameraPositionIndex
    {
        get
        {
            return cameraPositionIndex;
        }
        set
        {
            previousCameraPositionIndex = cameraPositionIndex;
            cameraPositionIndex = value;
            OnCameraPositionIndexChange(cameraPositionIndex);
        }
    }

    private float timeOfChange;
    private int previousCameraPositionIndex;

    // Use this for initialization
    void Start () {
        OnCameraPositionIndexChange += OnLevelChange;
        Camera.main.transform.position = new Vector3(cameraPositions[cameraPositionIndex].x, cameraPositions[cameraPositionIndex].y,
                                                        Camera.main.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        float deltaTime = Time.time - timeOfChange;
        if (deltaTime < 1)
            Camera.main.transform.position = new Vector3(Mathf.Lerp(cameraPositions[previousCameraPositionIndex].x,
                                                                    cameraPositions[cameraPositionIndex].x, deltaTime),
                                                         Mathf.Lerp(cameraPositions[previousCameraPositionIndex].y,
                                                                    cameraPositions[cameraPositionIndex].y, deltaTime),
                                                         Camera.main.transform.position.z);
	}

    void OnLevelChange(int index)
    {
        timeOfChange = Time.time;
    }

}
