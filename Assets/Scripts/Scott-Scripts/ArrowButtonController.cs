using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowButtonController : MonoBehaviour {

    [SerializeField]
    Sprite unpressedSprite, pressedSprite;

    SpriteRenderer arrowButtonRender;

    //Declares Input Variable
    public KeyCode arrowToPress; // <-- **Must be public because it is used by the NoteObject script**

    // Use this for initialization
    void Start()
    {
        //Get Sprite Renderer Component
        arrowButtonRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        InputHandler();
    }

    //Input Handler
    void InputHandler()
    {
        if (Input.GetKeyDown(arrowToPress))
        {
            arrowButtonRender.sprite = pressedSprite;
        }

        if (Input.GetKeyUp(arrowToPress))
        {
            arrowButtonRender.sprite = unpressedSprite;
        }
    }
}
