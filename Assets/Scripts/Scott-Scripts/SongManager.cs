using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour {

    [SerializeField]
    AudioSource lvlMusic;

    [SerializeField]
    bool startPlaying;

    [SerializeField]
    NoteScroller noteScroller;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                noteScroller.hasStarted = true;

                lvlMusic.Play();
            }
        }
	}
}
