using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        Destroy(this);
    }
}
