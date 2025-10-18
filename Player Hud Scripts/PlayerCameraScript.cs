using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerCameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    //Declaration
    public float camChangeDistVal = .5f;
    public float cameraMaxDistance = 4;
    public float camMinDistance =  1.5f;
    public float currentCamDist;
    public Camera cam;

    void Start()
    {
       cam = this.gameObject.GetComponent<Camera>();
        cam.orthographicSize = cam.orthographicSize;
        

    }

    // Update is called once per frame
    void Update()
    {

        MaxView();
        MinView();
        IncreaseDistance();
        DecreaseDistance();
    }

    public void MaxView()
    {
        // this function keeps the camera from exceeding the maximum

        if (currentCamDist > cameraMaxDistance)
        {
            currentCamDist = cameraMaxDistance;

        }



    }
    public void MinView()
    {
        // this function keeps the camera from exceeding the minimum

        if (currentCamDist < camMinDistance)
        {
            currentCamDist = camMinDistance;
        }



    }
    public void IncreaseDistance()
    {
        if (Input.mouseScrollDelta.y == -1)
        {
            currentCamDist = currentCamDist + camChangeDistVal;
            cam.orthographicSize = currentCamDist;
        }

    }
    public void DecreaseDistance()
    {
        if (Input.mouseScrollDelta.y == 1)
        {
            currentCamDist = currentCamDist + -camChangeDistVal;
            cam.orthographicSize = currentCamDist;
        }

    }
}
