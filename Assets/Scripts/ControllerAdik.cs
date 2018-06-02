using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ControllerAdik : Controller {
    
    private HoleManager hole;
<<<<<<< HEAD
    private Interactable interact;
    private bool crouching = false;
    private bool frontHole = false;
    public float speed = 5f;


    private void Start()
    {
        GameVariables.activePlayer = transform.gameObject;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!GameVariables.isInteract)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        }
    }

    void FixedUpdate () {
        if (Input.GetKey(KeyCode.E) && !GameVariables.isInteract && frontHole)
        {
            transform.position = interact.transform.position;
            GameVariables.isInteract = true;
            anim.SetBool("IsCrouch",true);
=======
    private bool interact = false;
    private bool frontDoor = false;

    private void Update()
    {
        if (Input.GetKey("e") && !GameVariables.isCrouching && frontDoor)
        {
            transform.position = hole.transform.position;
            GameVariables.isCrouching = true;
            anim.SetBool("IsCrouch", true);
>>>>>>> e3d8ea65bf12380ad47feff3bc8cf65610196c21
            StartCoroutine(delayCrouchIn());
            Debug.Log("Jongkok");
        }
        if (frontDoor && interact)
        {
<<<<<<< HEAD
            crouching = false;
            interact.interact();
=======
            interact = false;
            hole.goesThrough();
>>>>>>> e3d8ea65bf12380ad47feff3bc8cf65610196c21
            StartCoroutine(delayCrouchOut());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
<<<<<<< HEAD
        Debug.Log("Kena Collider " + other.tag + " and  " + crouching);
        if (other.tag == "Hole" )
        {
            hole = other.gameObject.GetComponent<HoleManager>();
            if (hole == null) frontHole = false;
            Debug.Log("Collider dengan tag = " + other.tag);
            frontHole = true;
        }
        if (other.tag.Equals("Door"))
        {
            interact = other.gameObject.GetComponent<Interactable>();
            frontHole = true;
=======
        Debug.Log("Kena Collider " + other.collider.tag + " and  " + interact);
        if (other.collider.tag == "Door" )
        {
            hole = other.gameObject.GetComponent<HoleManager>();
            if (hole == null) frontDoor = false;
            frontDoor = true;
>>>>>>> e3d8ea65bf12380ad47feff3bc8cf65610196c21
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Hole")
        {
            frontDoor = false;
        }
    }

    IEnumerator delayCrouchIn()
    {
        yield return new WaitForSeconds(1f);
        interact = true;
        transform.GetComponent<SpriteRenderer>().enabled = false;
    }

    IEnumerator delayCrouchOut()
    {
        transform.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(1f);
        anim.SetBool("IsCrouch", false);
        Debug.Log("Stand");
        yield return new WaitForSeconds(1f);
        GameVariables.isInteract = false;
    }

}
