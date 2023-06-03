using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] public float speed;

    private Vector2 lastClickedPos;

    private bool moving;

    private bool isClicked;
    
    public Vector3 respawnPoint;

    public Animator myAnim;


    private void Update()
    {
        PointMovement();
    }

    private void PointMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //CreateDust();
            lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
           // myAnim.SetBool("Run", true);
        }

        if (moving && (Vector2)transform.position != lastClickedPos)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);
            myAnim.Play("Idle");
        }
        else
        {
            moving = false;
           // myAnim.SetBool("Run", false);
           myAnim.Play("Run");
        }

    }
    
    }
