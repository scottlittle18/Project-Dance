using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour {

    [SerializeField]
    bool canBePressed;
    
    KeyCode arrowToPress;

    ArrowButtonController arrowButtonReceiver;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        InputHandler();
    }

    void InputHandler()
    {
        if (Input.GetKeyDown(arrowToPress) && canBePressed)
        {
            SongManager.instance.NoteHit();

            //Deactivates This GameObject When Player Hits Successfully
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Activator")
        {
            //Gets ArrowButtonController In Order To Find Out What The Correct Button To Press Is
            arrowButtonReceiver = collision.GetComponent<ArrowButtonController>();
            arrowToPress = arrowButtonReceiver.arrowToPress;

            //Allows the Note to be pressed when it is in the target zone
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Activator")
        {
            //Prevents the note from being pressed when out of the target zone
            canBePressed = false;

            SongManager.instance.NoteMissed();
        }
    }
}
