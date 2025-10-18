using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UIElements;

public class ExplosiveDroneWaterCreationPointScript : MonoBehaviour
{//Declarations
    private ExplosiveDroneScript EDS;
    private Vector3 cpPosition;
    private Quaternion cpRotation;
    public GameObject waterGO;
    //the cooldown to prevent more than 1 shot fired after explosion
    public int cd;
    
    // Start is called before the first frame update
    void Start()
    {
       EDS = gameObject.GetComponentInParent<ExplosiveDroneScript>();

    }

    // Update is called once per frame
    void Update()
    {
        WaterCreation();

    }

    public void WaterCreation()
    {
        if (EDS.SDTimerCurrent <= .01 && cd <= 0)
        {


            //this code is used to make the water bullet spawn from the positon of the "Water Creation point" on the turret and also make the bullet face the right way before spawning it.
            cpPosition = this.gameObject.transform.position;
            cpRotation = this.gameObject.transform.rotation;
            Instantiate(waterGO, cpPosition, cpRotation);
            cd = 99;

        }


    }

}


   
