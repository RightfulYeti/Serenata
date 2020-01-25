using System.Collections;
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

    public GameObject GameMasterRef;
    public GameObject Enemy2Ref;

    private int RandomEnemySpawn = 0;
    public int ActiveEnemySprite = 0;
    public bool ThrowingObject = false;

    // Start is called before the first frame update
    void Start()
    {
        Tomato = GameObject.Find("Tomato");
        EnemySprites = new GameObject[9];
        RandomEnemySpawn = Random.Range(0, 9);
        ActiveEnemySprite = RandomEnemySpawn;
        for (int i = 0; i < EnemySprites.Length; i++)
        {
            EnemySprites[i] = GameObject.Find("Enemy Sprite " + i);
            EnemySprites[i].SetActive(false);
        }
        InvokeRepeating("Spriter", 1.0f, 2.0f);
        Enemy2Ref = GameObject.Find("Enemy 2");
        GameMasterRef = GameObject.Find("GameMaster");
    }

    // Update is called once per frame
    void Update()
    {
        if (!ThrowingObject)
        {
            GameObject.Find("Tomato").GetComponent<TomatoScript>().CurrentlyActiveTomato = ActiveEnemySprite;
        }

        for (int i = 0; i < EnemySprites.Length; i++)
        {
            if (EnemySprites[i].name != "Enemy Sprite " + ActiveEnemySprite.ToString())
            {
                EnemySprites[i].SetActive(false);
            }
        }
    }

    void Spriter()
    {
        ActiveEnemySprite = Random.Range(0, 9);
        if (GameMasterRef.GetComponent<GameMasterScript>().GetWindowOccupied(ActiveEnemySprite))
        {
            EnemySprites[ActiveEnemySprite].SetActive(false);
        }
        else
        {
            for (int i = 0; i < EnemySprites.Length; i++)
            {
                if (ActiveEnemySprite == i)
                {
                    EnemySprites[i].SetActive(true);
                    GameMasterRef.GetComponent<GameMasterScript>().SetWindowOccupied(i);
                    if (!ThrowingObject)
                    {
                        ThrowObject(1);
                    }
                    else
                    {
                        EnemySprites[i].SetActive(false);
                        GameMasterRef.GetComponent<GameMasterScript>().SetWindowNotOccupied(i);
                    }
                }
            }
        }
    }

    void ThrowObject(int pObjectType)
    {
        if (pObjectType == 1)
        {
            ThrowingObject = true;
            Tomato.GetComponent<TomatoScript>().Active = true;
            Tomato.GetComponent<TomatoScript>().CurrentlyActiveTomato = ActiveEnemySprite;
            for (int i = 0; i < Tomato.GetComponent<TomatoScript>().TomatoSprites.Length; i++)
            {
                if (i == ActiveEnemySprite)
                {
                    Tomato.GetComponent<TomatoScript>().TomatoSprites[i].SetActive(true);
                }
                else
                {
                    Tomato.GetComponent<TomatoScript>().TomatoSprites[i].SetActive(false);
                }
            }
        }
    }
}
