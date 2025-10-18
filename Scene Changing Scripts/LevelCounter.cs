using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCounter : MonoBehaviour
{//this script is used for keeping record of levels sucessfully won and unlocking levels in the main menu
    //declarations
    public bool level1Clear = true;
    public bool level2Clear = false;
    public bool level3Clear = false;
    public bool level4Clear = false;
    public bool level5Clear = false;
    public bool level6Clear = false;
    public bool level7Clear = false;
    public bool level8Clear = false;
    public bool level9Clear = false;
    public bool level10Clear = false;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    public Button button7;
    public Button button8;
    public Button button9;
    public Button button10;
    public GameObject[] SimilarOBJs;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        DestroyDuplicates();
        Level2Clear();
        Level3Clear();
        Level4Clear();
        Level5Clear();
        Level6Clear();
        Level7Clear();
        Level8Clear();
        Level9Clear();
        Level10Clear();
    }
    public void DestroyDuplicates()
    {
        SimilarOBJs = GameObject.FindGameObjectsWithTag("LevelCounter");

        foreach (GameObject i in SimilarOBJs)
        {


            if (i.gameObject.tag == "LevelCounter" == true && i != this.gameObject)
            {

                Destroy(i);
                break;
            }
            else
            {

            }
        }
    }
    public void Level2Clear()
    {
       
        if (level2Clear == true && SceneManager.GetActiveScene().name == "Main Menu")
        {
            button2 = GameObject.Find("Level 2 Button").GetComponent<Button>();
            button2.interactable = true;
        }

    }
    public void Level3Clear()
    {
        if (level3Clear == true && SceneManager.GetActiveScene().name == "Main Menu")
        {
            button3 = GameObject.Find("Level 3 Button").GetComponent<Button>();
            button3.interactable = true;
        }

    }
    public void Level4Clear()
    {
        if (level4Clear == true && SceneManager.GetActiveScene().name == "Main Menu")
        {
            button4 = GameObject.Find("Level 4 Button").GetComponent<Button>();
            button4.interactable = true;
        }

    }
    public void Level5Clear()
    {
         if (level5Clear == true && SceneManager.GetActiveScene().name == "Main Menu")
        {
            button5 = GameObject.Find("Level 5 Button").GetComponent<Button>();
            button5.interactable = true;
        }

    }
    public void Level6Clear()
    {
          if (level6Clear == true && SceneManager.GetActiveScene().name == "Main Menu")
        {
            button6 = GameObject.Find("Level 6 Button").GetComponent<Button>();
            button6.interactable = true;
        }

    }
    public void Level7Clear()
    {
         if (level7Clear == true && SceneManager.GetActiveScene().name == "Main Menu")
        {
            button7 = GameObject.Find("Level 7 Button").GetComponent<Button>();
            button7.interactable = true;
        }

    }
    public void Level8Clear()
    {
           if (level8Clear == true && SceneManager.GetActiveScene().name == "Main Menu")
        {
            button8 = GameObject.Find("Level 8 Button").GetComponent<Button>();
            button8.interactable = true;
        }

    }
    public void Level9Clear()
    {
           if (level9Clear == true && SceneManager.GetActiveScene().name == "Main Menu")
        {
            button9 = GameObject.Find("Level 9 Button").GetComponent<Button>();
            button9.interactable = true;
        }

    }
    public void Level10Clear()
    {
           if (level10Clear == true && SceneManager.GetActiveScene().name == "Main Menu")
        {
            button10 = GameObject.Find("Level 10 Button").GetComponent<Button>();
            button10.interactable = true;
        }

    }
}
