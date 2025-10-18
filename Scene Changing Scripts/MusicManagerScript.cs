using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManagerScript : MonoBehaviour
{
    //declarations
    public GameObject boss;
    public AudioSource song1;
    public AudioSource bossSong;
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
        PlaySong1();
        FadeSong1();
        PlayBossSong();
        SearchForBoss();
        FadeBackIn();
        ReRaiseBossVolume();
    }
    public void SearchForBoss()
    {
        if (boss == null)
        {
            boss = GameObject.Find("Sprinkler Soldier");
        }
        else
        {

        }
    }
    public void StartMenuMusic()
    {
        SceneManager.GetActiveScene();
    }
   
    public void DestroyDuplicates()
    {
        SimilarOBJs = GameObject.FindGameObjectsWithTag("MusicManager");
       
        foreach (GameObject i in SimilarOBJs )
        {
            

            if (i.gameObject.tag == "MusicManager" == true && i != this.gameObject)
            {
                
                Destroy(i);
                break;
            }
            else
            {
                
            }
        }
    }
   
    public void PlaySong1()
    {
        if (song1.isPlaying == false) {
            if (SceneManager.GetActiveScene().name == "Main Menu")
            {
                song1.Play();
            }
            else
            {

            }
        }

    }
    public void PlayBossSong()
    {

        if (bossSong.isPlaying == false)
        {
            if (song1.volume <= 0)
            {
                bossSong.Play();

            }
            else
            {

            }
        }
        
    }
    public void FadeSong1() 
    {
        if (boss != null) {
            if (song1.isPlaying == true && boss.gameObject.activeSelf == true)
            {
                song1.volume = song1.volume - .1f * Time.deltaTime;
            }
           else
            {

            }
        }
        else
        {

        }
    }
    public void FadeBackIn()
    {
        if (song1.isPlaying == true && boss == null && song1.volume < .316f)
        {
            song1.volume = song1.volume + .1f * Time.deltaTime;
            bossSong.volume = bossSong.volume - 1f * Time.deltaTime;
        }
        else
        {

        }


    }
    public void ReRaiseBossVolume()
    {
        if (bossSong.volume <.6 && bossSong.isPlaying == true && boss != null)
        {
            bossSong.volume = bossSong.volume + 1f * Time.deltaTime;
        }
    }

}
