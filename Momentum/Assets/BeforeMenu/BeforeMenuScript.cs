using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeforeMenuScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject canvas;

    void Start()
    {
        Player.SetActive(false);
        canvas.SetActive(false);
        StartCoroutine(loadSceneMenu());  
    }

    IEnumerator loadSceneMenu()
    {
        yield return new WaitForSeconds(3f);
        Player.SetActive(true);
        canvas.SetActive(true);
        yield return new WaitForSeconds(3f);
        Player.SetActive(false);
        canvas.SetActive(false);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("menu");
    }
}
