using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D.IK;

public class SprinklerSoldierScript : MonoBehaviour
{
    //Declarations
    //health Subject to change
    public int health = 10 ;
    public bool shield = false;
    public float movespeed = .1f;
    public float missleCoolDown = 6;
    public PolygonCollider2D PC2D;
    public CircleCollider2D CC2D;
    public bool hit = false;
    //this stands or current color change time
    public int ccct;
    public bool invulnerable = false;
    public bool recentlyhurt = false;
    public GameObject deatheffect;
    public float InvulnerabilityTime = 2;
    public float HurtFeedbackTime = 2;
    private Rigidbody2D rb2D;
    public TurretTargetingScript TTS;
    public TurretTargeting2Script TTS2;
    private SpriteRenderer sr;
    private Animator anime;
    public GameObject beam;
    public RuntimeAnimatorController rtac1;
    public RuntimeAnimatorController rtac2;
    public RuntimeAnimatorController rtac3;
    public RuntimeAnimatorController rtac4;
    public AudioSource hurtSound;
    public bool chase = false ;
    // Start is called before the first frame update
    void Start()
    {
       
        CC2D = GetComponent<CircleCollider2D>();
        anime = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        
    }
    
    // Update is called once per frame
    void Update()
    {
       
        MovementAnimations();
        InvulnerabilityTimeReset();
        HurtInvulnerabilityTimer();
        hurtFeedbackCounter();
        Death();
        MissleCooldownTimeTick();
        SecondPhase();
    }
    public void SecondPhase()
    {
       if(health == 5)
        {
            beam.gameObject.SetActive(true);
        }
    }
    public void MissleCooldownTimeTick()
    {
        if (missleCoolDown >= 0) 
        {
            missleCoolDown = missleCoolDown - 1 * Time.deltaTime;

        }
        else
        {

        }
    }
    public void Movment()
    {
        //Vector2 direction =  GameObject.Find("Player 1").transform.position - transform.position ;
        transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("Player 1").transform.position, movespeed * Time.deltaTime);
    }
    public void MovementAnimations()
    {
        if (GameObject.Find("Player 1").transform.position.x > gameObject.transform.position.x && chase == true)
        {
            anime.runtimeAnimatorController = rtac2;
            sr.flipX = false;
        }
        else if (GameObject.Find("Player 1").transform.position.y > gameObject.transform.position.y && chase == true)
        {
            anime.runtimeAnimatorController = rtac4;
        }
        else if (GameObject.Find("Player 1").transform.position.x < gameObject.transform.position.x && chase == true)
        {
            anime.runtimeAnimatorController = rtac2;
            sr.flipX = true;
        }
        else if (GameObject.Find("Player 1").transform.position.y < gameObject.transform.position.y && chase == true)
        {
            anime.runtimeAnimatorController = rtac3;
        }
        else if(chase = false)
        {
            anime.runtimeAnimatorController = rtac1;
        }
        else
        {

        }

        
    }
    public void InvulnerabilityTimeReset()
    {
        if (InvulnerabilityTime <= 0)
        {
            InvulnerabilityTime = 2f;
            HurtFeedbackTime = 2f;
            recentlyhurt = false;
            invulnerable = false;
            hit = false;
        }
        else
        {

        }
    }

    public void HurtInvulnerabilityTimer()
    {
        if (recentlyhurt == true)
        {
            invulnerable = true;
            InvulnerabilityTime = InvulnerabilityTime - 3 * Time.deltaTime;
        }
        else if (recentlyhurt == false)
        {

            invulnerable = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.IsTouching(CC2D) == true )
        {

         
            TTS.enemyDetectedAnswer = true;
            MovementAnimations();

        }
       
        else
        {

        }
        //Sound Emmision

    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player" && other.IsTouching(CC2D) == false)
        {
            TTS.enemyDetectedAnswer = false;
           TTS2.enemyDetectedAnswer = false;

        }
        else
        {

        }
        //Sound emmission

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.IsTouching(PC2D) && collision.gameObject.tag == "Player" && invulnerable != true)
        {
            hit = true;
            health = health - 1;
            recentlyhurt = true;
            hurtSound.Play();

        }
      

        else
        {

        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.IsTouching(CC2D) && collision.gameObject.tag == "Player" && invulnerable != true)
        {
            chase = true;
            Movment();
            if (missleCoolDown <= 0)
            {
               
                TTS2.enemyDetectedAnswer = true;
                missleCoolDown = 6;
            }
            else
            {

            } 
            

            

        }
        else
        {
            chase = false;
        }
    }
    public void hurtFeedbackCounter()
    {
        if (recentlyhurt == true)
        {
            invulnerable = true;
            HurtFeedbackTime = HurtFeedbackTime - 3 * Time.deltaTime;
            InvulnerabilityTime = HurtFeedbackTime - 3 * Time.deltaTime;
        }
        else
        {
            invulnerable = false;
        }
    }

    public void Death()
    {
        if (health <= 0)
        {
            Instantiate(deatheffect).transform.SetPositionAndRotation(this.transform.localPosition, this.transform.localRotation);
            Destroy(this.gameObject);


        }
        else
        {



        }




    }
}
