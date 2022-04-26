using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GroundCollision : MonoBehaviour
{
    public GameObject panelFille;
    public AudioClip loseSound;
    float score;
    float gameTimer;
    public Text panelFilleTimeSurvivedTxt;

    private void Start()
    {
        GameObject.Find("PanelMère").GetComponent<Image>().enabled = false;
        panelFille.SetActive(false);
    }

    private void OnCollisionExit(Collision collision)
    {
        score = GameObject.Find("Player").GetComponent<CubeScript>().score;

        if (collision.gameObject.name == "Player")
        {
            GameObject.Find("Camera").GetComponent<AudioSource>().enabled = false;

            gameTimer = GameObject.Find("Player").GetComponent<CubeScript>().gameTimer;

            GetComponent<AudioSource>().PlayOneShot(loseSound);
            collision.gameObject.GetComponent<CubeScript>().enabled = false;
            GameObject.Find("Player").GetComponent<CubeScript>().enabled = false;
            GameObject.Find("PanelMère").GetComponent<Image>().enabled = true;
            panelFille.SetActive(true);

            /*Most Coins*/
            if (GameObject.Find("Player").GetComponent<PlayerTrriger>().coinsCounter > PlayerPrefs.GetInt("mostCoins"))
            {
                PlayerPrefs.SetInt("mostCoins", GameObject.Find("Player").GetComponent<PlayerTrriger>().coinsCounter);
            }

            /*High Score*/
            if ((int)score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", (int)score);
            }

            /*Longest Distance*/
            if ((int)GameObject.Find("Player").transform.position.z > PlayerPrefs.GetInt("longestDistance"))
            {
                PlayerPrefs.SetInt("longestDistance", (int)GameObject.Find("Player").transform.position.z);
            }

            /*Total Score*/
            PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("totalScore") + (int)score);

            /*Total Distance*/
            PlayerPrefs.SetInt("totalDistance", PlayerPrefs.GetInt("totalDistance") + (int)GameObject.Find("Player").transform.position.z);

            /*Convert Time*/
            int seconds = (int)gameTimer % 60;
            int minutes = (int)(gameTimer / 60) % 60;
            int hours = (int)(gameTimer / 3600) % 24;

            /*Longest Play Time*/
            LongestPlayTime(seconds, minutes, hours);

            /*Total Time*/
            addTimeToTotal(seconds, minutes, hours);

            /*PanelFille*/
            panelFilleTimeSurvivedTxt.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        }
    }

    void LongestPlayTime(int s, int m, int h)
    {
        if (h > PlayerPrefs.GetInt("highHours"))
        {
            PlayerPrefs.SetInt("highHours", h);
            PlayerPrefs.SetInt("highMinutes", m);
            PlayerPrefs.SetInt("highSeconds", s);
        }

        if (m > PlayerPrefs.GetInt("highMinutes"))
        {
            PlayerPrefs.SetInt("highHours", h);
            PlayerPrefs.SetInt("highMinutes", m);
            PlayerPrefs.SetInt("highSeconds", s);
        }

        if (s > PlayerPrefs.GetInt("highSeconds"))
        {
            PlayerPrefs.SetInt("highHours", h);
            PlayerPrefs.SetInt("highMinutes", m);
            PlayerPrefs.SetInt("highSeconds", s);
        }
    }

    void addTimeToTotal(int s, int m, int h)
    {
        /*Seconds*/
        if (PlayerPrefs.GetInt("totalSeconds") + s > 59)
        {
            PlayerPrefs.SetInt("totalSeconds", PlayerPrefs.GetInt("totalSeconds") + s - 60);

            if (PlayerPrefs.GetInt("totalMinutes") + 1 > 59)
            {
                PlayerPrefs.SetInt("totalMinutes", PlayerPrefs.GetInt("totalMinutes") + 1 - 60);

                PlayerPrefs.SetInt("totalHours", PlayerPrefs.GetInt("totalHours") + 1);
            }
            else
            {
                PlayerPrefs.SetInt("totalMinutes", PlayerPrefs.GetInt("totalMinutes") + 1);
            }
        }
        else
        {
            PlayerPrefs.SetInt("totalSeconds", PlayerPrefs.GetInt("totalSeconds") + s);
        }

        /*Minutes*/
        if (PlayerPrefs.GetInt("totalMinutes") + m > 59)
        {
            PlayerPrefs.SetInt("totalMinutes", PlayerPrefs.GetInt("totalMinutes") + m - 60);

            PlayerPrefs.SetInt("totalHours", PlayerPrefs.GetInt("totalHours") + 1);
        }
        else
        {
            PlayerPrefs.SetInt("totalMinutes", PlayerPrefs.GetInt("totalMinutes") + m);
        }

        /*Hours*/
        PlayerPrefs.SetInt("totalHours", PlayerPrefs.GetInt("totalHours") + h);
    }
}
