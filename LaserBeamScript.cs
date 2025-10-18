using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using UnityEngine.UI;

public class LaserBeamScript : MonoBehaviour
{
    //Declarations
    public RedButtonScript[] button;
    public GameObject laserBeam;
    public AudioSource electricSound;
    //buttons required
    public bool disableGate = false;
   
    // Start is called before the first frame update
    void Start()
    {
       
    
        

    }

    // Update is called once per frame
    void Update()
    {
        AllPressedChecker();
        DisableGate();
        

    }

    
    public void AllPressedChecker()
    {
        disableGate = true;
        foreach (RedButtonScript i in button)
        {
            

            if (i.pressed == false )
            {
                laserBeam.SetActive(true);
                electricSound.Play();
               disableGate = false;
                break;
            }
            else 
            {
                
            }
            


            
        }
        
       

    }
    
    public void DisableGate()
    {
        if (disableGate == true) {
            laserBeam.SetActive(false);
            electricSound.Stop();
        }
    } 




}
