using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongManager : MonoBehaviour {

    [SerializeField]
    AudioSource lvlMusic;

    [SerializeField]
    bool startPlaying;

    [SerializeField]
    int scorePerNote, penaltyPerMiss;

    [SerializeField]
    NoteScroller noteScroller;

    //Singleton Code Declaration
    public static SongManager instance;

    [HideInInspector]
    public int scoreCounter, moneyCounter;

    [SerializeField]
    Text scoreText;

    // Use this for initialization
    void Start ()
    {
        instance = this;
        SetScoreText();
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

    public void NoteHit()
    {
        //TODO: Debug.Log("Hit On Time");
        Debug.Log("Hit On Time");

        scoreCounter += scorePerNote;
        SetScoreText();
    }

    public void NoteMissed()
    {
        //TODO: Debug.Log("Missed Note");
        Debug.Log("Missed Note");

        scoreCounter -= penaltyPerMiss;
        SetScoreText();
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + scoreCounter.ToString();
    }
}
