using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuStart : MonoBehaviour {

    public GameObject panelCredit;

    public void startButton()
    {
        Debug.Log("ganti scene");
        //SceneManager.LoadScene("cobaa");
    }

    public void exitYes()
    {
        Debug.Log("keluar");
        Application.Quit();
    }

    public void creditButton()
    {
        panelCredit.SetActive(true);
        Debug.Log("ganti scene");
        //SceneManager.LoadScene("cobaa");
    }

    public void exitButton()
    {
        panelCredit.SetActive(true);
        Debug.Log("ganti scene");
        //SceneManager.LoadScene("cobaa");
    }

    public void Update()
    {
        if (panelCredit.activeSelf && Input.GetMouseButton(0))
        {
            panelCredit.SetActive(false);
        }

    }
}
