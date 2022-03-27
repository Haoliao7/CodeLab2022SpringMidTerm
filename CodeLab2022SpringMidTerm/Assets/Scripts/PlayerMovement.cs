using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D rb;
    public GameObject player;
    public float jumpForce;
    public bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;

       
        if (Input.GetKey(KeyCode.A))// press a to move left
        {
            newPos.x -= speed * Time.deltaTime;// Time.deltatime = times between two frames
        }
        if (Input.GetKey(KeyCode.D)) // press d to move right
        {
            newPos.x += speed * Time.deltaTime;// Time.deltatime = times between two frames
        }

        if ((Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.W)) && isJumping == false) // press space or W to jump, if players are in the sky, don't let them jump again or they will just fly away
        {
            isJumping = true; // cannot double jump
            rb.AddForce(new Vector2(0, jumpForce));
        }

        transform.position = newPos;



    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "platform")
        {
            isJumping = false; // if collide with ground, players can jump again
        }

        if(collision.gameObject.tag == "bullet")
        {
            GameManager.lose = true;// if collide with a bullet, player lose
        }

    }

}
