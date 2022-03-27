using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiming : MonoBehaviour
{
    
    public float mousePosXMap;
    public float mousePosYMap;
    public Vector3 target;

    public GameObject bulletPrefab;
    public GameObject specialBulletPrefab;
    public GameObject bigBulletPrefab;
    public Transform bulletInstantiatePos;
    public GameManager myManager;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            

        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; // the direction from fire point toward mouse position
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // change vetor2 into angle
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10); // rotate the gun0


        // shoot

        if (Input.GetMouseButtonDown(0) && GameManager.currentState != GameManager.State.Shield && GameManager.gameEnd == false)
        {
            if(GameManager.currentState == GameManager.State.SpecialBullet)
            {
                GameObject bullet = Instantiate(specialBulletPrefab); // instantiate a new bullet at the fire point
                bullet.transform.position = bulletInstantiatePos.position;

                

            }
            else if(GameManager.currentState == GameManager.State.BigBullet)
            {
                GameObject bullet = Instantiate(bigBulletPrefab); // instantiate a new bullet at the fire point
                bullet.transform.position = bulletInstantiatePos.position;
            }
            else
            {
                GameObject bullet = Instantiate(bulletPrefab); // instantiate a new bullet at the fire point
                bullet.transform.position = bulletInstantiatePos.position;
            }
            

        }
        

    }


}
