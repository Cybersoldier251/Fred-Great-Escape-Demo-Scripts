using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarkProjectileCreationPointLocationScript : MonoBehaviour
{
    //Declarations
    //this declaration is for the current location of the gameobject its attached to. for the use of moving it later
    private PlayerScripts PS;
    public GameObject self;



    // Start is called before the first frame update
    void Start()
    {
        PS = GameObject.Find("Player 1").GetComponent<PlayerScripts>();

    }

    // Update is called once per frame
    void Update()
    {

        CreationPointPositionChanger_Right();
        CreationPointPositionChanger_Left();
        CreationPointPositionChanger_Up();
        CreationPointPositionChanger_Down();
    }

    public void CreationPointPositionChanger_Right()
    {
        if (PS.directionRight == true )
        {
            self.transform.localPosition = new Vector3(0.4273653f, -0.052f, 0f);
            self.transform.localEulerAngles = new Vector3(0f, 0f, 180f);


        }
        else
        {

        }
        
       
       

    }

    public void CreationPointPositionChanger_Left()
    {
        if (PS.directionLeft == true )
        {

            self.transform.localPosition = new Vector3(-0.4273653f, 0.052f, 0f);
            self.transform.localEulerAngles = new Vector3(0f, 0f, 0f);

        }
        else
        {




        }








    }
    public void CreationPointPositionChanger_Up()
    {

        if (PS.directionUp == true )
        {
           

            self.transform.localPosition = new Vector3(0f, 0.5f, 0f);
            self.transform.localEulerAngles = new Vector3(0f, 0f, -90f);
        }
        else
        {



        }






    }
    public void CreationPointPositionChanger_Down()
    {

        if (PS.directionDown == true )
        {
            

            self.transform.localPosition = new Vector3(0f, -.5f, 0f);

            self.transform.localEulerAngles = new Vector3(0, 0, 90f);



        }   
        else
        {


        }







    }


}
