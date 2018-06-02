using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ControllerAdik : MonoBehaviour {

    private Animator anim;
    private HoleManager hole;
    private bool crouching = false;
    private bool frontHole = false;
    public float speed = 5f;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!GameVariables.isCrouching)
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
        if (Input.GetKey("down") && !GameVariables.isCrouching && frontHole)
        {
            transform.position = hole.transform.position;
            GameVariables.isCrouching = true;
            anim.SetBool("IsCrouch",true);
            StartCoroutine(delayCrouchIn());
            Debug.Log("Jongkok");
        }
        if (frontHole && crouching)
        {
            crouching = false;
            hole.goesThrough();
            StartCoroutine(delayCrouchOut());
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

    IEnumerator delayCrouchIn()
    {
        yield return new WaitForSeconds(1f);
        crouching = true;
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
