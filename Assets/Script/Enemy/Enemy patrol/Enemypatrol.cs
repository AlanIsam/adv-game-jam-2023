using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemypatrol : MonoBehaviour
{
    [SerializeField] float speed = 0.8f;
    [SerializeField] float range = 3;
    public GameObject FOV;
    public GameObject Light;

    private float startingY;
    int dir = 1;

    void Start()
    {
        startingY= transform.position.y;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime *dir);
        if (transform.position.y < startingY || transform.position.y > startingY + range)
        {
            dir *= -1;
            FOV.transform.Rotate(0f, 0f, 180f);
            Light.transform.Rotate(0f, 0f, 180f);
        }
    }
}
