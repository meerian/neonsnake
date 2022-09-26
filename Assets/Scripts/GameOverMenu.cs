using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI scoreNum;
    public Animator transitionAnim;

    // Start is called before the first frame update
    void Start()
    {
        scoreNum.text = GameManager.Instance.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.Instance.Play("mousedown");
            StartCoroutine(LoadLevel(1));
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            AudioManager.Instance.Play("mousedown");
            StartCoroutine(LoadLevel(0));
        }
    }

    IEnumerator LoadLevel(int levelindex)
    {
        Time.timeScale = 1;
        transitionAnim.SetTrigger("play");

        yield return new WaitForSecondsRealtime(0.5f);

        SceneManager.LoadScene(levelindex);
    }
}
