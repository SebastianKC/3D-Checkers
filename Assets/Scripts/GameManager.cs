﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { set; get; }

    public GameObject mainMenu;
    public GameObject hostMenu;
    public GameObject connectMenu;

    public GameObject serverPrefab;
    public GameObject clientPrefab;

    public InputField nameInput;

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
        try
        {
            Server s = Instantiate(serverPrefab).GetComponent<Server>();
            s.Init();

            Client c = Instantiate(clientPrefab).GetComponent<Client>();
            c.clientName = nameInput.text;
            if (c.clientName == "")
                c.clientName = "Host";
            c.ConnectToServer("127.0.0.1", 6321);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

        Debug.Log("Host");
        mainMenu.SetActive(false);
        hostMenu.SetActive(true);
    }
    public void ConnectToServerButton()
    {
        Debug.Log("Connect to server");
        string hostAddress = GameObject.Find("HostInput").GetComponent<InputField>().text;
        if (hostAddress == "")
            hostAddress = "127.0.0.1";

        try
        {
            Client c = Instantiate(clientPrefab).GetComponent<Client>();
            c.clientName = nameInput.text;
            if (c.clientName == "")
                c.clientName = "Client";
            c.ConnectToServer(hostAddress, 6321);
            connectMenu.SetActive(false);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
    public void BackButton()
    {
        mainMenu.SetActive(true);
        connectMenu.SetActive(false);
        hostMenu.SetActive(false);

        Server s = FindObjectOfType<Server>();
        if (s != null)
            Destroy(s.gameObject);
                
        Client c = FindObjectOfType<Client>();
        if (c != null)
            Destroy(s.gameObject);
    }
}
