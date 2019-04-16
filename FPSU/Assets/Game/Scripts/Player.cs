using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int health;
    public Slider healthBar;
    public bool isDead;

    private int trapDamage;
    private int ghostDamage;
    private float heightLimit;
    private float knockBackForce;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        isDead = false;
        trapDamage = 50;
        ghostDamage = 10;
        heightLimit = -10.0f;
        knockBackForce = 15000.0f;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;
        if (healthBar.value==0)
        {
            healthBar.fillRect.gameObject.SetActive(false);
        }

        if (health<=0||transform.position.y<heightLimit)
        {
            SceneManager.LoadScene("FinalScene");
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name=="pinxos"||col.gameObject.name=="pinxos(Clone)")
        {
            health -= trapDamage;
            
            Rigidbody rig = GetComponent<Rigidbody>();
            Vector3 vel = -rig.velocity;
            rig.AddForce(vel.normalized*knockBackForce);
        }   
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "fantome" || other.gameObject.name == "fantome(Clone)")
        {
            health -= ghostDamage;
        }
    }
}
