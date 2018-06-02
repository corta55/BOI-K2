using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ControllerAdik : Controller {
    
    private Interactable interact;
    private bool interacts = false;
    private bool frontDoor = false;


    private void Start()
    {
        GameVariables.activePlayer = transform.gameObject;
        anim = GetComponent<Animator>();
    }   

    private void Update()
    {

        if (Input.GetKey("e") && !GameVariables.isInteract && frontDoor)
        {
            transform.position = interact.transform.position;
            GameVariables.isInteract = true;
            anim.SetBool("IsCrouch", true);
            Debug.Log("Jongkok");
            interact.interact();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Kena Collider " + other.tag + " and  " + GameVariables.isInteract);
        if (other.tag.Equals("Door"))
        {
            interact = other.gameObject.GetComponent<Interactable>();
            frontDoor = true;
            Debug.Log("Kena Collider " + other.tag + " and  " + GameVariables.isInteract);
        }
    }

    private void OnTriggerExit2D(Collision2D other)
    {
        if (other.collider.tag == "Hole")
        {
            frontDoor = false;
        }
    }

}
