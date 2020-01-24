using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterScript : MonoBehaviour
{
    private int iScoreCounter = 0;
    private bool[] Windows;
    public int ObjectLocation;
    public int PlayerLocation;
    public int PlayerLives = 3;

    // Start is called before the first frame update
    void Start()
    {
        Windows = new bool[9];
        for (int i = 0; i < Windows.Length; i++)
        {
            Windows[i] = false;
        }
        InvokeRepeating("printer", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerLocation + 9 == ObjectLocation)
        {
            PlayerLives--;
            print(PlayerLives);
            PlayerLocation = 0;
            ObjectLocation = 0;
        }

        if (PlayerLives == 3)
        {
            GameObject.Find("Lives").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("Lives").transform.GetChild(1).gameObject.SetActive(true);
            GameObject.Find("Lives").transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (PlayerLives == 2)
        {
            GameObject.Find("Lives").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("Lives").transform.GetChild(1).gameObject.SetActive(true);
            GameObject.Find("Lives").transform.GetChild(2).gameObject.SetActive(false);
        }
        else if (PlayerLives == 1)
        {
            GameObject.Find("Lives").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("Lives").transform.GetChild(1).gameObject.SetActive(false);
            GameObject.Find("Lives").transform.GetChild(2).gameObject.SetActive(false);
        }
        else
        {
            GameObject.Find("Lives").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.Find("Lives").transform.GetChild(1).gameObject.SetActive(false);
            GameObject.Find("Lives").transform.GetChild(2).gameObject.SetActive(false);
        }

        if (PlayerLives <= 0)
        {
            print("You're soaked!");
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
    void printer()
    {
    }
    public void SetWindowOccupied(int pOccupied)
    {
        for (int i = 0; i < Windows.Length; i++)
        {
            if (i == pOccupied)
            {
                Windows[i] = true;
            }
            else
            {
                Windows[i] = false;
            }
        }
    }

    // returns true if occupied, false if not
    public bool GetWindowOccupied(int pWindow2Check)
    {
        if (Windows[pWindow2Check] == true)
        {
            return true;
        }
        else
            return false;
    }
}
