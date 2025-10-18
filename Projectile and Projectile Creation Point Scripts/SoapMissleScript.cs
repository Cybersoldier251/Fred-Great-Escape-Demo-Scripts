using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using UnityEngine.VFX;
using static UnityEngine.GraphicsBuffer;

public class SoapMissleScript : MonoBehaviour
{
    //declaration
    public GameObject effect;
    public float movespeed = 3;
    public float rotatespeed = 1;
    public BoxCollider2D boxColl;
    private PlayerScripts ps;
    private Rigidbody2D rb2d;
    private CircleCollider2D detectcircle;
    // Start is called before the first frame update
    void Start()
    {
        ps = GameObject.Find("Player 1").GetComponent<PlayerScripts>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        detectcircle = gameObject.GetComponent<CircleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Thrust();


    }
    public void Thrust()
    {

        rb2d.linearVelocity = transform.up * movespeed;


    }
    public void OnTriggerStay2D(Collider2D collision)
    {

        if (boxColl.IsTouching(GameObject.Find("Walls Tilemap").GetComponent<TilemapCollider2D>()) == true && collision.gameObject.tag == "Walls" == true)
        {
            
            Instantiate(effect).transform.position = transform.localPosition ;
            Destroy(this.gameObject);

        }
        else if ( collision.IsTouching(boxColl) && collision.gameObject.tag == "Player Projectile")
        {


            Instantiate(effect).transform.position = transform.localPosition;
            Destroy(this.gameObject);

        }
        else if (boxColl.IsTouching(collision) == true && collision.gameObject.tag == "PlayerHitBox")
        {
            Instantiate(effect).transform.position = transform.localPosition;
            Destroy(this.gameObject);

            Debug.Log("It HIt");


        }
        else if (detectcircle.IsTouching(GameObject.Find("Player 1").GetComponentInChildren<BoxCollider2D>()) == true)
        {
            Vector2 direction = GameObject.Find("Player 1").transform.position - transform.position;
            Quaternion targetRotation = Quaternion.FromToRotation(Vector3.up, GameObject.Find("Player 1").transform.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,targetRotation,45f * Time.deltaTime);


        }
       
        else
        {



        }
     }

}
