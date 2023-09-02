using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missle_friend : MonoBehaviour
{

    public Transform target;
    public Rigidbody2D rb;
    public float speed = 10f;
    public float rotateSpeed = 200f;
    public GameObject explosionEffect;
    private bool hasMissleExploed = false;
    private float explosionDuration = 20f;
    private ParticleSystem ps;
    private GameObject missile;

    // Start is called before the first frame update
    void Start()
    {
        // get the transform of the Player
        //target = GameObject.FindGameObjectWithTag("Missile").transform;


        // get the ridge body of missle
        rb = GetComponent<Rigidbody2D>();
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        missile = GameObject.FindGameObjectWithTag("Missile");
        if (missile)
        {
            target = missile.transform;
        }

        Vector2 direction;

        if (target)
        {
            direction = (Vector2)target.position - rb.position;
        }else
        {
            direction = rb.position;
        }

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * speed;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if(!hasMissleExploed)
        if(collision.CompareTag("Missile")) {
            Debug.Log(string.Format("missle collides to {0}", collision.gameObject.name));
            // collision.gameObject
            Instantiate(explosionEffect, transform.position, transform.rotation);

            //    hasMissleExploed = true;
            Destroy(gameObject);
        }


        //DestroyImmediate(explosionEffect, true);
        //Destroy(explosionEffect, explosionDuration);
        //yield return new WaitForSeconds(explosionDuration);
        //explosionEffect.SetActive(false);





        //Destroy(explosionEffect);
    }
}
