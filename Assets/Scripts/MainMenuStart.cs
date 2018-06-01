using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuStart : MonoBehaviour {

    public GameObject panelCredit;
    public GameObject panelExit;

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

    public void exitNo()
    {
        Debug.Log("gajadi");
        panelExit.SetActive(false);
    }

    public void creditButton()
    {
        panelCredit.SetActive(true);
        Debug.Log("credit");
        //SceneManager.LoadScene("cobaa");
    }

    public void exitButton()
    {
        panelExit.SetActive(true);
        Debug.Log("nanya");
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
