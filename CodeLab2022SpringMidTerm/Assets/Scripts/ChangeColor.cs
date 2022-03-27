using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Color normalGunColor;
    public Color lowSpeedGunColor;
    public Color highSpeedGunColor;
    public Color specialBulletColor;
    public Color bigBulletColor;
    public Color shieldColor;

    SpriteRenderer mySpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();// link to its SpriteRenderer
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.currentState == GameManager.State.NormalGun) // normal gun
        {
            mySpriteRenderer.color = normalGunColor;// change its color according to its category
        }
        if (GameManager.currentState == GameManager.State.LowSpeedGun) // low Speed Gun
        {
            mySpriteRenderer.color = lowSpeedGunColor;
        }
        if (GameManager.currentState == GameManager.State.HighSpeedGun) // high Speed Gun
        {
            mySpriteRenderer.color = highSpeedGunColor;
        }
        if (GameManager.currentState == GameManager.State.SpecialBullet) // special bullet
        {
            mySpriteRenderer.color = specialBulletColor;
        }
        if (GameManager.currentState == GameManager.State.BigBullet) // big bullet
        {
            mySpriteRenderer.color = bigBulletColor;
        }
        if (GameManager.currentState == GameManager.State.Shield) // shield
        {
            mySpriteRenderer.color = shieldColor;
        }
    }
}
