using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fantasma : MonoBehaviour
{
    public int speed;
    public int health;
    private float limit1;
    private float limit2;
    void Start()
    {
        speed = 3;
        limit1 = -15.0f;
        limit2 = 35.0f;
        health = 30;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * speed*Time.deltaTime);

        if (transform.position.x < limit1 || transform.position.x > limit2 || transform.position.z < limit1 || transform.position.z > limit2 || health==0)
        {
            gameObject.SetActive(false);
        }
    }
}
