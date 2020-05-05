using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { set; get; }

    public GameObject mainMenu;
    public GameObject hostMenu;
    public GameObject connectMenu;

    private void Start()
    {
        Instance = this;
        hostMenu.SetActive(false);
        connectMenu.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }

    public void ConnectButton()
    {
        Debug.Log("Connect");
        mainMenu.SetActive(false);
        connectMenu.SetActive(true);
    }
    public void HostButton()
    {
        Debug.Log("Host");
        mainMenu.SetActive(false);
        hostMenu.SetActive(true);
    }
    public void ConnectToServerButton()
    {
        Debug.Log("Connect to server");
    }
    public void BackButton()
    {
        mainMenu.SetActive(true);
        connectMenu.SetActive(false);
        hostMenu.SetActive(false);
    }
}
