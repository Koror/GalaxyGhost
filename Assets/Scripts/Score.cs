using UnityEngine;
using UnityEngine.UI;

public class Score : Observer
{
    public static Score Instance;
    public Text TextScore;
    [HideInInspector]
    public int SCORE = 0;
    public int EnemyCost = 5;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        if (!PlayerPrefs.HasKey("MaxScore"))
            PlayerPrefs.SetInt("MaxScore", 0);
    }

    public void UpdateScore()
    {
        TextScore.text = "Score: " + SCORE;
    }

    public override void OnNotify()
    {
        Score.Instance.SCORE += EnemyCost;
        Score.Instance.UpdateScore();
    }
}
