﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject[] EnemySprites;
    public GameObject Sprite0;
    public GameObject Sprite1;
    public GameObject Sprite2;
    public GameObject Sprite3;
    public GameObject Sprite4;
    public GameObject Sprite5;
    public GameObject Sprite6;
    public GameObject Sprite7;
    public GameObject Sprite8;

    public GameObject Tomato;
    public GameObject Water;

    private int RandomEnemySpawn = 0;
    public int ActiveEnemySprite = 0;

    public float ActionTime = 2.0f;
    public float Period = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        Tomato = GameObject.Find("Tomato");
        //GameObject.Find("Water").GetComponent<TomatoScript>()
        EnemySprites = new GameObject[9];
        RandomEnemySpawn = Random.Range(0, 9);
        ActiveEnemySprite = RandomEnemySpawn;
        for (int i = 0; i < EnemySprites.Length; i++)
        {
            EnemySprites[i] = GameObject.Find("Enemy Sprite " + i);
            EnemySprites[i].SetActive(false);
        }
        for (int i = 0; i < EnemySprites.Length; i++)
        {
            print(EnemySprites[i].name);
        }
        InvokeRepeating("Spriter", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Spriter()
    {
        ActiveEnemySprite = Random.Range(0, 9);

        for (int i = 0; i < EnemySprites.Length; i++)
        {
            if (ActiveEnemySprite == i)
            {
                EnemySprites[i].SetActive(true);
                //ThrowObject(Random.Range(0, 2));
                //ThrowObject(1);
            }
            else
                EnemySprites[i].SetActive(false);
        }
    }

    void ThrowObject(int pObjectType)
    {
        if (pObjectType == 1)
        {
            Tomato.GetComponent<TomatoScript>().Active = true;
            Tomato.GetComponent<TomatoScript>().ActiveTomatoSprite = ActiveEnemySprite;
            //for (int i = 0; i < Tomato.GetComponent<TomatoScript>().TomatoSprites.Length; i++)
            //{
            //    if (i == ActiveEnemySprite)
            //    {
            //        Tomato.GetComponent<TomatoScript>().TomatoSprites[i].SetActive(true);
            //    }
            //    else
            //    {
            //        Tomato.GetComponent<TomatoScript>().TomatoSprites[i].SetActive(false);
            //    }
            //}
        }
        else
        {
            //GameObject.Find("Water");
        }
    }
}
