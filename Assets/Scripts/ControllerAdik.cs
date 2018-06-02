using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ControllerAdik : Controller {
    
    private HoleManager hole;
    private bool interact = false;
    private bool frontDoor = false;

    private void Update()
    {
        if (Input.GetKey("e") && !GameVariables.isCrouching && frontDoor)
        {
            transform.position = hole.transform.position;
            GameVariables.isCrouching = true;
            anim.SetBool("IsCrouch", true);
            StartCoroutine(delayCrouchIn());
            Debug.Log("Jongkok");
        }
        if (frontDoor && interact)
        {
            interact = false;
            hole.goesThrough();
            StartCoroutine(delayCrouchOut());
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Kena Collider " + other.collider.tag + " and  " + interact);
        if (other.collider.tag == "Door" )
        {
            hole = other.gameObject.GetComponent<HoleManager>();
            if (hole == null) frontDoor = false;
            frontDoor = true;
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
        GameVariables.isCrouching = false;
    }

}
