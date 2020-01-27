using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMasterScript : MonoBehaviour
{
    private int iScoreCounter = 0;
    private bool[] Windows;
    public AudioClip[] LalalaSounds;
    public AudioClip[] PanSounds;
    public AudioClip[] TomatoSounds;
    public int ObjectLocation;
    public string ObjectType = "";
    public int Object2Location;
    public int PlayerLocation;
    public int WomanLocation;
    public int PlayerLives;
    Text ScoreTextBox;
    public bool UpNotPressed = true;

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
            int Selection = Random.Range(0, 4);
            if (ObjectType == "Pan")
            {
                GameObject.Find("Tomato Audio Source").GetComponent<AudioSource>().clip = PanSounds[Selection];
                GameObject.Find("Tomato Audio Source").GetComponent<AudioSource>().Play();
            }
            else if (ObjectType == "Tomato")
            {
                GameObject.Find("Water Audio Source").GetComponent<AudioSource>().clip = TomatoSounds[Selection];
                GameObject.Find("Water Audio Source").GetComponent<AudioSource>().Play();
            }
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

        if (Input.GetKey("up") && (WomanLocation == PlayerLocation || WomanLocation == PlayerLocation + 3 || WomanLocation == PlayerLocation + 6) && UpNotPressed)
        {
            UpNotPressed = false;
            iScoreCounter += 1;
            FindObjectOfType<Canvas>().GetComponentInChildren<Text>().text = iScoreCounter.ToString();
            int LalalaChoice = Random.Range(0, 6);
            GameObject.Find("Singing Audio Source").GetComponent<AudioSource>().clip = LalalaSounds[LalalaChoice];
            GameObject.Find("Singing Audio Source").GetComponent<AudioSource>().Play();
        }

        if (!GameObject.Find("Singing Audio Source").GetComponent<AudioSource>().isPlaying)
        {
            UpNotPressed = true;
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
