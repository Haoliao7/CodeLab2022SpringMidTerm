using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector2 direction;
    Rigidbody2D rb;
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        GameManager.bulletCount++;
        
        rb.velocity = bulletSpeed*direction / Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            GameManager.bulletCount--;
            Destroy(gameObject);
        }

        if(collision.gameObject.name == "Player")
        {
            //lose
            Debug.Log("lose");
        }
    }

}
