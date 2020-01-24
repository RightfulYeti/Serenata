using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterScript : MonoBehaviour
{
    private int iScoreCounter = 0;
    private bool[] Windows;

    // Start is called before the first frame update
    void Start()
    {
        Windows = new bool[9];
        for (int i = 0; i < Windows.Length; i++)
        {
            Windows[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetWindowOccupied(int pOccupied)
    {
        for (int i = 0; i < Windows.Length; i++)
        {
            if (i == pOccupied)
            {
                Windows[i] = true;
                print("Window " + i + " is now occupied!");
            }
            else
            {
                Windows[i] = false;
            }
        }
    }

    // returns true if occupied, false if not
    public bool GetWindowOccupied(int pWindow2Check)
    {
        if (Windows[pWindow2Check] == true)
        {
            return true;
        }
        else
            return false;
    }
}
