using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;


public class PlayerScripts : MonoBehaviour
{// All hard coded variables in methods such as "movement = 10" will have to be revisited.
    //Declarations
    public bool shield = false;
    public int health = 3;
    public bool slow = false;
    public float slowTime = 0;
    public float movementSpeed = 5;
    private Rigidbody2D rb;
    private SpriteRenderer sR;
    private Animator anime;
    public BoxCollider2D bc2D;
    // the PolyGonCollider is being used as a hurt box
    public PolygonCollider2D pc2D;
    public Vector2 velocity;
    public bool isBoostedA = false;
    public bool isBoostedD = false;
    public bool isBoostedS = false;
    public bool isBoostedW = false;
    public bool boostReady = true;
    private GameObject ObjLayer;
    public float InvulnerabilityTime = 1f;
    public bool Invulnerable = false;
    public float boostCooldownTime = 0f;
    public float boostDuration = 1f;
    public bool recentlyInjured = false;
    public RuntimeAnimatorController rtac1;
    public RuntimeAnimatorController rtac2;
    public RuntimeAnimatorController rtac3;
    public RuntimeAnimatorController rtac4;
    public RuntimeAnimatorController rtac5;
    public bool DeathCheck = false;
    public bool ableBark = true;
    private BarkProjectileCreationPointScript BPCPS;
    private DogHouseScript DH;
    public Transform BPCPLS;
    public bool directionUp = false;
    public bool directionDown = false;
    public bool directionLeft = false;
    public bool directionRight = true;
    public bool lastDirectionPressed_U;
    public bool lastDirectionPressed_D;
    public bool lastDirectionPressed_L;
    public bool lastDirectionPressed_R;
    //used for detecting if the player is over water
    public CircleCollider2D circleTrigger;
    public BoxCollider2D boxCollider;
    public WaterDropletScript wds;
    public AudioSource boostSound;
    public AudioSource barkSound;
    public AudioSource deathSound;
    public AudioSource hurtSound;
    public Text CooldownTime;

    // this game object is the object that will spawn the bark Projectiles. its full name is Bark Projectile Creation Point


    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Dog House Goal") != null)
        {
            DH = GameObject.Find("Dog House Goal").GetComponent<DogHouseScript>();
        }
        else if (GameObject.Find("Dog House Goal (1)") != null)
        {
            DH = GameObject.Find("Dog House Goal (1)").GetComponent<DogHouseScript>();
        }
        else
        {

        }

