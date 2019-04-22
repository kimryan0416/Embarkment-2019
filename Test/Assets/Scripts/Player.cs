using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth;
    int currentHealth;
    public float speed;
    public Image[] hearts;
    public GameObject GoldenLeaf;
    Camera mainCamera;
    public float leafPower;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        currentHealth = maxHealth;
        GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.P) && currentHealth > 0)
        {
            currentHealth--;
        }
        if (Input.GetKeyDown(KeyCode.O) && currentHealth < maxHealth)
        {
            currentHealth++;
        }
        GetHealth();
    }

    void GetHealth()
    {
        for(int i = 0; i <= hearts.Length-1; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].gameObject.SetActive(true);
            }
            else
            {
                hearts[i].gameObject.SetActive(false);
            }

        }
    }

    void Movement()
    {
        if(Input.GetKey(KeyCode.W))
        {
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

    void Attack()
    {
        #region //prepareGoldenLeaf
        // Need to get mouse's position relative to world, not the screen
        Vector3 mouseOriginal = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(mouseOriginal);
        // Create new clone of GoldenLeaf, generated at current position of player, at the default GoldenLeaf's rotation angle
        GameObject newGoldenLeaf = Instantiate(GoldenLeaf, transform.position, GoldenLeaf.transform.rotation);
        #endregion

        #region //GoldenLeafRotation
        // We rotate the newGoldenLeaf to face the mouse's world position
        float difY = mousePosition.y - transform.position.y;
        float difX = mousePosition.x - transform.position.x;
        float directionRadians = Mathf.Atan2(difY, difX);
        float directionDegrees = directionRadians * Mathf.Rad2Deg - 90;
        newGoldenLeaf.transform.eulerAngles = new Vector3(0, 0, directionDegrees);
        #endregion

        // Since difY and difX are relative to the world, since screens are naturally more wide than tall, 
        // shooting upwards or downwards will result in a slower velocity
        // We need to counter this by setting a constant velocity...
        // We don't use addForce because velocity allows for constant movement, unlike addForce which is used primarily for movement of bodies
        float velX = Mathf.Cos(directionRadians) * leafPower;
        float velY = Mathf.Sin(directionRadians) * leafPower;
        newGoldenLeaf.GetComponent<Rigidbody2D>().velocity = new Vector3(velX, velY, 0);

    }
}
