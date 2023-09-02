using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class misslescript : MonoBehaviour
{

    public Transform target;
    public Rigidbody2D rb;
    public float speed = 1f;
    public float rotateSpeed = 200f;
    public GameObject explosionEffect;
    private bool hasMissleExploed = false;
    private float explosionDuration = 20f;
    private ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        // get the transform of the Player
        target = GameObject.FindGameObjectWithTag("Player").transform;
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
        Vector2 direction = (Vector2) target.position - rb.position;

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if(!hasMissleExploed)
  
            Debug.Log(string.Format("missle collides to {0}", collision.gameObject.name));
            // collision.gameObject
            Instantiate(explosionEffect, transform.position, transform.rotation);

        //    hasMissleExploed = true;
            Destroy(gameObject);

            //DestroyImmediate(explosionEffect, true);
            //Destroy(explosionEffect, explosionDuration);
            //yield return new WaitForSeconds(explosionDuration);
            //explosionEffect.SetActive(false);


 


        //Destroy(explosionEffect);
    }
}
