using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject[] selections;
    public GameObject[] panels;
    public int curSelected;
    public Animator transitionAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowSelection(int i)
    {
        AudioManager.Instance.Play("mouseover");
        selections[curSelected].SetActive(false);
        panels[curSelected].SetActive(false);
        selections[i].SetActive(true);
        panels[i].SetActive(true);
        curSelected = i;
    }

    public void StartGame()
    {
        AudioManager.Instance.Play("mousedown");
        StartCoroutine(LoadLevel(1));
    }

    public void QuitGame()
    {
        AudioManager.Instance.Play("mousedown");
        //Application.Quit();
    }

    IEnumerator LoadLevel(int levelindex)
    {
        transitionAnim.SetTrigger("play");

        yield return new WaitForSecondsRealtime(0.5f);

        SceneManager.LoadScene(levelindex);
    }
}
