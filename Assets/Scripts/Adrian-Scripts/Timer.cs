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

    public void StartTimer()
    {

        IsRunning = true;
    }

    public void StopTimer()
    {

        IsRunning = false;
    }

    public void ResetTimer()
    {

        EndTime = 0;
        CurrentTime = 0;

    }

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
            if (CurrentTime >= EndTime)
            {

                IsRunning = false;

            }

        }

	}

}
