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

    private int RandomEnemySpawn = 0;
    public int ActiveEnemySprite = 0;

    public float ActionTime = 2.0f;
    public float Period = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        EnemySprites = new GameObject[9];
        RandomEnemySpawn = Random.Range(0, 9);
        ActiveEnemySprite = RandomEnemySpawn;
        for (int i = 0; i < EnemySprites.Length; i++)
        {
            EnemySprites[i] = GameObject.Find("Enemy Sprite " + i);
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
            }
            else
                EnemySprites[i].SetActive(false);
        }
    }
}
