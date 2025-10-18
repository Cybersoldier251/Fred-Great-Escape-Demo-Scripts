using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BarkProjectileScript : MonoBehaviour
{
    //Declarations
    private Rigidbody2D rb2d;
    private Animator anime;
    private PolygonCollider2D PC2D;
    private Collision2D coll2D;
    public GameObject effect;
    private Vector3 cpPosition;
    public TurretScript ts;
    //this value is called "Dead time". its used for resetting the "Current Dead time"'s time
    private float dt = 1f;
    // this value is called "Current Dead Time". after a collision is detected this will count down to 0. after that is should be deleted
    // this is used to allow the collision animation to play
    private float cdt = 1f;
    private SpriteRenderer sr;
    //this value is called "Time Tick Start" used for telling the function when it should start ticking down the clock aka "Current Dead Time"
    public bool tts = false;

    // Start is called before the first frame update
    void Start()
    {
        tts = false ;
        rb2d = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        PC2D = GetComponent<PolygonCollider2D>();

        cpPosition = transform.position;

        sr = GetComponent<SpriteRenderer>();




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
        rb2d.linearVelocity = -transform.right * 7;









    }


    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.IsTouching(PC2D) == true && other.gameObject.tag == "EnemyHitRegister" )
        {
            sr.forceRenderingOff = true;
            PC2D.enabled = false;
            rb2d.linearVelocity = -transform.right * 0;
            tts = true;

            Instantiate(effect).transform.SetPositionAndRotation(this.transform.localPosition, this.transform.localRotation);




        }
        else if (PC2D.IsTouching(GameObject.Find("Walls Tilemap").GetComponent<TilemapCollider2D>()) == true && other.gameObject.tag == "Walls" == true)
        {
            sr.forceRenderingOff = true;
            PC2D.enabled = false;
            rb2d.linearVelocity = -transform.right * 0;
            tts = true;
            Instantiate(effect).transform.SetPositionAndRotation(this.transform.localPosition, this.transform.localRotation);


        }
        else if ( other.gameObject.tag == "Walls" == true)
        {
            sr.forceRenderingOff = true;
            PC2D.enabled = false;
            rb2d.linearVelocity = -transform.right * 0;
            tts = true;
            Instantiate(effect).transform.SetPositionAndRotation(this.transform.localPosition, this.transform.localRotation);


        }
        else
        {



        }
       







    }

    public void TimeBeforeDestroy()
    {
        if (cdt <= 0)
        {
            Destroy(this.gameObject);


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








    }

