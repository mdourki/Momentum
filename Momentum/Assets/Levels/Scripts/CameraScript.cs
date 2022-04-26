using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Vector3 playerPostion;
    void Start()
    {
        //playerPostion = GameObject.Find("Player").transform.position;
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("musicVolume");
    }

    void Update()
    {
        /*playerPostion = GameObject.Find("Player").transform.position;
        transform.position =  new Vector3(playerPostion.x , 2.18f , playerPostion.z - 4.7f);*/
    }
}
