using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    [SerializeField]
    bool IsRunning;

    [SerializeField]
    float EndTime;

    [SerializeField]
    float CurrentTime;


	// Use this for initialization
	void Start ()
    {

        IsRunning = false;

	}

    // Call to start the timer
    public void StartTimer()
    {

        IsRunning = true;
    }

    // Call to stop and end the timer
    public void StopTimer()
    {

        IsRunning = false;
    }

    // Resets timer 
    public void ResetTimer()
    {

        EndTime = 0;
        CurrentTime = 0;

    }

    // Resets timer with set endtime
    public void ResetTimer(float NewEndTime)
    {

        EndTime = NewEndTime;
        CurrentTime = 0;

    }


    void FixedUpdate()
    {
		
        if (IsRunning)
        {

            CurrentTime += Time.fixedDeltaTime;

            // End timer if CurrentTime has reached EndTime
            if (CurrentTime >= EndTime)
            {

                StopTimer();

            }

        }

	}

}
