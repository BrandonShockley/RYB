using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    public AudioClip mainMusic;
    public AudioClip bossMusic;
    public AudioClip wind;
    public AudioClip bubblePop;
    public AudioClip victory;
    //Chaching an instance to the manager
    private static MusicManager s_Instance = null;
    public static MusicManager instance
    {
        get
        {
            if (s_Instance == null)
            {
                s_Instance = FindObjectOfType<MusicManager>();
            }
            //If still null, create a new instance
            if (s_Instance == null)
            {
                GameObject obj = new GameObject("MusicManager");
                s_Instance = obj.AddComponent<MusicManager>();
                Debug.Log("Could not locate a MusicManager instance. A new one was generated automatically.");
            }
            return s_Instance;
        }
    }
    // Use this for initialization
    void Start () {
        PlaySound(wind, true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PlaySound(AudioClip audioClip, bool loop)
    {
        //GetComponent<AudioSource>().loop = loop;
        if (loop)
        {
            GetComponent<AudioSource>().clip = audioClip;
            GetComponent<AudioSource>().Play();

        }
        GetComponent<AudioSource>().PlayOneShot(audioClip);
    }

    public void StartMusic()
    {
        PlaySound(mainMusic, true);
        //FindObjectOfType<QuickCutsceneController>().EndCutscene();
    }
}
