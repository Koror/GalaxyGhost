using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultController : MonoBehaviour
{
    public Text FinalScore;
    public GameObject ResultPanel;

    public void Activate()
    {
        if (PlayerPrefs.GetInt("MaxScore") < Score.Instance.SCORE)
            PlayerPrefs.SetInt("MaxScore", Score.Instance.SCORE);
        ResultPanel.SetActive(true);
        FinalScore.text = "Score: " + Score.Instance.SCORE + "\n" + "Max Score: " + PlayerPrefs.GetInt("MaxScore");
    }
    public void ButtonPlay()
    {
        SceneManager.LoadScene("Game");   
    }

}
