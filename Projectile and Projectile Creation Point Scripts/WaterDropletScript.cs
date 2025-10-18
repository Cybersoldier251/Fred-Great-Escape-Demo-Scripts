using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class WaterDropletScript : MonoBehaviour
{
    //Delcaration
    public Rigidbody2D rb2d;
    public Animator anime;
    public PolygonCollider2D PC2D;
    public Collision2D coll2D;
    public GameObject effect;
    private Vector3 cpPosition;
    //this value is called "Dead time". its used for resetting the "Current Dead time"'s time
    public float dt = 1f;
    // this value is called "Current Dead Time". after a collision is detected this will count down to 0. after that is should be deleted
    // this is used to allow the collision animation to play
    public float cdt = 1f;
    public SpriteRenderer sr;
    //this value is called "Time Tick Start" used for telling the function when it should start ticking down the clock aka "Current Dead Time"
    public bool tts = false;
    public GameObject player;
    public PlayerScripts ps;
    public TilemapCollider2D walls;
    //this is fot the player projectile
    public GameObject pp;
    public PlayerHitRegisterBoxColliderScript phr;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        PC2D = GetComponent<PolygonCollider2D>();
        cpPosition = transform.position;
        sr = GetComponent<SpriteRenderer>();
        ps = GameObject.Find("Player 1").GetComponent<PlayerScripts>();
        player = GameObject.Find("Player 1");
        walls = GameObject.Find("Walls Tilemap").gameObject.GetComponent<TilemapCollider2D>();
        phr = GameObject.Find("Hit Register Box Collider").GetComponent<PlayerHitRegisterBoxColliderScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Velocity();
        TimeBeforeDestroy();
        TimeTick();


    }
    public void Velocity()
    {

        // this code allows the water droplet to move to the direction 
        rb2d.linearVelocity = -transform.right * 2f;









    }

    
    public void OnTriggerStay2D(Collider2D collision)
    {
        
        if (PC2D.IsTouching( GameObject.Find("Walls Tilemap").GetComponent<TilemapCollider2D>()) == true && collision.gameObject.tag == "Walls" == true)
        {
            sr.forceRenderingOff = true;
            PC2D.enabled = false;
            rb2d.linearVelocity = -transform.right * 0;
            tts = true;
            Instantiate(effect).transform.SetPositionAndRotation(this.transform.localPosition, this.transform.localRotation);


        }
        else if ( collision.gameObject.tag == "Player Projectile")
        {
            sr.forceRenderingOff = true;
            PC2D.enabled = false;
            rb2d.linearVelocity = -transform.right * 0;
            tts = true;
            Instantiate(effect).transform.SetPositionAndRotation(this.transform.localPosition, this.transform.localRotation);


        }
        

        else if (collision.IsTouching(PC2D) == true && collision.gameObject.tag == "PlayerHitBox")
        {
            if (ps.Invulnerable == true)
            {


            }
            else
            {
                sr.forceRenderingOff = true;
                PC2D.enabled = false;
                rb2d.linearVelocity = -transform.right * 0;
                tts = true;
                Instantiate(effect).transform.SetPositionAndRotation(transform.localPosition, transform.localRotation);
                ps.health = ps.health - 1;
                ps.recentlyInjured = true;


            }



        }
        else
        {



        }

        
      



    }

    private void TimeTick()
    {
        if (tts == true)
        {
            cdt = cdt - .1f * Time.deltaTime;



        }
        else
        {




        }




    }

    public void TimeBeforeDestroy()
    {
        if(cdt <= 0)
        {

            Destroy(this.gameObject);


        }
        else
        {





        }




        
    }
   
}
