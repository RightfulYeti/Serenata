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

    private int RandomWomanSpawn = 0;
    public int ActiveWomanSprite = 0;

    public float ActionTime = 2.0f;
    public float Period = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        WomanSprites = new GameObject[9];
        //RandomWomanSpawn = Random.Range(0, 9);
        //ActiveWomanSprite = RandomWomanSpawn;
        for (int i = 0; i < WomanSprites.Length; i++)
        {
            WomanSprites[i] = GameObject.Find("Woman Sprite " + i);
            WomanSprites[i].SetActive(false);
        }
        //for (int i = 0; i < WomanSprites.Length; i++)
        //{
        //    print(WomanSprites[i].name);
        //}
        //InvokeRepeating("Spriter", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    //void Spriter()
    //{
    //    ActiveWomanSprite = Random.Range(0, 9);

    //    for (int i = 0; i < WomanSprites.Length; i++)
    //    {
    //        if (ActiveWomanSprite == i)
    //        {
    //            WomanSprites[i].SetActive(true);
    //        }
    //        else
    //            WomanSprites[i].SetActive(false);
    //    }
    //}
}
