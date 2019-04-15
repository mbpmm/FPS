using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gun : MonoBehaviour
{
    public LayerMask rayCastLayer;
    public float rayDistance;
    public Image crosshair;
    public Text pointsText;
    private GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager");
        pointsText.text = "Points: " + manager.GetComponent<Manager>().points;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.left * 20, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, rayCastLayer))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);

            string layerHitted = LayerMask.LayerToName(hit.transform.gameObject.layer);

            switch (layerHitted)
            {
                case "trampas":
                    crosshair.color = Color.red;
                    if (Input.GetMouseButton(0))
                    {
                        hit.transform.gameObject.SetActive(false);
                        manager.GetComponent<Manager>().points += 100;
                        manager.GetComponent<Manager>().traps++;
                    }
                    break;
                case "fantasmas":
                    crosshair.color = Color.red;
                    if (Input.GetMouseButton(0))
                    {
                        hit.transform.gameObject.SetActive(false);
                        manager.GetComponent<Manager>().points += 200;
                        manager.GetComponent<Manager>().ghosts++;
                    }
                    break;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.white);
            crosshair.color = Color.green;
        }

        pointsText.text = "Points: " + manager.GetComponent<Manager>().points;
    }
}
