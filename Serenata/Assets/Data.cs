using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Data : MonoBehaviour
{
    public float PlayerEndScore = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        //FindObjectOfType<EndScript>().FinalScore = PlayerEndScore;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "End")
        {
            FindObjectOfType<EndScript>().FinalScore = PlayerEndScore;
        }
    }
}
