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

    // Start is called before the first frame update
    void Start()
    {
        TomatoSprites = new GameObject[9];
        for (int i = 0; i < TomatoSprites.Length; i++)
        {
            TomatoSprites[i] = GameObject.Find("Tomato Sprite " + i);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}