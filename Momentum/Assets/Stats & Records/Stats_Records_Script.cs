using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats_Records_Script : MonoBehaviour
{
    public Text totalScoreTxt;
    public Text totalCoinsTxt;
    public Text totalPlayTimeTxt;
    public Text totalDistanceTxt;
    public Text highScoreTxt;
    public Text mostCoinsTxt;
    public Text longestPlayTimeTxt;
    public Text longestDistanceTxt;
    string longerTime;
    string totalTime;

    void Update()
    {
        longerTime = string.Format("{0:00}:{1:00}:{2:00}", PlayerPrefs.GetInt("highHours"), PlayerPrefs.GetInt("highMinutes"), PlayerPrefs.GetInt("highSeconds"));
        totalTime = string.Format("{0:00}:{1:00}:{2:00}", PlayerPrefs.GetInt("totalHours"), PlayerPrefs.GetInt("totalMinutes"), PlayerPrefs.GetInt("totalSeconds"));

        totalScoreTxt.text = "Total Score : " + PlayerPrefs.GetInt("totalScore");
        totalCoinsTxt.text = "Total Coins : " + PlayerPrefs.GetInt("totalCoins");
        totalPlayTimeTxt.text = "Total Play Time : " + totalTime;
        totalDistanceTxt.text = "Total Distance : " + PlayerPrefs.GetInt("totalDistance") + "m";

        highScoreTxt.text = "High Score : " + PlayerPrefs.GetInt("highScore");
        mostCoinsTxt.text = "Most Coins : " + PlayerPrefs.GetInt("mostCoins");
        longestPlayTimeTxt.text = "Longest Play Time : " + longerTime;
        longestDistanceTxt.text = "Longest Distance : " + PlayerPrefs.GetInt("longestDistance") + "m";
    }

    public void reset()
    {
        PlayerPrefs.SetInt("highScore",0);
        PlayerPrefs.SetInt("mostCoins",0);
        PlayerPrefs.SetInt("highHours", 0);
        PlayerPrefs.SetInt("highMinutes", 0);
        PlayerPrefs.SetInt("highSeconds", 0);
        PlayerPrefs.SetInt("longestDistance",0);
    }
}
