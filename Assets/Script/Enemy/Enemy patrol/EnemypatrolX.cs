using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemypatrolX : MonoBehaviour
{
    [SerializeField] float speed = 0.8f;
    [SerializeField] float range = 3;

    private float startingX;
    int dir = 1;

    void Start()
    {
        startingX= transform.position.x;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime *dir);
        if (transform.position.x < startingX || transform.position.x > startingX + range)
        {
            dir *= -1;
          //rotate the enemy when it changes direction
            transform.Rotate(0f, 0f, 90f);
            
              

        }
    }
}
