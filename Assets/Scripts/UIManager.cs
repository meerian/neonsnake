using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Experimental.Rendering.Universal;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI scoreNum;

    public TextMeshProUGUI colorText;
    public TextMeshProUGUI correctText;
    public GameObject addScore;
    public GameObject pauseMenu;
    public GameObject gameoverMenu;
    public Light2D curLight;

    private Color32 green = new Color32(0, 180, 0, 100);
    private Color32 orange = new Color32(255, 128, 0, 100);
    private Color32 blue = new Color32(0, 128, 255, 100);
    private Color32 pink = new Color32(255, 75, 255, 100);

    void Start()
    {
        Instance = this;
        ChangeColor();
    }

    // Update is called once per frame
    void Update()
    {
        scoreNum.text = GameManager.Instance.score.ToString();
        colorText.text = GameManager.Instance.color;
        correctText.text = GameManager.Instance.correct;
        if (!GameManager.Instance.isPaused && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space)))
        {
            AudioManager.Instance.Play("mousedown");
            GameManager.Instance.isPaused = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }

    public void GameOver()
    {
        GameManager.Instance.isPaused = true;
        Time.timeScale = 0;
        gameoverMenu.SetActive(true);
    }

    public void StartGame()
    {
        colorText.gameObject.SetActive(true);
        correctText.gameObject.SetActive(true);
    }

    public void AddScore(int bonus)
    {
        addScore.GetComponent<ScoreAdd>().ShowScore(bonus);
    }

    public void ChangeColor()
    {
        Color32 color;
        if (GameManager.Instance.correctAns < 4)
        {
            switch (GameManager.Instance.color)
            {
                case "green":
                    GameManager.Instance.wordcolor = "green";
                    color = green;
                    break;
                case "orange":
                    GameManager.Instance.wordcolor = "orange";
                    color = orange;
                    break;
                case "blue":
                    GameManager.Instance.wordcolor = "blue";
                    color = blue;
                    break;
                case "pink":
                    GameManager.Instance.wordcolor = "pink";
                    color = pink;
                    break;
                default:
                    color = green;
                    break;
            }    
        }
        else
        {
            int rand = Random.Range(0,4);
            switch (rand)
            {
                case 0:
                    GameManager.Instance.wordcolor = "green";
                    color = green;
                    break;
                case 1:
                    GameManager.Instance.wordcolor = "orange";
                    color = orange;
                    break;
                case 2:
                    GameManager.Instance.wordcolor = "blue";
                    color = blue;
                    break;
                case 3:
                    GameManager.Instance.wordcolor = "pink";
                    color = pink;
                    break;
                default:
                    color = green;
                    break;
            }   
        }
        curLight.color = color;
        scoreNum.color = color;
        colorText.color = color;
        correctText.color = color;

        float x = Mathf.Round(Random.Range(-16, 16));
        float y = Mathf.Round(Random.Range(-10, 10));
        float size = Mathf.Round(Random.Range(2, 11));
        correctText.transform.position = new Vector3(x, y, 0.0f);
        correctText.fontSize = size;

        x = Mathf.Round(Random.Range(-16, 16));
        y = Mathf.Round(Random.Range(-10, 10));
        size = Mathf.Round(Random.Range(2, 11));
        colorText.transform.position = new Vector3(x, y, 0.0f);
        colorText.fontSize = size;
    }
}
