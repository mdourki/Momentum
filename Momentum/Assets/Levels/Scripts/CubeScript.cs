using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;


public class CubeScript : MonoBehaviour
{
    public float score;
    public Text scoreTxt;
    public Time playTime;
    public GameObject panelFilleClose;
    public Text panelFilleCloseCurrentTimeSurvivedTxt;
    public float gameTimer;

    

    private void Start()
    {
        GameObject.Find("PanelMère").GetComponent<Image>().enabled = false;
        panelFilleClose.SetActive(false);

        if(gameObject.transform.position == GameObject.Find("PositionDepart").transform.position)
        {
            GameObject.Find("Camera").GetComponent<AudioSource>().enabled = true;
            gameTimer = 0f;
        }
    }
    void Update()
    {
        gameTimer += Time.deltaTime;

        /*Convert Time*/
        int seconds = (int)gameTimer % 60;
        int minutes = (int)(gameTimer / 60) % 60;
        int hours = (int)(gameTimer / 3600) % 24;

        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");

        gameObject.GetComponent<Rigidbody>().AddForce(0, 0, 800 * Time.deltaTime);

        if(v > 0)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(0, 0, 300 * Time.deltaTime);
        }

        if (v < 0)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(0, 0, -300 * Time.deltaTime);
        }

        if (h > 0)
        {
            transform.Translate(Vector3.right * 0.2f);
        }

        if (h < 0)
        {
            transform.Translate(Vector3.left * 0.2f);
        }
        score += 0.1f;
        scoreTxt.text = "" + (int) score;

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            panelFilleCloseCurrentTimeSurvivedTxt.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
            GameObject.Find("PanelMère").GetComponent<Image>().enabled = true;
            panelFilleClose.SetActive(true);
        }

    }

    public void fermerPause()
    {
        GameObject.Find("PanelMère").GetComponent<Image>().enabled = false;
        panelFilleClose.SetActive(false);
    }

}