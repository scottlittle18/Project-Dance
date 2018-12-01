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
    public int scoreCounter, moneyCounter, multiplierTracker;
    public int currentMultiplier;
    public int[] multiplierThresholds;

    [SerializeField]
    Text scoreText, multipierText;

    // Use this for initialization
    void Start () {
        instance = this;
        currentMultiplier = 1;
        SetHUDText();
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

        //Builds up Multiplier with each successful hit
        if(currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        scoreCounter += scorePerNote * currentMultiplier;
        SetHUDText();
    }

    public void NoteMissed()
    {
        //TODO: Debug.Log("Missed Note");
        Debug.Log("Missed Note");

        //Reset Multiplier
        currentMultiplier = 1;
        multiplierTracker = 0;

        //Subtract from player score
        scoreCounter -= penaltyPerMiss;

        //Refresh Score and Multiplier HUD
        SetHUDText();
    }

    void SetHUDText()
    {
        scoreText.text = "Score: " + scoreCounter.ToString();
        multipierText.text = currentMultiplier + "x Multiplier!";
    }
}
