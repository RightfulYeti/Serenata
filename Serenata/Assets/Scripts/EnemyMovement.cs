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
    private TomatoScript TomatoScriptRef;
    public GameObject GameMasterRef;
    private GameMasterScript GameMasterScriptRef;
    public GameObject Enemy2Ref;
    public GameObject WomanRef;
    private int RandomEnemySpawn = 0;
    public int ActiveEnemySprite = 0;
    public bool ThrowingObject = false;


    // Start is called before the first frame update
    void Start()
    {
        EnemySprites = new GameObject[9];
        RandomEnemySpawn = Random.Range(0, 9);
        ActiveEnemySprite = RandomEnemySpawn;
        for (int i = 0; i < EnemySprites.Length; i++)
        {
            EnemySprites[i] = GameObject.Find("Enemy Sprite " + i);
            EnemySprites[i].SetActive(false);
        }
        InvokeRepeating("Spriter", 2.0f, 2.0f);
        Enemy2Ref = GameObject.Find("Enemy 2");
        WomanRef = GameObject.Find("Woman");
        GameMasterRef = GameObject.Find("GameMaster");
        GameMasterScriptRef = GameMasterRef.GetComponent<GameMasterScript>();
        Tomato = GameObject.Find("Tomato");
        TomatoScriptRef = Tomato.GetComponent<TomatoScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ThrowingObject)
        {
            TomatoScriptRef.CurrentlyActiveTomato = ActiveEnemySprite;
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
        if (GameMasterScriptRef.GetWindowOccupied(ActiveEnemySprite) || Enemy2Ref.GetComponent<Enemy2Movement>().ActiveEnemy2Sprite == ActiveEnemySprite || WomanRef.GetComponent<WomanMovement>().ActiveWomanSprite == ActiveEnemySprite)
        {
            ActiveEnemySprite = 0;
            EnemySprites[ActiveEnemySprite].SetActive(false);
        }
        else
        {
            for (int i = 0; i < EnemySprites.Length; i++)
            {
                if (ActiveEnemySprite == i)
                {
                    EnemySprites[i].SetActive(true);
                    GameMasterScriptRef.SetWindowOccupied(i);
                    if (!ThrowingObject)
                    {
                        ThrowObject(1);
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
            TomatoScriptRef.Active = true;
            TomatoScriptRef.CurrentlyActiveTomato = ActiveEnemySprite;
            for (int i = 0; i < TomatoScriptRef.TomatoSprites.Length; i++)
            {
                if (i == ActiveEnemySprite)
                {
                    TomatoScriptRef.TomatoSprites[i].SetActive(true);
                }
                else
                {
                    TomatoScriptRef.TomatoSprites[i].SetActive(false);
                }
            }
        }
    }
}
