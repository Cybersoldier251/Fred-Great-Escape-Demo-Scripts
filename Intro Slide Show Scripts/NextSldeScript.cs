using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NextSldeScript : MonoBehaviour
{// Declaration
    private GameObject currentSlide;
    public Sprite Sld1  ;
    public Sprite Sld2 ;
    public Sprite Sld3 ;
    public Sprite Sld4 ;
    public Sprite Sld5 ;
    // Start is called before the first frame update
    void Start()
    {
        currentSlide = GameObject.Find("Current Slide");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextSlide()
    {
        if (currentSlide.GetComponent<SpriteRenderer>().sprite.name == "Slide 1")
        {
            currentSlide.GetComponent<SpriteRenderer>().sprite = Sld2;
        }
        else if(currentSlide.GetComponent<SpriteRenderer>().sprite.name == "Slide 2")
        {
            currentSlide.GetComponent<SpriteRenderer>().sprite = Sld3;
        }
        else if (currentSlide.GetComponent<SpriteRenderer>().sprite.name == "Slide 3")
        {
            currentSlide.GetComponent<SpriteRenderer>().sprite = Sld4;
        }
        else if (currentSlide.GetComponent<SpriteRenderer>().sprite.name == "Slide 4")
        {
            currentSlide.GetComponent<SpriteRenderer>().sprite = Sld5;
        }
        else if (currentSlide.GetComponent<SpriteRenderer>().sprite.name == "Slide 5")
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
