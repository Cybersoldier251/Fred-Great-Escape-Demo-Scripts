using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGateTrapTriggerScript : MonoBehaviour
{
    //declarations
    public GameObject boss;
    public GameObject Laserbeam;
    private bool hit = false;
    public BoxCollider2D thisBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GateOn();


    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "PlayerHitBox" && thisBox.IsTouching(collision))
        {
            
            hit = true;
        }
        else
        {

        }
    }
    public void GateOn()
    {
        if(hit == true)
        {
            Laserbeam.gameObject.SetActive(true);
            boss.gameObject.SetActive(true);
           
        }
        
    }
}
