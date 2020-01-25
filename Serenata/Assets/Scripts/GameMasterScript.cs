using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMasterScript : MonoBehaviour
{
    private int iScoreCounter = 0;
    private bool[] Windows;
    public int ObjectLocation;
    public int Object2Location;
    public int PlayerLocation;
    public int WomanLocation;
    public int PlayerLives;
    Text ScoreTextBox;

    // Start is called before the first frame update
    void Start()
    {
        Windows = new bool[9];
        for (int i = 0; i < Windows.Length; i++)
        {
            Windows[i] = false;
        }
    }

    private IEnumerator Blink(float waitTime)
    {
        float endTime = Time.time + waitTime;
        while (Time.time < endTime)
        {
            GameObject Player = GameObject.Find("Player");
            Player.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            Player.SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerLocation + 9 == ObjectLocation)
        {
            PlayerLives--;
            PlayerLocation = 0;
            ObjectLocation = 0;
            StartCoroutine("Blink", 1.0f);
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
            FindObjectOfType<Data>().PlayerEndScore = iScoreCounter;
            SceneManager.LoadScene("End");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && (WomanLocation == PlayerLocation || WomanLocation == PlayerLocation + 3 || WomanLocation == PlayerLocation + 6))
        {
            iScoreCounter += 1;
            FindObjectOfType<Canvas>().GetComponentInChildren<Text>().text = iScoreCounter.ToString();
        }
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

    public void SetWindowNotOccupied(int pOccupied)
    {
        for (int i = 0; i < Windows.Length; i++)
        {
            if (i == pOccupied)
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
