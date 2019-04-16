using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public enum GunEquipped
    {
        TrapGun=1,
        GhostGun
    };

    public int health;
    public Slider healthBar;
    public GameObject gun1;
    public GameObject gun2;
    public GunEquipped Gun;

    private int trapDamage;
    private int ghostDamage;
    private float heightLimit;
    private float knockBackForce;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        trapDamage = 50;
        ghostDamage = 10;
        heightLimit = -10.0f;
        knockBackForce = 15000.0f;
        Gun = GunEquipped.TrapGun;
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

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Gun = GunEquipped.TrapGun;
            gun1.gameObject.SetActive(true);
            gun2.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Gun = GunEquipped.GhostGun;
            gun1.gameObject.SetActive(false);
            gun2.gameObject.SetActive(true);
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
