using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject trampa;
    public float timer;
    public float timerLimit;

    // Start is called before the first frame update
    void Start()
    {
        GameObject prefab=level1;
        int rand= Random.Range(1, 4);
        timer = 0;
        timerLimit = 10.0f;
        
        for (int i = 0; i < 3; i++)
        {
            float posx = Random.Range(1, 30);
            float posz = Random.Range(1, 30);
            Instantiate(trampa, new Vector3(posx, -0.5f, posz), Quaternion.Euler(new Vector3(-90, 0, 0)));

        }

        for (int i = 0; i < 4; i++)
        {
            rand= Random.Range(1, 4);
            switch (rand)
            {
                case 1:
                    prefab = level1;
                    break;
                case 2:
                    prefab = level2;
                    break;
                case 3:
                    prefab = level3;
                    break;
            }
            if (i<2)
                Instantiate(prefab, new Vector3(prefab.transform.position.x + 20 * i, prefab.transform.position.y, prefab.transform.position.z), Quaternion.identity);
            if (i==2)
                Instantiate(prefab, new Vector3(prefab.transform.position.x , prefab.transform.position.y, prefab.transform.position.z+20), Quaternion.identity);
            if(i==3)
                Instantiate(prefab, new Vector3(prefab.transform.position.x + 20, prefab.transform.position.y, prefab.transform.position.z+20), Quaternion.identity);

        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer>timerLimit)
        {
            float posx = Random.Range(1, 30);
            float posz = Random.Range(1, 30);
            Instantiate(trampa, new Vector3(posx, -0.5f, posz), Quaternion.Euler(new Vector3(-90, 0, 0)));
            timer = 0.0f;
        }
    }
}
