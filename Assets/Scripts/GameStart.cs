using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStart : MonoBehaviour
{
    public int countdown = 3;
    public TextMeshProUGUI countdownText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Countdown");
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSecondsRealtime(1);
        countdown--;
        countdownText.text = countdown.ToString();
        if (countdown == 0)
        {
            countdownText.gameObject.SetActive(false);
            GameManager.Instance.StartGame();
            GameManager.Instance.isStarted = true;
        }
        else
        {
            StartCoroutine("Countdown");            
        }

    }
}
