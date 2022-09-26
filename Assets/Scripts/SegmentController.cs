using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentController : MonoBehaviour
{
    public Sprite orange;
    public Sprite green;
    public Sprite blue;
    public Sprite pink;
    public Sprite white;

    public SpriteRenderer sr;
    public string color;

    void Start()
    {
        color = GameManager.Instance.snakecolor;
        UpdateColor();
    }

    public void NextMove(GameObject other)
    {
        transform.position = other.transform.position;
        if (other.GetComponent<SegmentController>() != null)
        {
            this.color = other.GetComponent<SegmentController>().color;
            UpdateColor();
        }
        else
        {
            this.color = other.GetComponent<SnakeController>().color;
            UpdateColor();
        }
    }

    private void UpdateColor()
    {
       switch (color)
        {
            case "green":
                sr.sprite = green;
                break;
            case "orange":
                sr.sprite = orange;
                break;
            case "blue":
                sr.sprite = blue;
                break;
            case "pink":
                sr.sprite = pink;
                break;
            case "white":
                sr.sprite = white;
                break;
        }

        if (GameManager.Instance.color == color)
        {
            sr.color = new Color(1f,1f,1f,1f);
        }
        else
        {
            sr.color = new Color(1f,1f,1f,0.5f);
        }
    }
}
