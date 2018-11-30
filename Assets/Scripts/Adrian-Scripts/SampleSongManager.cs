using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleSongManager : MonoBehaviour
{

    //
    [SerializeField]
    bool Playing;

    // Delay before the song is played
    [SerializeField]
    float PlayDelay;

    // Referenec to a timer
    [SerializeField]
    Timer SongTimer;

    [SerializeField]
    int CurrentNoteIndex;

    [SerializeField]
    List<float> NoteTimes;

    // You can refactor this into somewhere else
    [SerializeField]
    List<GameObject> ArrowsToSpawn;

    //
    [SerializeField]
    AudioClip SongToPlay;

    //
    [SerializeField]
    AudioSource SongPlayer;


	// Use this for initialization
	void Start ()
    {

        // Ensures Timer gameobject exists in the scene
        if (GameObject.Find("Timer") == null)
        {

            GameObject Timer = new GameObject("Timer");
            Timer.AddComponent<Timer>();
            SongTimer = Timer.GetComponent<Timer>();

        }
        else
        {

            SongTimer = GameObject.Find("Timer").GetComponent<Timer>();

        }

        // Audio Player
        SongPlayer = this.GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update ()
    {

        if (!SongPlayer.isPlaying && Playing)
        {

            SongPlayer.PlayDelayed(PlayDelay);

        }
        
        if (NoteTimes[CurrentNoteIndex] >= SongTimer.GetCurrentTime())
        {

            /*
             
            
                SPAWN NOTE OR DO SOMETHING HERE


             */         
            CurrentNoteIndex++;

        }

    }

    public void StartPlaying()
    {

        Playing = true;
        CurrentNoteIndex = 0;
        SongTimer.ResetTimer(SongToPlay.length + PlayDelay);
        SongTimer.StartTimer();

    }

    public void StopPlaying()
    {

        Playing = false;
        CurrentNoteIndex = 0;
        SongTimer.StopTimer();
        SongTimer.ResetTimer();

    }

    public void NewSong(AudioClip NewSongToPlay)
    {

        SongToPlay = NewSongToPlay;

    }

}
