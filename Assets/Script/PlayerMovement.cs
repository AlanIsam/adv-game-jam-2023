using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] public float speed;

    private Vector2 lastClickedPos;

    private bool moving;

    private bool isClicked;

    public Vector3 respawnPoint;

    public Animator myAnim;

    public bool isFacingLeft;

    public AudioSource walkingSFX;







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

        if (moving && (Vector2)transform.position != lastClickedPos && Time.timeScale == 1)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);
            myAnim.Play("Idle");

            if (transform.position.x > lastClickedPos.x && !isFacingLeft)
            {
                Flip();
            }
            else if (transform.position.x < lastClickedPos.x && isFacingLeft)
            {
                Flip();
            }
        }
        else
        {
            moving = false;
            // myAnim.SetBool("Run", false);
            myAnim.Play("Run");
        }

        if (moving)
        {
            if (!walkingSFX.isPlaying)
                walkingSFX.Play();
        }
        else
        {
            walkingSFX.Stop();
        }





    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        isFacingLeft = !isFacingLeft;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            moving = false;
        }
        




    }

}



