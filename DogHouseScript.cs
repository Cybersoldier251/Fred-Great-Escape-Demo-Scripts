using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DogHouseScript : MonoBehaviour
{
    //Declarations
    public bool playerWin = false;
    private CircleCollider2D CC2D;
    private Animator anime;
    private PlayerScripts ps;
    private SpriteRenderer playerSR;
    public RuntimeAnimatorController AnimeC;
    private Camera playerCam;
    public GameObject SecondCamera;
    // Victory menu panel object
    public GameObject vm;
    private LevelCounter LC;
    //player hit register
    private BoxCollider2D playerHR;
    //player Physical collider
    private BoxCollider2D playerPC;



    // Start is called before the first frame update
    void Start()
    {
        CC2D = GetComponent<CircleCollider2D>();
        playerCam = GameObject.Find("Player 1").GetComponent<Camera>();
       playerSR = GameObject.Find("Player 1").GetComponent<SpriteRenderer>();
        playerHR = GameObject.FindWithTag("PlayerHitBox").GetComponent<BoxCollider2D>();
        playerPC = GameObject.Find("Player 1").GetComponent<BoxCollider2D>();
        ps = GameObject.Find("Player 1").GetComponent<PlayerScripts>();
        anime = GetComponent<Animator>();
        LC = GameObject.Find("LevelCounter").GetComponent<LevelCounter>();
    }

    // Update is called once per frame
    void Update()
    {

        PlayerWin();
        RecordVictory();

    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.IsTouching(CC2D) == true)
        {

            playerWin = true;
            

        }







    }

    public void PlayerWin()
    {
        if(playerWin == true){
           // ps.gameObject.SetActive(false);
            anime.runtimeAnimatorController = AnimeC;
            SecondCamera.SetActive(true);
            vm.SetActive(true);
            ps.velocity.x = 0;
            ps.velocity.y = 0;
            playerSR.enabled = false ;
           playerPC.enabled = false ;
           playerHR.enabled = false ;  
        }





    }
    public void RecordVictory()
    {
        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            LC.level2Clear = true;            
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            LC.level3Clear = true;
        }
        else if (SceneManager.GetActiveScene().name == "Level 4")
        {
            LC.level4Clear = true;
        }
        else if (SceneManager.GetActiveScene().name == "Level 5")
        {
            LC.level5Clear = true;
        }
        else if (SceneManager.GetActiveScene().name == "Level 6")
        {
            LC.level6Clear = true;
        }
        else if (SceneManager.GetActiveScene().name == "Level 7")
        {
            LC.level7Clear = true;
        }
        else if (SceneManager.GetActiveScene().name == "Level 8")
        {
            LC.level8Clear = true;
        }
        else if (SceneManager.GetActiveScene().name == "Level 9")
        {
            LC.level9Clear = true;
        }
        else if (SceneManager.GetActiveScene().name == "Level 10")
        {
            LC.level10Clear = true;
        }




    }

}
