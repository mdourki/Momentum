using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Monetization;

public class buttonsManager : MonoBehaviour
{
    public Animator panelShopAnimator;
    public Animator panelHelpOptionsAnimator;
    public Animator panelStatsRecorsAnimator;
    int shopActive;
    int helpOptionsActive;
    int statsRecorsActive;
    public AudioClip buttonOnClickSound;
    public Text bankTxt;

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
        //PlayerPrefs.SetInt("bank", 0);
        //PlayerPrefs.SetInt("totalCoins", 0);
        //PlayerPrefs.SetInt("greenSelled", 0);
        //PlayerPrefs.SetString("CubeActive", "red");
        //PlayerPrefs.SetInt("totalHours", 0);
        //PlayerPrefs.SetInt("totalMinutes", 0);
        //PlayerPrefs.SetInt("totalSeconds", 0);
        //PlayerPrefs.SetInt("totalDistance", 0);
        //PlayerPrefs.SetInt("totalScore", 0);
        //PlayerPrefs.SetString("modeActive" , "clearSky");

        if(PlayerPrefs.GetInt("initialized") == 0)
        {
            PlayerPrefs.SetString("CubeActive", "red");
            PlayerPrefs.SetString("modeActive", "clearSky");
            PlayerPrefs.SetInt(("initialized"), 1);
        }
    }

    private void Update()
    {
        bankTxt.text = "Bank : " + PlayerPrefs.GetInt("bank");
    }

    [System.Obsolete]
    public void start()
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

        /*Cube Rouge*/
        if (PlayerPrefs.GetString("CubeActive") == "red" && PlayerPrefs.GetString("modeActive") == "clearSky")
        {
            SceneManager.LoadScene(rougeClearSky[Random.Range(0,2)]);
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

    public void shop()
    {
        shopActive++;

        GetComponent<AudioSource>().PlayOneShot(buttonOnClickSound);

        if (shopActive % 2 != 0)
        {
            panelShopAnimator.SetTrigger("Active");

            if(helpOptionsActive % 2 != 0)
            {
                helpOptionsActive++;
                panelHelpOptionsAnimator.SetTrigger("Inactive");
            }

            if (statsRecorsActive % 2 != 0)
            {
                statsRecorsActive++;
                panelStatsRecorsAnimator.SetTrigger("Inactive");
            }
        }

        if (shopActive % 2 == 0)
        {
            panelShopAnimator.SetTrigger("Inactive");
        }
    }

    public void stats_Records()
    {
        statsRecorsActive++;

        GetComponent<AudioSource>().PlayOneShot(buttonOnClickSound);

        if (statsRecorsActive % 2 != 0)
        {
            panelStatsRecorsAnimator.SetTrigger("Active");

            if (shopActive % 2 != 0)
            {
                shopActive++;
                panelShopAnimator.SetTrigger("Inactive");
            }

            if (helpOptionsActive % 2 != 0)
            {
                helpOptionsActive++;
                panelHelpOptionsAnimator.SetTrigger("Inactive");
            }
        }

        if (statsRecorsActive % 2 == 0)
        {
            panelStatsRecorsAnimator.SetTrigger("Inactive");
        }
    }

    public void help_Options()
    {
        helpOptionsActive++;

        GetComponent<AudioSource>().PlayOneShot(buttonOnClickSound);

        if (helpOptionsActive % 2 != 0)
        {
            panelHelpOptionsAnimator.SetTrigger("Active");

            if(shopActive % 2 != 0)
            {
                shopActive++;
                panelShopAnimator.SetTrigger("Inactive");
            }

            if (statsRecorsActive % 2 != 0)
            {
                statsRecorsActive++;
                panelStatsRecorsAnimator.SetTrigger("Inactive");
            }
        }

        if (helpOptionsActive % 2 == 0)
        {
            panelHelpOptionsAnimator.SetTrigger("Inactive");
        }
    }

    public void exit()
    {
        StartCoroutine(Pause());

        Application.Quit();
    }

    IEnumerator Pause()
    {
        GetComponent<AudioSource>().PlayOneShot(buttonOnClickSound);
        yield return new WaitForSeconds(1f);
    }
}
