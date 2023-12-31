using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileGenerator : MonoBehaviour
{

    public GameObject missile;
    public float spawnRate = 2f;
    private float timer = 0;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

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
            Debug.Log(string.Format("MissileGenScript: time {1} = {1} + delta {0}", Time.deltaTime, timer));

            Instantiate(missile, transform.position, Quaternion.Inverse(transform.rotation));
            timer = 0;
        }


    }
}
