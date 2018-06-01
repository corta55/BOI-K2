using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Crouch : MonoBehaviour {

    private Animator anim;
    private HoleManager hole;
    private bool crouching = false;
    private bool frontHole = false;
    public float speed = 5f;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate () {
        if (Input.GetKey("down"))
        {
            anim.SetBool("IsCrouch",true);
            crouching = true;
            Debug.Log("Jongkok");
        }
        else
        {
            anim.SetBool("IsCrouch", false);
            crouching = false;
            Debug.Log("Stand");
        }
        if (frontHole && crouching == true)
        {
            hole.goesThrough();
        }
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Kena Collider " + other.collider.tag + " and  " + crouching);
        if (other.collider.tag == "Hole" )
        {
            hole = other.gameObject.GetComponent<HoleManager>();
            if (hole == null) frontHole = false;
            Debug.Log("Collider dengan tag = " + other.collider.tag);
            frontHole = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Hole")
        {
            frontHole = false;
        }
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    Debug.Log("Kena Collider");
    //    if (other.tag == "Hole" && crouching == true)
    //    {
    //        Debug.Log("Collider dengan tag = " + other.tag);
    //        hole.goesThrough();
    //    }
    //}

}
