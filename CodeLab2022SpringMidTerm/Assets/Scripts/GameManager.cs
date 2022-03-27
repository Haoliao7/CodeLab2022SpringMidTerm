using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public string fileName;

    public static int bulletCount;
    public static int bulletSpeed = 8;

    public int normalBulletSpeed;
    public int fastBulletSpeed;
    public int slowBulletSpeed;

    public static State currentState;

    public GameObject shield;
    public GameObject specialItemPrefab;
    public GameObject winTextandButton;
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject loseTextandButton;

    public float timeBetweenEveryItemAppear;

    public Text weaponText;
    public Text levelText;
    public Text highScoreText;


    public int level=1;
    public float highScore;

    public static bool gameEnd;
    public static bool lose;

    public enum State// create your own data type
    {
        NormalGun,
        LowSpeedGun,
        HighSpeedGun,
        SpecialBullet,
        Shield,
        BigBullet
    }


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
        InvokeRepeating("InstantiateItem", timeBetweenEveryItemAppear, timeBetweenEveryItemAppear);//keep generating special item
        gameEnd = false;
        bulletCount = 1;
        level = 1;
        lose = false;

        StreamReader reader = new StreamReader(fileName);
        string highScoreString = reader.ReadLine();//read the file to check the high score
        reader.Close();//close the file
        highScore = float.Parse(highScoreString); //set the high score according to the content in the file
    }


    void Update()
    {
        if (bulletCount <= 0 && lose == false) //if there is no bullet in the screen, you win
        {
            gameEnd = true;
            winTextandButton.SetActive(true);
        }

        if(lose == true)
        {
            gameEnd = true;
            loseTextandButton.SetActive(true);
            
        }

        if (level >= highScore)
        {
            highScore = level;
        }

        levelText.text = "Level:" + level; //display the level
        highScoreText.text = "High Score:" + highScore;//display the high score
    }

    public void TransitionState(State newState) //a function for changing state
    {
        shield.SetActive(false);
        currentState = newState;
        switch (newState) //if newState(the weapon you are having) = ...
        {
            case State.NormalGun: //if it's normalgun
                weaponText.text = "Weapon: Normal Gun"; //display the name of it
                bulletSpeed = normalBulletSpeed; // change your bullet speed
            break;
            case State.LowSpeedGun://if it's LowSpeedGun
                weaponText.text = "Weapon: Low Speed Gun";//display the name of it
                bulletSpeed = slowBulletSpeed; // change your bullet speed
                break;
            case State.HighSpeedGun://if it's HighSpeedGun
                weaponText.text = "Weapon: High Speed Gun";//display the name of it
                bulletSpeed = fastBulletSpeed; // change your bullet speed
                break;
            case State.Shield://if it's shield
                weaponText.text = "Weapon: Shield";//display the name of it
                shield.SetActive(true);//activate the shield
            break;
            case State.SpecialBullet:
                weaponText.text = "Weapon: Ghost Bullet Gun";//display the name of it
                bulletSpeed = normalBulletSpeed;// change your bullet speed
                break;
            case State.BigBullet:
                weaponText.text = "Weapon: Big Bullet Gun";//display the name of it
                bulletSpeed = normalBulletSpeed;// change your bullet speed
                break;

        }


    }


    void InstantiateItem()
    {

        GameObject specialItem = Instantiate(specialItemPrefab); // instantiate a new item
        specialItem.transform.position = new Vector2(Random.Range(-8.5f, 8.5f), Random.Range(1, 5));//randomize its position
    }


    public void LoadNextLevel()
    {
        level++;
        DestroyAll("items"); //destroy all the item in the screen
        player.transform.position = new Vector2(0, -3); //set the player's position back to the starting point
        for(int i=0; i<level; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab); // instantiate the bullets according to the number of this level
            bulletPrefab.transform.position = new Vector2(Random.Range(-8.5f, 8.5f), Random.Range(0, 5));//randomize their position
        }
        bulletCount = level;
        winTextandButton.SetActive(false);
        gameEnd = false;

    }

    public void Restart()
    {
        level = 1;
        DestroyAll("items");//destroy all the item in the screen
        DestroyAll("bullet");//destroy all the bullet in the screen
        player.transform.position = new Vector2(0, -3);//set the player's position back to the starting point
        for (int i = 0; i < level; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);// instantiate the bullets according to the number of this level
            bulletPrefab.transform.position = new Vector2(Random.Range(-8.5f, 8.5f), Random.Range(0, 5));//randomize their position
        }
        bulletCount = level;
        loseTextandButton.SetActive(false);
        TransitionState(State.NormalGun); //change your weapon back to normal gun
        SaveHighScore(); //save your high score to the txt file
        lose = false;
        gameEnd = false;

    }

    void DestroyAll(string tag)
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag(tag); // find every object with tag named "items"
        for (int i = 0; i < items.Length; i++)
        {
            Destroy(items[i]); // destory them
        }
    }

    void SaveHighScore()
    {
        StreamWriter writer = new StreamWriter(fileName);
        writer.Write(highScore); //save your high score to the txt file
        writer.Close();
    }

}
