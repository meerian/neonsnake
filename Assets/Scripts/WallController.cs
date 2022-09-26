using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    private Color32 green = new Color32(0, 180, 0, 50);
    private Color32 orange = new Color32(255, 128, 0, 50);
    private Color32 blue = new Color32(0, 128, 255, 50);
    private Color32 pink = new Color32(255, 75, 255, 50);

    public SpriteRenderer sr;

    private void Start()
    {
        //sr = GetComponent<SpriteRenderer>();
    }

    public void ChangeColor()
    {
       if (GameManager.Instance.correctAns < 4)
        {
            switch (GameManager.Instance.color)
            {
                case "green":
                    sr.color = green;
                    break;
                case "orange":
                    sr.color = orange;
                    break;
                case "blue":
                    sr.color = blue;
                    break;
                case "pink":
                    sr.color = pink;
                    break;
                default:
                    sr.color = green;
                    break;
            }    
        }
        else
        {
            int rand = Random.Range(0,4);
            switch (rand)
            {
                case 0:
                    sr.color = green;
                    break;
                case 1:
                    sr.color = orange;
                    break;
                case 2:
                    sr.color = blue;
                    break;
                case 3:
                    sr.color = pink;
                    break;
                default:
                    sr.color = green;
                    break;
            }   
        }
    }
}
