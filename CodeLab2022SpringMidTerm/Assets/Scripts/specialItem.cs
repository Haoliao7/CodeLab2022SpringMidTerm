using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialItem : MonoBehaviour
{
    public Color normalGunColor;
    public Color lowSpeedGunColor;
    public Color highSpeedGunColor;
    public Color specialBulletColor;
    public Color bigBulletColor;
    public Color shieldColor;
    SpriteRenderer mySpriteRenderer;

    int index;
    // Start is called before the first frame update
    void Start()
    {
        index = Random.Range(0, 6);//randomly generate a special item
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        CheckIfRepeat(); // if the one which is generated is the one that the player has, generate another item
        ChangeColor();
        
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") // if the player get the item
        {
            if (index == 0) // normal gun
            {
                GameManager myManager = FindObjectOfType<GameManager>();
                myManager.TransitionState(GameManager.State.NormalGun); //change the state to NormalGun
                Destroy(gameObject);
            }
            if (index == 1) // low Speed Gun
            {
                GameManager myManager = FindObjectOfType<GameManager>();
                myManager.TransitionState(GameManager.State.LowSpeedGun);
                Destroy(gameObject);
            }
            if (index == 2) // high Speed Gun
            {
                GameManager myManager = FindObjectOfType<GameManager>();
                myManager.TransitionState(GameManager.State.HighSpeedGun);
                Destroy(gameObject);
            }
            if (index == 3) // special bullet
            {
                GameManager myManager = FindObjectOfType<GameManager>();
                myManager.TransitionState(GameManager.State.SpecialBullet);
                Destroy(gameObject);
            }
            if (index == 4) // big bullet
            {
                GameManager myManager = FindObjectOfType<GameManager>();
                myManager.TransitionState(GameManager.State.BigBullet);
                Destroy(gameObject);
            }
            if (index == 5) // shield
            {
                GameManager myManager = FindObjectOfType<GameManager>();
                myManager.TransitionState(GameManager.State.Shield);
                Destroy(gameObject);
            }
        }
    }

    void CheckIfRepeat()
    {
        if (GameManager.currentState == GameManager.State.NormalGun) // if your weapon is this
        {
            while (index == 0) // keep randomizing until it's not your current weapon
            {
                index = Random.Range(0, 6);
            }
        }

        if (GameManager.currentState == GameManager.State.LowSpeedGun) // if your weapon is this
        {
            while (index == 1) // keep randomizing until it's not your current weapon
            {
                index = Random.Range(0, 6);
            }
        }
        if (GameManager.currentState == GameManager.State.HighSpeedGun) // if your weapon is this
        {
            while (index == 2) // keep randomizing until it's not your current weapon
            {
                index = Random.Range(0, 6);
            }
        }
        if (GameManager.currentState == GameManager.State.SpecialBullet) // if your weapon is this
        {
            while (index == 3) // keep randomizing until it's not your current weapon
            {
                index = Random.Range(0, 6);
            }
        }
        if (GameManager.currentState == GameManager.State.BigBullet) // if your weapon is this
        {
            while (index == 4) // keep randomizing until it's not your current weapon
            {
                index = Random.Range(0, 6);
            }
        }
        if (GameManager.currentState == GameManager.State.Shield) // if your weapon is this
        {
            while (index == 5) // keep randomizing until it's not your current weapon
            {
                index = Random.Range(0, 6);
            }
        }



    }

    void ChangeColor()
    {
        if (index == 0) // normal gun
        {
            mySpriteRenderer.color = normalGunColor;
        }
        if (index == 1) // low Speed Gun
        {
            mySpriteRenderer.color = lowSpeedGunColor;
        }
        if (index == 2) // high Speed Gun
        {
            mySpriteRenderer.color = highSpeedGunColor;
        }
        if (index == 3) // special bullet
        {
            mySpriteRenderer.color = specialBulletColor;
        }
        if (index == 4) // big bullet
        {
            mySpriteRenderer.color = bigBulletColor;
        }
        if (index == 5) // shield
        {
            mySpriteRenderer.color = shieldColor;
        }
    }



}
