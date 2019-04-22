using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenLeaf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(0,8,false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<EdgeCollider2D>().enabled = false;
        GetComponent<EdgeCollider2D>().enabled = true;
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
