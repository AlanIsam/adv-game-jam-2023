using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] public float speed;

    private Vector2 lastClickedPos;

    private bool moving;

    private bool isClicked;
    
    public Vector3 respawnPoint;

<<<<<<< Updated upstream
    //public Animator myAnim;
=======
    public Animator myAnim;
    public bool facingLeft;
>>>>>>> Stashed changes


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
<<<<<<< Updated upstream
=======
            myAnim.Play("Idle");
              if (transform.position.x > lastClickedPos.x && !facingLeft)
                {
                    Flip();
                }
                else if (transform.position.x < lastClickedPos.x && facingLeft)
                {
                    Flip();
                }
            
>>>>>>> Stashed changes

        }
        else
        {
            moving = false;
           // myAnim.SetBool("Run", false);
        }

    }

    void Flip()
    {
      Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingLeft = !facingLeft;
    }

 

}
