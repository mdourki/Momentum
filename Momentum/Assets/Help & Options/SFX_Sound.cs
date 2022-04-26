using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFX_Sound : MonoBehaviour
{
    //public Button start;

    public Slider musicSFX;
    public Text musicSFXTxt;

    private void Start()
    {
        musicSFX.GetComponent<Slider>().value = PlayerPrefs.GetFloat("SFXVolume");
        GameObject.Find("Canvas").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SFXVolume");
        musicSFXTxt.text = "SFX Volume : " + (int)(PlayerPrefs.GetFloat("SFXVolume") * 100);
    }

    private void Update()
    {
        
    }
    public void changeSFXVolume(float volume)
    {
        /*  First way  */
        PlayerPrefs.SetFloat("SFXVolume", volume);

        /*  Second way  */
        /*
         * PlayerPrefs.SetFloat("SFXVolume", musicSFX.GetComponent<Slider>().value);
         */

        GameObject.Find("Canvas").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SFXVolume");
        GameObject.Find("PanelShop").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SFXVolume");
        musicSFXTxt.text = "SFX Volume : " + (int)(PlayerPrefs.GetFloat("SFXVolume") * 100);
    }
}
