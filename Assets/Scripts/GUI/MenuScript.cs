using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Text FinalScore;

    void Start()
    {

        if (!PlayerPrefs.HasKey("MaxScore"))
            PlayerPrefs.SetInt("MaxScore", 0);

        FinalScore.text = "Max Score: " + PlayerPrefs.GetInt("MaxScore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ButtonPlay()
    {
        SceneManager.LoadScene("Game");
    }
}
