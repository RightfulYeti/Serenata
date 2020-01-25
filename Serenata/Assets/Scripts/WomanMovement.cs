using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanMovement : MonoBehaviour
{
    public GameObject[] WomanSprites;
    public GameObject Sprite0;
    public GameObject Sprite1;
    public GameObject Sprite2;
    public GameObject Sprite3;
    public GameObject Sprite4;
    public GameObject Sprite5;
    public GameObject Sprite6;
    public GameObject Sprite7;
    public GameObject Sprite8;

    public GameObject GameMasterRef;

    private int RandomWomanSpawn = 0;
    public int ActiveWomanSprite = 0;
    private int ActiveCounter = 0;
    public float ActionTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        WomanSprites = new GameObject[9];
        RandomWomanSpawn = Random.Range(0, 9);
        ActiveWomanSprite = RandomWomanSpawn;
        for (int i = 0; i < WomanSprites.Length; i++)
        {
            WomanSprites[i] = GameObject.Find("Woman Sprite " + i);
            WomanSprites[i].SetActive(false);
        }
        InvokeRepeating("Spriter", 1.0f, 2.0f);
        GameMasterRef = GameObject.Find("GameMaster");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < WomanSprites.Length; i++)
        {
            if (!WomanSprites[i].activeSelf)
            {
                ActiveCounter++;
            }
        }

        if (ActiveCounter == 9)
        {
            GameMasterRef.GetComponent<GameMasterScript>().WomanLocation = -1;
        }
    }

    void Spriter()
    {
        ActiveWomanSprite = Random.Range(0, 9);
        if (GameMasterRef.GetComponent<GameMasterScript>().GetWindowOccupied(ActiveWomanSprite))
        {
            WomanSprites[ActiveWomanSprite].SetActive(false);
            GameMasterRef.GetComponent<GameMasterScript>().WomanLocation = 0;
        }
        else
        {
            for (int i = 0; i < WomanSprites.Length; i++)
            {
                if (ActiveWomanSprite == i)
                {
                    WomanSprites[i].SetActive(true);
                    GameMasterRef.GetComponent<GameMasterScript>().SetWindowOccupied(i);
                    GameMasterRef.GetComponent<GameMasterScript>().WomanLocation = ActiveWomanSprite;
                }
                else
                {
                    WomanSprites[i].SetActive(false);
                    GameMasterRef.GetComponent<GameMasterScript>().SetWindowNotOccupied(i);
                } 
            }
        }
    }
}
