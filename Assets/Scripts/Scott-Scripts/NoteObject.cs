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
            //Destroys This GameObject When Player Hits Successfully
            Destroy(gameObject);
        }

        if((Input.inputString != Input.GetKeyDown(arrowToPress).ToString()) && canBePressed)
        {
            //TODO: Condition - User Hit Wrong Button
        }

        if (Input.GetKeyDown(arrowToPress) && !canBePressed)
        {
            //TODO: Condition - User Hit Button While An Arrow Was Not Inside A Trigger Zone
        }

        if ((Input.inputString != Input.GetKeyDown(arrowToPress).ToString()) && !canBePressed)
        {
            //TODO: Condition - User Hit Wrong Button While An Arrow Was Not Inside A Trigger Zone
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
        }
    }
}
