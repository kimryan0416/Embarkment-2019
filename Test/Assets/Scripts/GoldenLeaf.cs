using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenLeaf : MonoBehaviour
{
    float timer = 2f; // Default time until destruction of current Golden Leaf, in case it doesn't hit anything

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(0,8,false);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        GetComponent<EdgeCollider2D>().enabled = false;
        GetComponent<EdgeCollider2D>().enabled = true;
        */
        Destroy(collision.gameObject);
        Destroy(gameObject);
        Debug.Log("I Collided With: " + collision.gameObject.name);
        /*
        if (collision.gameObject.tag == "GoldenLeaf")
        {
            //Destroy(gameObject);
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), collision.gameObject.GetComponent<BoxCollider2D>());
            Debug.Log("COLLISION WITH BRETHEREN!");
        } 
        */

    }
}
