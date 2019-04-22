using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public float speed;
    public SpriteRenderer PlayerSprite;
    ArrayList PlayerSpritesList;

    // Start is called before the first frame update
    void Start()
    {
        PlayerSpritesList = new ArrayList(Resources.LoadAll<Sprite>("Sprites/Player"));
        Debug.Log("Size of Player Sprites: " + PlayerSpritesList.Count);
        foreach(Sprite sp in PlayerSpritesList)
        {
            Debug.Log(sp);
        }
        PlayerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if(Input.GetKey(KeyCode.W))
        {
            PlayerSprite.sprite = PlayerSpritesList[0];
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0,0);
        }
    }
}
