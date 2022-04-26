using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public Text cubeRougeEquippedTxt;
    public Text cubeVertEquippedTxt;
    public Text cubeRoseEquippedTxt;
    public Text cubeJauneEquippedTxt;

    public Text clearSkyEquippedTxt;
    public Text rainEquippedTxt;

    public Text priceCubeGreenTxt;
    public Text priceCubePinkTxt;
    public Text priceCubeYellowTxt;

    public Text pricerainTxt;

    public AudioClip buttonOnClickSound;

    void Start()
    {
        
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("greenSelled") == 1)
        {
            priceCubeGreenTxt.gameObject.SetActive(false);
        }

        if (PlayerPrefs.GetInt("pinkSelled") == 1)
        {
            priceCubePinkTxt.gameObject.SetActive(false);
        }

        if (PlayerPrefs.GetInt("yellowSelled") == 1)
        {
            priceCubeYellowTxt.gameObject.SetActive(false);
        }

        if (PlayerPrefs.GetInt("rainSelled") == 1)
        {
            pricerainTxt.gameObject.SetActive(false);
        }

            /*                 Cubes                 */

            /*Cube Rouge*/
            if (PlayerPrefs.GetString("CubeActive") == "red")
        {
            cubeRougeEquippedTxt.GetComponent<Text>().enabled = true;
            cubeVertEquippedTxt.GetComponent<Text>().enabled = false;
            cubeRoseEquippedTxt.GetComponent<Text>().enabled = false;
            cubeJauneEquippedTxt.GetComponent<Text>().enabled = false;
        }

        /*Cube Vert*/
        if (PlayerPrefs.GetString("CubeActive") == "green")
        {
            priceCubeGreenTxt.gameObject.SetActive(false);
            cubeRougeEquippedTxt.GetComponent<Text>().enabled = false;
            cubeVertEquippedTxt.GetComponent<Text>().enabled = true;
            cubeRoseEquippedTxt.GetComponent<Text>().enabled = false;
            cubeJauneEquippedTxt.GetComponent<Text>().enabled = false;
        }

        /*Cube Rose*/
        if (PlayerPrefs.GetString("CubeActive") == "pink")
        {
            priceCubePinkTxt.gameObject.SetActive(false);
            cubeRougeEquippedTxt.GetComponent<Text>().enabled = false;
            cubeVertEquippedTxt.GetComponent<Text>().enabled = false;
            cubeRoseEquippedTxt.GetComponent<Text>().enabled = true;
            cubeJauneEquippedTxt.GetComponent<Text>().enabled = false;
        }

        /*Cube Jaune*/
        if (PlayerPrefs.GetString("CubeActive") == "yellow")
        {
            priceCubeYellowTxt.gameObject.SetActive(false);
            cubeRougeEquippedTxt.GetComponent<Text>().enabled = false;
            cubeVertEquippedTxt.GetComponent<Text>().enabled = false;
            cubeRoseEquippedTxt.GetComponent<Text>().enabled = false;
            cubeJauneEquippedTxt.GetComponent<Text>().enabled = true;
        }

        /*                 Fin Cubes                 */

        /*                 Modes                 */
        if (PlayerPrefs.GetString("modeActive") == "clearSky")
        {
            clearSkyEquippedTxt.GetComponent<Text>().enabled = true;
            rainEquippedTxt.GetComponent<Text>().enabled = false;
        }

        if (PlayerPrefs.GetString("modeActive") == "rain")
        {
            pricerainTxt.gameObject.SetActive(false);
            clearSkyEquippedTxt.GetComponent<Text>().enabled = false;
            rainEquippedTxt.GetComponent<Text>().enabled = true;
        }
        /*                 Fin Modes                 */
    }

    /*  The next methodes will called when we click at the button corresponding  */
    public void cubeRouge()
    {
        PlayerPrefs.SetString("CubeActive", "red");
        GetComponent<AudioSource>().PlayOneShot(buttonOnClickSound);
    }

    public void cubeVert()
    {
        if(PlayerPrefs.GetInt("greenSelled") == 1)
        {
            PlayerPrefs.SetString("CubeActive", "green");
            GetComponent<AudioSource>().PlayOneShot(buttonOnClickSound);
        }

        if (PlayerPrefs.GetInt("greenSelled") == 0)
        {
            if(PlayerPrefs.GetInt("bank") >= 500)
            {
                PlayerPrefs.SetInt("bank", (PlayerPrefs.GetInt("bank") - 500));
                PlayerPrefs.SetInt("greenSelled", 1);
                priceCubeGreenTxt.gameObject.SetActive(false);
                PlayerPrefs.SetString("CubeActive", "green");
            }
            GetComponent<AudioSource>().PlayOneShot(buttonOnClickSound);
        }
    }

    public void cubeRose()
    {
        if (PlayerPrefs.GetInt("pinkSelled") == 1)
        {
            PlayerPrefs.SetString("CubeActive", "pink");
            GetComponent<AudioSource>().PlayOneShot(buttonOnClickSound);
        }

        if (PlayerPrefs.GetInt("pinkSelled") == 0)
        {
            if (PlayerPrefs.GetInt("bank") >= 500)
            {
                PlayerPrefs.SetInt("bank", (PlayerPrefs.GetInt("bank") - 500));
                PlayerPrefs.SetInt("pinkSelled", 1);
                priceCubePinkTxt.gameObject.SetActive(false);
                PlayerPrefs.SetString("CubeActive", "pink");
            }
            GetComponent<AudioSource>().PlayOneShot(buttonOnClickSound);
        }
    }

    public void cubeJaune()
    {
        if (PlayerPrefs.GetInt("yellowSelled") == 1)
        {
            PlayerPrefs.SetString("CubeActive", "yellow");
            GetComponent<AudioSource>().PlayOneShot(buttonOnClickSound);
        }

        if (PlayerPrefs.GetInt("yellowSelled") == 0)
        {
            if (PlayerPrefs.GetInt("bank") >= 500)
            {
                PlayerPrefs.SetInt("bank", (PlayerPrefs.GetInt("bank") - 500));
                PlayerPrefs.SetInt("yellowSelled", 1);
                priceCubeYellowTxt.gameObject.SetActive(false);
                PlayerPrefs.SetString("CubeActive", "yellow");
            }
            GetComponent<AudioSource>().PlayOneShot(buttonOnClickSound);
        }
    }

    public void clearSky()
    {
        PlayerPrefs.SetString("modeActive", "clearSky");
        GetComponent<AudioSource>().PlayOneShot(buttonOnClickSound);
    }

    public void rain()
    {
        if (PlayerPrefs.GetInt("rainSelled") == 1)
        {
            PlayerPrefs.SetString("modeActive", "rain");
            GetComponent<AudioSource>().PlayOneShot(buttonOnClickSound);
        }

        if (PlayerPrefs.GetInt("rainSelled") == 0)
        {
            if (PlayerPrefs.GetInt("bank") >= 500)
            {
                PlayerPrefs.SetInt("bank", (PlayerPrefs.GetInt("bank") - 500));
                PlayerPrefs.SetInt("rainSelled", 1);
                pricerainTxt.gameObject.SetActive(false);
                PlayerPrefs.SetString("modeActive", "rain");
            }
            GetComponent<AudioSource>().PlayOneShot(buttonOnClickSound);
        }
    }
}
