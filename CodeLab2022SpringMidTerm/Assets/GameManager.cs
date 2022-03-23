using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int bulletCount;


    //singleton pattern
    private static GameManager instance;

    //in some cases, if a variable of this game manager is NOT static, we'll need a reference to
    //the instance with the game manager

    public static GameManager FindInstance()
    {
        return instance;
    }

    private void Awake()
    {
        //if we have already chosen a king game manager
        //(null literally means "nothing", so if instance is NOT nothing)
        //AND
        //if the king game manager is NOT this instance of the class
        //destroy this
        if (instance != null && instance != this)
        {
            //what we;re doing is ensuring that there can only
            //be one game manager in any scene
            Destroy(this);
        }
        else //otherwise, if we do not have a king game manager
        {
            //make this the king game manager
            instance = this;
            //and do not destroy this game object when we load new scenes
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        
    }


    void Update()
    {
        if (bulletCount <= 0)
        {
            Debug.Log("win");
        }
    }
}
