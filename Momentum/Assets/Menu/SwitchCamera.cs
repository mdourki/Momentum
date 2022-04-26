using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{

    public GameObject cameraToLoad;
    public GameObject posIniCameraToLOad;

    public void callNextCamera()
    {

        if(gameObject.name == "Camera1")
        {
            cameraToLoad.gameObject.SetActive(true);
            gameObject.SetActive(false);
            cameraToLoad.gameObject.transform.position = posIniCameraToLOad.gameObject.transform.position;
        }

        if(gameObject.name == "Camera2")
        {
            cameraToLoad.gameObject.SetActive(true);
            gameObject.SetActive(false);
            cameraToLoad.gameObject.transform.position = posIniCameraToLOad.gameObject.transform.position;
        }
    }
}
