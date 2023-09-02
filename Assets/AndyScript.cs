using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndyScript : MonoBehaviour
{

    public Rigidbody2D myrigidbody;
    public GameObject missile;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "Bob";
        //gameObject.tag = "duh";


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log(string.Format("Upkey pressed"));
            myrigidbody.velocity = Vector2.up * 10;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            myrigidbody.velocity = Vector2.down * 10;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            myrigidbody.velocity = Vector2.right * 10;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            myrigidbody.velocity = Vector2.left * 10;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 pos = transform.position + Vector3.up*3;
            Instantiate(missile, pos, Quaternion.Inverse(transform.rotation));
            // myrigidbody.velocity = Vector2.left * 10;
        }
    }
    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log(string.Format("OnTriggerEnter for Andy"));
    //}
}
