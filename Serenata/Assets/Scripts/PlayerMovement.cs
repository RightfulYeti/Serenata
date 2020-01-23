using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int LivesLeft = 3;
    public int ActivePlayerSprite = 0;
    public GameObject Sprite0;
    public GameObject Sprite1;
    public GameObject Sprite2;
    private int RandomPlayerSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        RandomPlayerSpawn = Random.Range(0, 3);

        if (RandomPlayerSpawn == 0)
        {
            Sprite0.SetActive(true);
            Sprite1.SetActive(false);
            Sprite2.SetActive(false);
        }
        else if (RandomPlayerSpawn == 1)
        {
            Sprite1.SetActive(true);
            Sprite0.SetActive(false);
            Sprite2.SetActive(false);
        }
        else
        {
            Sprite2.SetActive(true);
            Sprite1.SetActive(false);
            Sprite0.SetActive(false);
        }

        ActivePlayerSprite = RandomPlayerSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && ActivePlayerSprite != 0)
        {
            --ActivePlayerSprite;
            print(ActivePlayerSprite + "sprite is ACTIVE");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && ActivePlayerSprite != 2)
        {
            ++ActivePlayerSprite;
            print(ActivePlayerSprite + "sprite is ACTIVE");
        }

        if (ActivePlayerSprite == 0)
        {
            Sprite0.SetActive(true);
            Sprite1.SetActive(false);
            Sprite2.SetActive(false);
        }
        else if (ActivePlayerSprite == 1)
        {
            Sprite1.SetActive(true);
            Sprite0.SetActive(false);
            Sprite2.SetActive(false);
        }
        else
        {
            Sprite2.SetActive(true);
            Sprite1.SetActive(false);
            Sprite0.SetActive(false);
        }
    }
}
