﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour
{

    public bool grabbed;
    RaycastHit2D hit;
    public float distance = 2f;
    public Transform holdpoint;
    public Transform zoneGrab;
    public float throwforce;
    public LayerMask notgrabbed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (!grabbed)
            {
                //Grab
                Physics2D.queriesStartInColliders = false;
                hit = Physics2D.Raycast(zoneGrab.position, Vector2.right * transform.localScale.x, distance);

                if (hit.collider != null && hit.collider.tag == "Grabbable")
                {
                    grabbed = true;
                }
            }
            else if (!Physics2D.OverlapPoint(holdpoint.position, notgrabbed))
            {
                //Throw
                grabbed = false;
                if (hit.collider.gameObject.GetComponent<BoxCollider2D>() != null)
                {
                    hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                }
                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwforce;
                }
            }
        }

        if (grabbed)
        {
            hit.collider.gameObject.transform.position = holdpoint.position;
            if (hit.collider.gameObject.GetComponent<BoxCollider2D>() != null)
            {
                hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
    }
}
