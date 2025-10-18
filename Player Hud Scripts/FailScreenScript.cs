using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailScreenScript : MonoBehaviour
{   //declarations
    public GameObject FP;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        



    }

    // Update is called once per frame
    void Update()
    {
        SetMenuActive();



    }


    public void SetMenuActive()
    {

        if (player.GetComponent<PlayerScripts>().DeathCheck == true)
        {
            FP.active = true;


        }
        else
        {
            FP.active = false;



        }






    }



}