        rb = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
        anime = GetComponent<Animator>();
        bc2D = GetComponent<BoxCollider2D>();
        pc2D = GetComponent<PolygonCollider2D>();
        ObjLayer = this.gameObject;
        BPCPS = GameObject.Find("Bark Projectile Creation Point").GetComponent<BarkProjectileCreationPointScript>();
        BPCPLS = GameObject.Find("Bark Projectile Creation Point").transform;

    }

    // Update is called once per frame
    void Update()
    {
        DirectionalIdleAnimationSetter();
        MoveX();
        MoveY();
        BarkCheck();
        Bark();
        BoostSignal();
        Boost();
        BoostCoolDown();
        HurtInvulnerabilityTimer();
        InvulnerabilityTimeReset();
        BoostReset();
        Death();
        BoostReadyChecker();
        LastPressedSetter();
        Slow();
        SlowTimeTick();
        DisplayReady();
    }
    public void BarkCheck()
        {

        if (DH != null )
        {
            if (DH.playerWin == true)
            {
                ableBark = false;
            }
            else
            {
                ableBark = true;
            }
        }
        else
        {

        }

        }
    public void DisplayReady()
    {
        if (boostCooldownTime <= 0)
        {
            CooldownTime.text = "Ready!!!";
        }
        else
        {
            CooldownTime.text = boostCooldownTime.ToString();
        }
    }
    public void Slow()
    {
        if (slow = true)
        {
            movementSpeed = 1;
        }
        else
        {

        }

    }
    public void SlowTimeTick()
    {
        if (slowTime <= 0)
        {
            slow = false;
            movementSpeed = 5;
        }
        else if (slow == true)
        {

            slowTime = slowTime - 1 * Time.deltaTime;
        }
        else
        {

        }

    }
    public void MoveX()
    {
        rb.linearVelocity = velocity;


        //Movement Code
        if (Input.GetKey(KeyCode.D) == true)
        {
            if (DeathCheck == true || isBoostedA == true || isBoostedW == true || isBoostedD == true || isBoostedS == true) {

            }
            else
            {
                velocity.x = movementSpeed;
                sR.flipX = true;
                //Animation Code
                anime.Play("Running", ObjLayer.layer);
                bc2D.offset = new Vector2(bc2D.offset.x * -1, bc2D.offset.y);

                directionRight = true;

            }

        }
        else if (Input.GetKey(KeyCode.A) == true)
        {
            if (DeathCheck == true || isBoostedA == true || isBoostedW == true || isBoostedD == true || isBoostedS == true)
            {

            }
            else
            {

                velocity.x = -movementSpeed;
                sR.flipX = false;
                //Animation Code
                anime.Play("Running", ObjLayer.layer);
                bc2D.offset = new Vector2(bc2D.offset.x * -1, bc2D.offset.y);


                directionLeft = true;
            }


        }
        else
        {
           
            velocity.x = 0;
            directionLeft = false;
            directionRight = false;

        }
       

    }

    public void MoveY()
    {

        if (Input.GetKey(KeyCode.S) == true)
        {
            if (DeathCheck == true || isBoostedA == true || isBoostedW == true || isBoostedD == true || isBoostedS == true)
            {

            }
            else
            {

                velocity.y = -movementSpeed;

                directionDown = true;

                //Animation Code
                if (Input.GetKey(KeyCode.A) == true || Input.GetKey(KeyCode.D) == true)
                {

                }
                else
                {
                    anime.Play("Walk Down", ObjLayer.layer);
                }
            }
        }
        else if (Input.GetKey(KeyCode.W) == true)
        {
            if (DeathCheck == true || isBoostedA == true || isBoostedW == true || isBoostedD == true || isBoostedS == true)
            {

            }
            else
            {
                velocity.y = movementSpeed;

                directionUp = true;
                //Animation Code
                if (Input.GetKey(KeyCode.A) == true || Input.GetKey(KeyCode.D) == true) 
                {

                }
                else 
                {
                    anime.Play("Walk Up", ObjLayer.layer);
                }
            }


        }
        else
        {
            velocity.y = 0;
            directionUp = false;
            directionDown = false;
        }
    }
    public void Bark()
    {
        if (Input.GetKey(KeyCode.Mouse1) == true && ableBark == true)
        {
            BPCPS.FireSignal = true;
            if (BPCPS.CooldownCurrentTime == 0) {
                barkSound.Play();
            }
            else
            {

            }

        }
        else
        {
            BPCPS.FireSignal = false;
        }
        
    }
    //this function makes it so the "MoveY" Functions dont have to worry about Stopping animations while not moving.
    public void DirectionalIdleAnimationSetter()
        {
        //WIP Code
       
         if (velocity.x == 0 && velocity.y == 0 && lastDirectionPressed_L == true)
        {
            anime.Play("Idle", ObjLayer.layer);
        }
         else if (velocity.x == 0 && velocity.y == 0 && lastDirectionPressed_R == true)
        {
            anime.Play("Idle", ObjLayer.layer);
        }
        else if (velocity.x == 0 && velocity.y == 0 && lastDirectionPressed_U == true)
        {
            anime.Play("Up Idle Animation", ObjLayer.layer);
        }
         else if (velocity.x == 0 && velocity.y == 0 && lastDirectionPressed_D == true)
        {

            anime.Play("Down Idle Animation", ObjLayer.layer);
        }
        else
        {

        }
    }
    public void LastPressedSetter()
    {
        if (directionUp  == true)
        {
            lastDirectionPressed_U = true;
            lastDirectionPressed_D = false;
            lastDirectionPressed_L = false;
            lastDirectionPressed_R = false;

        }
        else if (directionDown == true)
        {
            lastDirectionPressed_D = true;
            lastDirectionPressed_U = false;
            lastDirectionPressed_L = false;
            lastDirectionPressed_R = false;
        }
        else if (directionLeft == true)
        {

            lastDirectionPressed_L = true;
            lastDirectionPressed_U = false;
            lastDirectionPressed_D = false;
            lastDirectionPressed_R = false;


        }
        else if (directionRight == true)
        {

            lastDirectionPressed_R = true;
            lastDirectionPressed_U = false;
            lastDirectionPressed_D = false;
            lastDirectionPressed_L = false;

        }
        else
        {

        }

    }

    public void BoostCoolDown()
    {
        if (Input.GetKey(KeyCode.Mouse0) == true && boostReady == true && boostCooldownTime <= 0)
        {
           boostCooldownTime = 2f;
           
        }
        else if (DeathCheck != true && isBoostedA != true || isBoostedD != true || isBoostedS != true || isBoostedW != true)
        {
            boostCooldownTime = boostCooldownTime - 1 * Time.deltaTime;
            boostDuration = boostDuration - 1 * Time.deltaTime;
             ResetCoolDownTime();
            ResetBoostDuration();
        }

    }
    // this function resets the cool down timer so it does NOT go less than zero
    public void ResetCoolDownTime()
    {

        if (boostCooldownTime < 0)
        {
            boostCooldownTime = 0;
        }
        else
        {

        }

    }
    // this function resets the Boost duration timer so it does NOT go less than zero
    public void ResetBoostDuration()
    {
        if (boostDuration < 0)
        {
            boostDuration = 0;
        }
        else
        {

        }

    }

    public void BoostReset()
    {
        if (boostDuration < 0)
        {
            boostDuration = 0f;
        }
        else
        {

        }

    }
    public void boostreadyCheck()
    {
        
        if(boostCooldownTime <= 0 && DH.playerWin == false)
        {
            boostReady = true;
        }
        else
        {
            boostReady = false;
        }


    }

    public void BoostSignal()
    {
      

        //Boost Code
        if (Input.GetKey(KeyCode.Mouse0) == true && Input.GetKey(KeyCode.A) == true && boostReady == true && boostCooldownTime <= 0 && DeathCheck == false)
        {
            isBoostedA = true;
            boostDuration = 1;
            //play sound clip
            boostSound.Play();
        }
        else if(Input.GetKey(KeyCode.Mouse0) == true && Input.GetKey(KeyCode.D) == true && boostReady == true && boostCooldownTime <= 0 && DeathCheck == false)
        {
            isBoostedD = true;
            boostDuration = 1;
            //play sound clip
            boostSound.Play();
        }
        else if (Input.GetKey(KeyCode.Mouse0) == true && Input.GetKey(KeyCode.W) == true && boostReady == true && boostCooldownTime <= 0 && DeathCheck == false)
        {
            isBoostedW = true;
            boostDuration = 1;
            //play sound clip
            boostSound.Play();
        }
        else if (Input.GetKey(KeyCode.Mouse0) == true && Input.GetKey(KeyCode.S) == true && boostReady == true && boostCooldownTime <= 0 && DeathCheck == false)
        {
            isBoostedS = true;
            boostDuration = 1;
            //play sound clip
            boostSound.Play();
        }
        else if (isBoostedA == false && isBoostedS == false && isBoostedW == false && isBoostedD == false)
        {
            boostSound.Stop();
        }
        else
        {
            movementSpeed = 5;

        }
    }
    //the following code will be incharge of invincibly boosting the character in one direction at a time
    public void Boost()
    {
        Vector2 verticalForce = Vector2.up;
        Vector2 HorizontalForce = Vector2.left;

        if (isBoostedA == true )
        {
            if (boostDuration > 0 ) {
                velocity.x = -7;
                velocity.y = velocity.y;
                
                //animation
                anime.runtimeAnimatorController = rtac2 ;

            }
            else
            {
                isBoostedA = false;
            }

        }
        else if ( isBoostedW == true )
        {
            if (boostDuration > 0 )
            {
                velocity.x = velocity.x;
                velocity.y = 7;
                Invulnerable = true;
                //animation
                anime.runtimeAnimatorController = rtac4;

            }
            else
            {
                isBoostedW = false;
            }

        }
        else if ( isBoostedS == true )
        {
            if (boostDuration > 0 )
            {
                velocity.x = velocity.x;
                velocity.y = -7;
                Invulnerable = true;
                //animation
                anime.runtimeAnimatorController = rtac5;

            }
            else
            {
                isBoostedS = false;

            }
        }
        else if ( isBoostedD == true)
        {
            if (boostDuration > 0 )
            {
                velocity.x = 7;
                velocity.y = velocity.y;
                Invulnerable = true;
                //animation
                anime.runtimeAnimatorController = rtac2;

            }
            else
            {
                isBoostedD = false;
                
            }
        }
        else
        {
            if (boostDuration == 0) {
                //animation
                anime.runtimeAnimatorController = rtac1;

                Invulnerable = false;

            }
        }

    }
    // this function is only used to reset the timer and invulnerable state to normal
    // code is Commented out for possible reuse else where

    public void InvulnerabilityTimeReset()
    {
        if (InvulnerabilityTime <= 0)
        {
            InvulnerabilityTime = 3f;
            recentlyInjured = false;
            Invulnerable = false;
        }
        else
        {
            
        }
    }
    
    public void HurtInvulnerabilityTimer()
    {
        if (recentlyInjured == true)
        {
            
            Invulnerable = true;
            InvulnerabilityTime = InvulnerabilityTime - 3 * Time.deltaTime;    
        }
        else if (recentlyInjured == false) { 
        
            Invulnerable = false;
     }
 }
    
    public void Death()
    {
       
        if (health <= 0)
        {
            movementSpeed = 0;
            velocity.x = 0;
            velocity.y = 0;
            anime.runtimeAnimatorController = rtac3;
            anime.Play("Death");
            DeathCheck = true;
             deathSound.Play();
            bc2D.enabled = false;
        }
        else
        {

        }
    }
    public void BoostReadyChecker()
    {
        if (boostCooldownTime > 0)
        {
            boostReady = false;
        }
        else
        {
            boostReady = true;
        }

    }
    //this function allows the player to take damage from obstacles or enemy projectiles
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.IsTouching(circleTrigger) == true && collision.gameObject.tag == "Map Water" && isBoostedA == false && isBoostedS == false && isBoostedD == false && isBoostedW == false)
        {
            health = health - 3;
        }
        else if (collision.IsTouching(boxCollider) == true && collision.gameObject.tag == "Enemy Water Beam")
        {
            if (Invulnerable == true)
            {

            }
            else
            {
             
                health = health - 1;
                recentlyInjured = true;
               hurtSound.Play();
            }


        }else if (collision.IsTouching(boxCollider) == true && collision.gameObject.tag == "Enemy Soap Projectile" && collision.gameObject.GetComponent<BoxCollider2D>().IsTouching(boxCollider))
        {
            slowTime = 4f;
            slow = true;
        }
        else
        {

        }
    }
    
}
