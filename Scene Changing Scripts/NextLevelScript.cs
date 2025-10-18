using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{
    //Declarations
    public List<string> sceneList = new List<string>() { "Intro SlideShow", "Level 1", "Level 2", "Level 3", "Level 4", "Level 5", "Level 6", "Level 7", "Level 8", "Level 9", "Level 10" }; 

    private int currentSceneIndex = 0;

    // Start is called before the first frame update
    void Start()
    {




    }

    // Update is called once per frame
    void Update()
    {


        

       

    }



    public void NextScene()
    {
        
        // Get the build index of the currently active scene
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;

        // Check if the current scene is in our list
        if (sceneList.Contains(SceneManager.GetActiveScene().name))
        {
            // Find the index of the current scene within our list
            currentSceneIndex = sceneList.IndexOf(SceneManager.GetActiveScene().name);

            // Increment to the next index
            currentSceneIndex++;

            // Check if there is a next scene in the list
            if (currentSceneIndex < sceneList.Count)
            {
               
                SceneManager.LoadScene(sceneList[currentSceneIndex]);
            }
            else
            {
                Debug.Log("This is the last scene!");
               
            }
        }
        else
        {
            Debug.LogError("The current scene is not in the sceneList!");
        }
    }

    



}
