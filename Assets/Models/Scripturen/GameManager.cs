using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Animator anim;
    private int levelIndex;

    public GameObject aud;
    public GameObject canvas;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void exitgame()
    {
        Application.Quit();

    }

    public void FadeToLevel()
    {
        canvas.SetActive(false);
        loadNextScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void loadNextScene(int scene)
    {
        levelIndex = scene;
        aud.GetComponent<SoundBoard>().PlaySound(0);
        anim.SetTrigger("FadeOut");

    }

    public void FadeComplete()
    {
        SceneManager.LoadScene(levelIndex);
    }

}
