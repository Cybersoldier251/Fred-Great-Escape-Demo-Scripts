using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    //declaration
    
    private CircleCollider2D CC2D;
    private Animator anime;
    public TurretTargetingScript TTS;
    private Collision2D coll2D;
    public int health = 1;
    private bool shield = false;
    public bool stunned = false;
    public GameObject SE;
    private Object obj;
    public float stunTime = 2f ;
    private SpriteRenderer sr;
    public bool hit = false;
    //this stands or current color change time
    public int ccct;
    public bool invulnerable = false;
    public bool recentlyhurt = false;
    public GameObject deatheffect;
    public float InvulnerabilityTime = 2;
    public float HurtFeedbackTime = 2;
    private PolygonCollider2D PC2D;
    public AudioSource detectionSound;
    //Target Lost Sound Source
    public AudioSource TLSound;
    public AudioSource hurtSound;
    public AudioSource StunSound;

    // Start is called before the first frame update
    void Start()
    {
       
        CC2D = GetComponent<CircleCollider2D>();
        anime = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer> ();
        PC2D = GetComponent<PolygonCollider2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Death();
        StunDuration();
        StunTimerReset();
        StunnedEffectResetter();
        hurtFeedbackCounter();
        HurtFeedback();
        InvulnerabilityTimeReset();




    }
    public void StunnedEffectResetter()
    {
        if (stunned == true)
        {
           
            SE.gameObject.SetActive(true);

        }
        else
        {
            SE.gameObject.SetActive(false);
            

        }





    }
    public void StunDuration()
    {
        if (stunned == true)
        {
            TTS.enemyDetectedAnswer = false;
           
            
            stunTime = stunTime - 1 * Time.deltaTime;
            

        }
        else
        {



        }




    }
    public void StunTimerReset()
    {
        if (stunTime <= 0)
        {
            stunned = false;
            stunTime = 2;
            TTS.enemyDetectedAnswer = true;
        }
        else
        {



        }





    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && other.IsTouching(CC2D) == true && stunned == false)
        {
        TTS.enemyDetectedAnswer = true;
           



        }
        else if (other.gameObject.tag == "Player Projectile" && other.IsTouching(GetComponentInChildren<PolygonCollider2D>()) == true)
        {
            stunned = true;
            StunSound.Play();
        }
         else
        {

        }
        //Sound Emmision
       
    }
    // this code is just here to procvide feedback to the player that they are doing damage by changing the enemy color for a brief time
    public void HurtFeedback()
    {
        if (hit == true)
        {
            sr.color = Color.red;
        }
        else
        {
            sr.color = Color.white;
        }
        
    }
   
    public void ColorReset()
    {
        if (HurtFeedbackTime >= 0) 
        {
          
            HurtFeedbackTime = 2;
        }
        else
        {

        }
    }
    // this function is only used to reset the timer and invulnerable state to normal
    
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
    private void OnTriggerExit2D(Collider2D other)
    {
       
        if (other.gameObject.tag == "Player" && other.IsTouching(CC2D) == false)
       {
            TTS.enemyDetectedAnswer = false;
            
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
