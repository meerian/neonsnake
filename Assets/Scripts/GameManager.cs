using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score;
    public int correctAns;
    public float prevTime;

    public string color = "green";
    public string wordcolor = "green";
    public string correct = "text";
    public string snakecolor = "green";

    public GameObject[] foods;
    public GameObject[] walls;
    public GameObject snake;
    public bool isPaused = false;
    public bool isStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void ChangeColor()
    {
        prevTime = Time.time;
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            correct = "text";
        }
        else
        {
            correct = "color";
        }
        snake.GetComponent<SnakeController>().ChangeColor();
        switch (color)
        {
            case "green":
                color = "orange";
                break;
            case "orange":
                color = "blue";
                break;
            case "blue":
                color = "pink";
                break;
            case "pink":
                color = "green";
                break;
        }
        UIManager.Instance.ChangeColor();
        foreach (var wall in walls)
        {
            wall.GetComponent<WallController>().ChangeColor();
        }
    }

    public void StartGame()
    {
        UIManager.Instance.StartGame();
        RandomColorandPosition();
        foreach (var food in foods)
        {
            food.SetActive(true);
        }
        prevTime = Time.time;
    }

    public void RandomColorandPosition()
    {
        ChangeColor();
        foreach (var food in foods)
        {
            food.GetComponent<Food>().RandomizePosition();
        }
    }

    public void AddScore()
    {
        int bonus = 100 + (int)(100 * Mathf.Max((5 - (Time.time - prevTime)) / 5, 0));
        UIManager.Instance.AddScore(bonus);
        score += bonus;
        correctAns++;
    }
}
