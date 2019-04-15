using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fantasma : MonoBehaviour
{
    public int speed;
    // Start is called before the first frame update
   
    void Start()
    {
        speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * speed*Time.deltaTime);

        if (transform.position.x < -15.0f || transform.position.x > 35.0f || transform.position.z < -15.0f || transform.position.z > 35.0f )
        {
            transform.position=new Vector3(10,-10,10) ;
        }
    }
}
