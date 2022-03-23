using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiming : MonoBehaviour
{

    public float mousePosXMap;
    public float mousePosYMap;
    public Vector3 target;

    public GameObject bulletPrefab;
    public Transform bulletInstantiatePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        


        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10);


        // shoot

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab); // instantiate a new meteor
            bullet.transform.position = bulletInstantiatePos.position;

        }
        

    }


}
