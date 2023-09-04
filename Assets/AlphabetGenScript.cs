using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetGenScript : MonoBehaviour
{

    public GameObject missile;
    public float spawnRate = 2f;
    private float timer = 0;
    public Sprite[] letterSprites;
    private SpriteRenderer spriteRenderer;
    private int spriteIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Resources.Load<Sprite>()
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spriteIndex += 1;
            int moduloIndex = spriteIndex % 4; // 0, 1, 2, 3, 0
            Debug.Log(string.Format("sprite index is {0}", moduloIndex));
            spriteRenderer.sprite = letterSprites[moduloIndex];
            GameObject newMissile = Instantiate(missile, transform.position, Quaternion.Inverse(transform.rotation));
            timer = 0;
        }


    }
}

