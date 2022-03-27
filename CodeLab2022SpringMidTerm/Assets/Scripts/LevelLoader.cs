using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelLoader : MonoBehaviour
{
    public string fileName;

    public float xOffset;
    public float yOffset;

    public float xStartingPoint;
    public float yStartingPoint;
    // Start is called before the first frame update
    void Start()
    {
        StreamReader reader = new StreamReader(fileName);
        string contentOfFile = reader.ReadToEnd(); // read the txt file
        reader.Close(); //close it

        char[] newLineChar = { '\n' };

        string[] level = contentOfFile.Split(newLineChar);//split the string according to the new line char

        for (int i = 0; i < level.Length; i++)
        {
            MakeRow(level[i], -i);//use every string to make a row of platform
        }
    }

    void MakeRow(string rowStr, float y)
    {
        
        char[] rowArray = rowStr.ToCharArray(); //change this string into a array of character
        for (int x = 0; x < rowStr.Length; x++)
        {
            char c = rowArray[x]; //check every character
            if (c == 'X') //if it's X
            {
                GameObject platform = Instantiate(Resources.Load("Platform")) as GameObject; //make a normal platform
                platform.transform.position = new Vector2(
                    xStartingPoint+ x * xOffset,
                    yStartingPoint+ y * yOffset);
            }else if (c == 'Z')//if it's Z
            {
                    GameObject platform = Instantiate(Resources.Load("Platform")) as GameObject;//make a platform
                platform.transform.position = new Vector2(
                        xStartingPoint + x * xOffset,
                        yStartingPoint + y * yOffset);
                    platform.transform.eulerAngles = new Vector3(0, 0, 45);// and rotate it
            }
            else if (c == 'C')//if it's C
            {
                GameObject platform = Instantiate(Resources.Load("Platform")) as GameObject;//make a platform
                platform.transform.position = new Vector2(
                    xStartingPoint + x * xOffset,
                    yStartingPoint + y * yOffset);
                platform.transform.eulerAngles = new Vector3(0, 0, -45);// and rotate it
            }
            else if (c == 'A')//if it's A
            {
                GameObject platform = Instantiate(Resources.Load("Platform")) as GameObject;//make a platform
                platform.transform.position = new Vector2(
                    xStartingPoint + x * xOffset-0.5f*xOffset,// move it left a little
                    yStartingPoint + y * yOffset);
                platform.transform.eulerAngles = new Vector3(0, 0, 90);// and rotate it to make it vertical
            }
            else if (c == 'S')//if it's S
            {
                GameObject platform = Instantiate(Resources.Load("Platform")) as GameObject;//make a platform
                platform.transform.position = new Vector2(
                    xStartingPoint + x * xOffset,
                    yStartingPoint + y * yOffset);
                platform.transform.eulerAngles = new Vector3(0, 0, 90);// and rotate it to make it vertical
            }
            else if (c == 'D')//if it's D
            {
                GameObject platform = Instantiate(Resources.Load("Platform")) as GameObject;//make a platform
                platform.transform.position = new Vector2(
                    xStartingPoint + x * xOffset+ 0.5f * xOffset,// move it right a little
                    yStartingPoint + y * yOffset);
                platform.transform.eulerAngles = new Vector3(0, 0, 90);// and rotate it to make it vertical
            }



        }


    }
}
