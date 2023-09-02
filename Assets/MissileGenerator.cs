using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileGenerator : MonoBehaviour
{

    public GameObject missile;
    public float spawnRate = 2f;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            Instantiate(missile, transform.position, Quaternion.Inverse(transform.rotation));
            timer = 0;
        }


    }
}
