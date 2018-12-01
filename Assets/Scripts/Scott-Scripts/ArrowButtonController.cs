using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowButtonController : MonoBehaviour {

    [SerializeField]
    Sprite unpressedSprite, pressedSprite;

    SpriteRenderer arrowButtonRender;
    
    //TODO: Used For prototyping pressable buttons due to not having the necessary assets
    Color defaultColor;

    //Declares Input Variable
    public KeyCode arrowToPress; // <-- **Must be public because it is used by the NoteObject script**

    // Use this for initialization
    void Start()
    {
        //Get Sprite Renderer Component
        arrowButtonRender = GetComponent<SpriteRenderer>();

        //TODO: Set Defaul Color for Prototype Buttons
        defaultColor = arrowButtonRender.color;
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
            //TODO: Commented out for prototyping // strumButtonRender.sprite = pressedSprite;

            arrowButtonRender.material.color = Color.gray;
        }

        if (Input.GetKeyUp(arrowToPress))
        {
            //TODO: Commented out for prototyping // strumButtonRender.sprite = unpressedSprite;

            arrowButtonRender.material.color = defaultColor;
        }
    }
}
