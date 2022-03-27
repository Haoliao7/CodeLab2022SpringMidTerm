using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector2 direction;
    Rigidbody2D rb;
    
    public Color highSpeedBulletColor;
    public Color lowSpeedBulletColor;
    public Color normalSpeedBulletColor;

    public bool isOriginalEnemy;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // link to its rigidbody
       
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; // the direction from its current position toward mouse position



        if (isOriginalEnemy)
        {
            rb.velocity = -1*8 * direction / Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position); // give it a velocity based on its distance from mouse position(so their speed will be all the same)
        }
        else
        {
            GameManager.bulletCount++; //the amount of bullet in the screen +1
            rb.velocity = GameManager.bulletSpeed * direction / Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position);// give it a velocity based on its distance from mouse position(so their speed will be all the same)
            if (GameManager.currentState == GameManager.State.HighSpeedGun)// change its color according to its category
            {
                GetComponent<SpriteRenderer>().color = highSpeedBulletColor;
            }
            else if (GameManager.currentState == GameManager.State.LowSpeedGun)
            {
                GetComponent<SpriteRenderer>().color = lowSpeedBulletColor;
            }
            else if (GameManager.currentState == GameManager.State.NormalGun)
            {
                GetComponent<SpriteRenderer>().color = normalSpeedBulletColor;
            }
        }


        

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bullet" || collision.gameObject.tag == "shield")
        {
            GameManager.bulletCount--;//if collide with another bullet or shield, destroy it
            Destroy(gameObject);
        }
    }

}
