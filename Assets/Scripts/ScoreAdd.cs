using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreAdd : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Animator anim;

    private Color32 green = new Color32(0, 180, 0, 100);
    private Color32 orange = new Color32(255, 128, 0, 100);
    private Color32 blue = new Color32(0, 128, 255, 100);
    private Color32 pink = new Color32(255, 75, 255, 100);

    public void ShowScore(int score)
    {
        //scoreText.fontSize = 2;
        scoreText.text = score.ToString();
        switch (GameManager.Instance.snakecolor)
            {
                case "green":
                    scoreText.color = green;
                    break;
                case "orange":
                    scoreText.color = orange;
                    break;
                case "blue":
                    scoreText.color = blue;
                    break;
                case "pink":
                    scoreText.color = pink;
                    break;
            }
        anim.SetTrigger("show");
    }

    public void RemoveText()
    {
        scoreText.text = "";
    }

}
