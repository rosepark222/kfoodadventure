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
    public GameObject letterGen;
    private bool hasMissleExploed = false;
    private float explosionDuration = 20f;
    private ParticleSystem ps;
    private SpriteRenderer spriteRenderer;
    private bool rocketFollowTarget = false;
    public bool locked = false;
    // Start is called before the first frame update
    void Start()
    {

        this.transform.localScale = new Vector3(1f, 1f, 1f);
        spriteRenderer = GetComponent<SpriteRenderer>();

        // get the transform of the Player
        target = GameObject.FindGameObjectWithTag("Player").transform;
        // get letterGen and access letterGenScript
        letterGen = GameObject.FindGameObjectWithTag("LetterGen");
        if (letterGen != null)
        {
            LetterGenScript scriptB = letterGen.GetComponent<LetterGenScript>();
            if (scriptB != null)
            {
                
                Debug.Log(string.Format("LetterGenScript has sprite {0} in {1}", scriptB.indexOfCharacter, this)); // Access and use scriptB here.
                spriteRenderer.sprite = scriptB.letterSprites[scriptB.indexOfCharacter];
            }
        }
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

        if(rocketFollowTarget)
        {
            Vector2 direction = (Vector2)target.position - rb.position;

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * speed;
        } else
        {
            Vector2 direction = (Vector2)target.position - rb.position;
            direction.Normalize(); // Normalize the direction vector to maintain consistent speed.

            // Calculate the new position based on the direction and speed.
            Vector2 newPosition = (Vector2)transform.position + direction * speed * Time.fixedDeltaTime;

            // Move the Rigidbody to the new position.
            rb.MovePosition(newPosition);
        }



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
