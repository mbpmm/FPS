using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int health;
    public Slider healthBar;


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;
        if (healthBar.value==0)
        {
            healthBar.fillRect.gameObject.SetActive(false);
        }

        if (health==0||transform.position.y<-10.0f)
        {
            SceneManager.LoadScene("FinalScene");
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name=="pinxos"||col.gameObject.name=="pinxos(Clone)")
        {
            health -= 50;
            
            Rigidbody rig = GetComponent<Rigidbody>();
            Vector3 vel = -rig.velocity;
            rig.AddForce(vel.normalized*10000.0f);
            Debug.Log("colisiona");
        }
        
    }
}
