using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Animator transitionAnim;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isPaused && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space)))
        {
            AudioManager.Instance.Play("mousedown");
            GameManager.Instance.isPaused = false;
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }

        if (GameManager.Instance.isPaused && (Input.GetKeyDown(KeyCode.H)))
        {
            AudioManager.Instance.Play("mousedown");
            Time.timeScale = 1;
            StartCoroutine(LoadLevel(0));
        }
    }


    IEnumerator LoadLevel(int levelindex)
    {
        transitionAnim.SetTrigger("play");

        yield return new WaitForSecondsRealtime(0.5f);

        SceneManager.LoadScene(levelindex);
    }
}
