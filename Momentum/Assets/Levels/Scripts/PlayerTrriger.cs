using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrriger : MonoBehaviour
{
    public AudioClip coinSound;
    public int coinsCounter;
    private void Start()
    {
        coinsCounter = 0;
        //GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("musicVolume");
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if(other.gameObject.tag == "coin")
        {
            GetComponent<AudioSource>().PlayOneShot(coinSound);
            coinsCounter++;
            PlayerPrefs.SetInt("bank", (PlayerPrefs.GetInt("bank") + 1));
            PlayerPrefs.SetInt("totalCoins", (PlayerPrefs.GetInt("totalCoins") + 1));
        }
    }
}
