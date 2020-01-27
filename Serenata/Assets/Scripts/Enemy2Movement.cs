using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Movement : MonoBehaviour
{
    public GameObject[] Enemy2Sprites;
    public GameObject Sprite0;
    public GameObject Sprite1;
    public GameObject Sprite2;
    public GameObject Sprite3;
    public GameObject Sprite4;
    public GameObject Sprite5;
    public GameObject Sprite6;
    public GameObject Sprite7;
    public GameObject Sprite8;

    public GameObject FryingPan;
    private PanScript FryingPanScript;
    public GameObject GameMasterRef;
    private GameMasterScript GameMasterScriptRef;
    public GameObject EnemyRef;

    private int RandomEnemy2Spawn = 0;
    public int ActiveEnemy2Sprite = 0;
    public bool ThrowingObject = false;

    // Start is called before the first frame update
    void Start()
    {
        Enemy2Sprites = new GameObject[9];
        RandomEnemy2Spawn = Random.Range(0, 9);
        ActiveEnemy2Sprite = RandomEnemy2Spawn;
        for (int i = 0; i < Enemy2Sprites.Length; i++)
        {
            Enemy2Sprites[i] = GameObject.Find("Enemy 2 Sprite " + i);
            Enemy2Sprites[i].SetActive(false);
        }
        InvokeRepeating("Spriter", 2.0f, 2.0f);
        EnemyRef = GameObject.Find("Enemy");
        GameMasterRef = GameObject.Find("GameMaster");
        GameMasterScriptRef = GameMasterRef.GetComponent<GameMasterScript>();
        FryingPan = GameObject.Find("FryingPan");
        FryingPanScript = FryingPan.GetComponent<PanScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ThrowingObject)
        {
            FryingPanScript.CurrentlyActivePan = ActiveEnemy2Sprite;
        }

        for (int i = 0; i < Enemy2Sprites.Length; i++)
        {
            if (Enemy2Sprites[i].name != "Enemy 2 Sprite " + ActiveEnemy2Sprite.ToString())
            {
                Enemy2Sprites[i].SetActive(false);
            }
        }
    }

    void Spriter()
    {
        ActiveEnemy2Sprite = Random.Range(0, 9);
        if (GameMasterScriptRef.GetWindowOccupied(ActiveEnemy2Sprite) || EnemyRef.GetComponent<EnemyMovement>().ActiveEnemySprite == ActiveEnemy2Sprite)
        {
            ActiveEnemy2Sprite = 1;
            Enemy2Sprites[ActiveEnemy2Sprite].SetActive(false);
        }
        else
        {
            for (int i = 0; i < Enemy2Sprites.Length; i++)
            {
                if (ActiveEnemy2Sprite == i)
                {
                    Enemy2Sprites[i].SetActive(true);
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
            FryingPanScript.Active = true;
            FryingPanScript.CurrentlyActivePan = ActiveEnemy2Sprite;
            for (int i = 0; i < FryingPanScript.PanSprites.Length; i++)
            {
                if (i == ActiveEnemy2Sprite)
                {
                    FryingPanScript.PanSprites[i].SetActive(true);
                }
                else
                {
                    FryingPanScript.PanSprites[i].SetActive(false);
                }
            }
        }
    }
}
