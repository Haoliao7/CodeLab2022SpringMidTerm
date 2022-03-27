using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTheGun : MonoBehaviour
{

    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // make the shield follow the gun's position and rotation
        transform.position = target.position; 
        transform.rotation = target.rotation; 
    }
}
