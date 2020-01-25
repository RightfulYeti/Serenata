using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanScript : MonoBehaviour
{
    public GameObject[] PanSprites;
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

    public int CurrentlyActivePan = 0;
    public float PanTimer = 2.0f;
    public bool Active = false;
    private float ElapsedTime = 0f;
    private float ElapsedTime2 = 0f;

    // Start is called before the first frame update
    void Start()
    {
        PanSprites = new GameObject[12];
        for (int i = 0; i < PanSprites.Length; i++)
        {
            PanSprites[i] = GameObject.Find("Frying Pan Sprite " + i);
            PanSprites[i].SetActive(false);
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
            CurrentlyActivePan = GameObject.Find("Enemy 2").GetComponent<Enemy2Movement>().ActiveEnemy2Sprite;
        }

        if (ElapsedTime2 >= 5.0f)
        {
            ElapsedTime2 = ElapsedTime2 % 1f;
            PanTimer -= 0.1f;
        }

        if (Active && ElapsedTime >= PanTimer && CurrentlyActivePan <= 8)
        {
            ElapsedTime = ElapsedTime % 1f;
            PanSprites[CurrentlyActivePan].SetActive(false);
            PanSprites[CurrentlyActivePan + 3].SetActive(true);
            CurrentlyActivePan += 3;
            GameMasterRef.GetComponent<GameMasterScript>().ObjectLocation = CurrentlyActivePan;
        }
        else if (CurrentlyActivePan > 8)
        {
            for (int i = 0; i < PanSprites.Length; i++)
            {
                PanSprites[i].SetActive(false);
            }
            CurrentlyActivePan = 0;
            ElapsedTime = 0f;
            Active = false;
            GameObject.Find("Enemy 2").GetComponent<Enemy2Movement>().ThrowingObject = false;
            GameMasterRef.GetComponent<GameMasterScript>().ObjectLocation = 0;
        }
    }
}
