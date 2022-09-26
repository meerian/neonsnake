using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI countdownText;

    public int countdown = 3;

    private void Start()
    {
        StartCoroutine("Timer");
    }

    private void ChangeColor()
    {
        GameManager.Instance.ChangeColor();
        UIManager.Instance.ChangeColor();
    }

    IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(1);
        countdown--;
        countdownText.text = countdown.ToString();
        if (countdown == 0)
        {
            ChangeColor();
            countdown = 3;
        }
        StartCoroutine("Timer");
    }
}
