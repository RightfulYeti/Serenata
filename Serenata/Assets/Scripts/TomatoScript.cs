using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoScript : MonoBehaviour
{
    public GameObject[] TomatoSprites;
    public GameObject Sprite0;
    public GameObject Sprite1;
    public GameObject Sprite2;
    public GameObject Sprite3;
    public GameObject Sprite4;
    public GameObject Sprite5;
    public GameObject Sprite6;
    public GameObject Sprite7;
    public GameObject Sprite8;
    public GameObject Sprite9;
    public GameObject Sprite10;
    public GameObject Sprite11;

    public GameObject GameMasterRef;
 

    public int CurrentlyActiveTomato = 0;
    public float PomidoryTimer = 2.0f;
    public bool Active = false;
    private float ElapsedTime = 0f;
    private float ElapsedTime2 = 0f;

    // Start is called before the first frame update
    void Start()
    {
        TomatoSprites = new GameObject[12];
        for (int i = 0; i < TomatoSprites.Length; i++)
        {
            TomatoSprites[i] = GameObject.Find("Tomato Sprite " + i);
            TomatoSprites[i].SetActive(false);
        }
        GameMasterRef = GameObject.Find("GameMaster");
}

    // Update is called once per frame
    void Update()
    {
        ElapsedTime += Time.deltaTime;
        ElapsedTime2 += Time.deltaTime;

        if (!Active)
        {
            ElapsedTime = 0;
            CurrentlyActiveTomato = GameObject.Find("Enemy").GetComponent<EnemyMovement>().ActiveEnemySprite;
        }

        if(ElapsedTime2 >= 5.0f)
        {
            ElapsedTime2 = ElapsedTime2 % 1f;
            PomidoryTimer -= 0.1f;
        }

        if (Active && ElapsedTime >= PomidoryTimer && CurrentlyActiveTomato <= 8)
        {
            ElapsedTime = ElapsedTime % 1f;
            TomatoSprites[CurrentlyActiveTomato].SetActive(false);
            TomatoSprites[CurrentlyActiveTomato + 3].SetActive(true);
            CurrentlyActiveTomato += 3;
            GameMasterRef.GetComponent<GameMasterScript>().ObjectLocation = CurrentlyActiveTomato;
        }
        else if (CurrentlyActiveTomato > 8)
        {
            for (int i = 0; i < TomatoSprites.Length; i++)
            {
                TomatoSprites[i].SetActive(false);
            }
            CurrentlyActiveTomato = 0;
            ElapsedTime = 0f;
            Active = false;
            GameObject.Find("Enemy").GetComponent<EnemyMovement>().ThrowingObject = false;
            GameMasterRef.GetComponent<GameMasterScript>().ObjectLocation = CurrentlyActiveTomato;
            GameMasterRef.GetComponent<GameMasterScript>().ObjectType = 2;
        }
    }
}