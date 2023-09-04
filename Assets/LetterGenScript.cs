using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterGenScript : MonoBehaviour
{

    public GameObject missile;
    public float spawnRate = 2f;
    private float timer = 0;

    // sprite are array holding letters
    public Sprite[] letterSprites;
    private SpriteRenderer spriteRenderer;
    private int spriteIndex = 0;
    public int moduloIndex = 0;
    public char[] message = "dorobotics".ToCharArray();
    public int indexOfCharacter = 0;

    private int messageIdx = 0;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        message = "yodorobotics".ToCharArray();
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
            if(messageIdx >= (message.Length -1)) messageIdx = 0; else messageIdx += 1;
            indexOfCharacter = message[messageIdx] - 'a';


            //spriteIndex += 1;
            //moduloIndex = spriteIndex % 4; // 0, 1, 2, 3, 0
            //Debug.Log(string.Format("sprite index is {0}", moduloIndex));
            //spriteRenderer.sprite = letterSprites[moduloIndex];
            //GameObject newMissile = Instantiate(missile, transform.position, Quaternion.Inverse(transform.rotation));

            Debug.Log(string.Format("LetterGenScript: time {1} = {1} + delta {0}", Time.deltaTime, timer));

            spriteRenderer.sprite = letterSprites[indexOfCharacter];
            GameObject newMissile = Instantiate(missile, transform.position, Quaternion.Inverse(transform.rotation));

            timer = 0;
        }


    }
}

