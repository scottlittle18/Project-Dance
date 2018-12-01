using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScroller : MonoBehaviour {

    [SerializeField]
    float beatTempo;

    //To check if game has started
    [HideInInspector]
    public bool hasStarted;

	// Use this for initialization
	void Start () {

        // Decides how fast the notes should move per second based on BPM
        beatTempo = beatTempo / 60f;
	}
	
	// Update is called once per frame
	void Update () {

        if (!hasStarted)
        {  
            /*Press Any Key To Get The Notes To Start Scrolling If The Game Hasn't Started
            if (Input.anyKeyDown)
            {
                //Starts Scrolling
                hasStarted = true;
            }   */
        }
        else
        {
            //Controls the direction & speed of the notes
            transform.position += new Vector3(0f, beatTempo * Time.deltaTime, 0f); //Current Direction: Straight Up
        }
	}
}
