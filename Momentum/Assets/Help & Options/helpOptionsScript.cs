using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class helpOptionsScript : MonoBehaviour
{
    public Slider musicSlider;
    public Text musicVolumeTxt;

    private void Start()
    {
        musicSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("musicVolume");
        GameObject.Find("Directional Light").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("musicVolume");
        musicVolumeTxt.text = "Music Volume : " + (int) (PlayerPrefs.GetFloat("musicVolume") * 100);
    }
    public void changeMusicVolume(float volume)
    {
        /*  First way  */
        PlayerPrefs.SetFloat("musicVolume", volume);

        /*  Second way  */
        /*
         * PlayerPrefs.SetFloat("musicVolume", musicSlider.GetComponent<Slider>().value);
         */

        GameObject.Find("Directional Light").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("musicVolume");
        musicVolumeTxt.text = "Music Volume : " + (int) (PlayerPrefs.GetFloat("musicVolume") * 100);
    }

}
