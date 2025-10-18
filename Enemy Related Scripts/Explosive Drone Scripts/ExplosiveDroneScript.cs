using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.U2D.IK;

public class ExplosiveDroneScript : MonoBehaviour
{
    //Declarations
    //max number of seconds before self destruct
    private float SDTimerMax = 3;
    //Current time before self destruct
    public float SDTimerCurrent = 3;
    public bool selfDestruct = false;
    private SpriteRenderer sr;
    private bool stunned = false;
    public float stunTime = 2f;
    //Stunned effect game object
    public GameObject SE;
    public bool explode = false;
    public float movementSpeed = 3;
    public CircleCollider2D trackingCollider;
    public Collider2D explosionAlert;
    public bool chase = false;
    public GameObject deatheffect;
    public AudioSource bombBeep;

    // Start is called before the first frame update
    void Start()
    {
        sr = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SelfDestructTimer();
        SelfDestruct();
        StunnedEffectResetter();
        StunDuration();
        StunTimerReset();
        Chase();
    }

   public void TriggerSelfDestruct()
    {

        selfDestruct = true;

    }
    public void SelfDestructTimer()
    {
        if (selfDestruct == true)
        {
            sr.color = Color.red;
            SDTimerCurrent = SDTimerCurrent - 1 * Time.deltaTime;
            
            

        }

        


    }
    public void SelfDestruct()
    {
        if(SDTimerCurrent <= 0)
            {
           
            explode = true;
            Instantiate(deatheffect).transform.SetPositionAndRotation(this.transform.localPosition, this.transform.localRotation);
            Destroy(this.gameObject);


        }
        else
        {

        }

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
           
        }
        else
        {



        }





    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (explosionAlert.IsTouching(other) == true && other.gameObject.tag == "Player" )
        {
            TriggerSelfDestruct();
            bombBeep.Play();
        }
        else if (trackingCollider.IsTouching(other) == true && other.gameObject.tag == "Player")
        {
            chase = true;
        }
        else if (other.gameObject.tag == "Player Projectile" == true && other.IsTouching(GetComponentInChildren<CircleCollider2D>()) == true)
        {
            stunned = true;

        }
        else
        {


        }
        //Utilize the "Move towards" method of the vector3 class.






    }
    public void Chase()
    {

         if (chase == true && stunned == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("Player 1").gameObject.transform.position, movementSpeed * Time.deltaTime);
            

        }
        

    }
    
    

    void OnCollisionEnter2D(Collision2D collision)
    {

       if (collision.gameObject.tag == "Player Projectile")
        {
            stunned = true;
            movementSpeed = 0;



        }
        else
        {
            movementSpeed = 4;



        }

    }
}
