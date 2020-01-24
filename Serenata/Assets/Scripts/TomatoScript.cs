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

    public int ActiveTomatoSprite = 0;
    public bool Active = false;
    private float ActionTime = 5.0f;
    public float PeriodTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        TomatoSprites = new GameObject[9];
        for (int i = 0; i < TomatoSprites.Length; i++)
        {
            TomatoSprites[i] = GameObject.Find("Tomato Sprite " + i);
            TomatoSprites[i].SetActive(false);
        }

        InvokeRepeating("Spriter", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Active)
        {
            for (int i = 0; i < TomatoSprites.Length; i++)
            {
                if (i == ActiveTomatoSprite)
                {
                    TomatoSprites[i].SetActive(true);
                }
                else
                    TomatoSprites[i].SetActive(false);
            }
            if (Time.time > ActionTime)
            {
                ActionTime += PeriodTime;
                TomatoSprites[ActiveTomatoSprite].SetActive(false);
                TomatoSprites[ActiveTomatoSprite+3].SetActive(true);
            }
        }
    }

    void Spriter()
    {
        for (int i = 0; i < TomatoSprites.Length; i++)
        {
            if (i == ActiveTomatoSprite)
            {
                TomatoSprites[i].SetActive(true);
            }
            else
                TomatoSprites[i].SetActive(false);
        }
    }
}