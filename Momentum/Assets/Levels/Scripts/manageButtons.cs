using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Monetization;

public class manageButtons : MonoBehaviour
{
    public AudioClip buttonOnClickSound;

    string[] rougeClearSky = new string[2] { "level1_SR", "level2_SR" };
    string[] rougeRain = new string[2] { "level1_RR", "level2_RR" };

    string[] vertClearSky = new string[2] { "level1_SV", "level2_SV" };
    string[] vertRain = new string[2] { "level1_RV", "level2_RV" };

    string[] roseClearSky = new string[2] { "level1_SP", "level2_SP" };
    string[] roseRain = new string[2] { "level1_RP", "level2_RP" };

    string[] jauneClearSky = new string[2] { "level1_SY", "level2_SY" };
    string[] jauneRain = new string[2] { "level1_RY", "level2_RY" };

    /*  ADS  */
    private string adId = "3583175";

    private string videoad = "video";

    [System.Obsolete]
    private void Start()
    {
        Monetization.Initialize(adId, true);
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SFXVolume");
    }

    [System.Obsolete]
    public void Restart()
    {
        /*if (Monetization.IsReady(videoad))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(videoad) as ShowAdPlacementContent;
            if (ad != null)
            {
                ad.Show();
            }
        }*/

        StartCoroutine(Pause());

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        /*Cube Rouge*/
        if (PlayerPrefs.GetString("CubeActive") == "red" && PlayerPrefs.GetString("modeActive") == "clearSky")
        {
            SceneManager.LoadScene(rougeClearSky[Random.Range(0, 2)]);
        }

        if (PlayerPrefs.GetString("CubeActive") == "red" && PlayerPrefs.GetString("modeActive") == "rain")
        {
            SceneManager.LoadScene(rougeRain[Random.Range(0, 2)]);
        }

        /*Cube Vert*/
        if (PlayerPrefs.GetString("CubeActive") == "green" && PlayerPrefs.GetString("modeActive") == "clearSky")
        {
            SceneManager.LoadScene(vertClearSky[Random.Range(0, 2)]);
        }

        if (PlayerPrefs.GetString("CubeActive") == "green" && PlayerPrefs.GetString("modeActive") == "rain")
        {
            SceneManager.LoadScene(vertRain[Random.Range(0, 2)]);
        }

        /*Cube Rose*/
        if (PlayerPrefs.GetString("CubeActive") == "pink" && PlayerPrefs.GetString("modeActive") == "clearSky")
        {
            SceneManager.LoadScene(roseClearSky[Random.Range(0, 2)]);
        }

        if (PlayerPrefs.GetString("CubeActive") == "pink" && PlayerPrefs.GetString("modeActive") == "rain")
        {
            SceneManager.LoadScene(roseRain[Random.Range(0, 2)]);
        }

        /*Cube Jaune*/
        if (PlayerPrefs.GetString("CubeActive") == "yellow" && PlayerPrefs.GetString("modeActive") == "clearSky")
        {
            SceneManager.LoadScene(jauneClearSky[Random.Range(0, 2)]);
        }

        if (PlayerPrefs.GetString("CubeActive") == "yellow" && PlayerPrefs.GetString("modeActive") == "rain")
        {
            SceneManager.LoadScene(jauneRain[Random.Range(0, 2)]);
        }
    }

    [System.Obsolete]
    public void backToMenu()
    {
        if (Monetization.IsReady(videoad))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(videoad) as ShowAdPlacementContent;
            if (ad != null)
            {
                ad.Show();
            }
        }

        StartCoroutine(Pause());

        SceneManager.LoadScene("menu");
    }

    IEnumerator Pause()
    {
        GetComponent<AudioSource>().PlayOneShot(buttonOnClickSound);
        yield return new WaitForSeconds(1f);
    }
}
