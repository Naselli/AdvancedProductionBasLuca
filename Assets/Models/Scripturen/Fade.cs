using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(CountdownTimer))]

public class Fade : MonoBehaviour
{
    private CountdownTimer countdownTimer;
    private Text textUI;
    int fadeAwayCount = 1;
    public Text thanks;
    private int switcher = 0;

    void Awake()
    {
        countdownTimer = GetComponent<CountdownTimer>();
        textUI = GetComponent<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        countdownTimer.ResetTimer(3);
    }

    // Update is called once per frame
    void Update()
    {
        switch (switcher)
        {
            case 0:
                thanks.text = " ";
                break;
            case 1:
                thanks.text = "Thank you for playing!";
                break;
            case 2:
                thanks.text = "An Experience Game Made by:";
                break;
            case 3:
                thanks.text = "Luca Naselli";
                break;
            case 4:
                thanks.text = "Chelsey Severi:";
                break;
            case 5:
                thanks.text = "Andrea Grimaldi";
                break;
            case 6:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            default:
                thanks.text = "An Experience Game Made by:";
                break;
        }


        if (fadeAwayCount % 2 != 0)
        {
            float alphaRemaining = countdownTimer.GetProportionTimeRemaining();
            fadeAway(alphaRemaining);
            if (alphaRemaining < 0f)
            {
                fadeAwayCount += 1;
                switcher += 1;
            }
        }
        else
        {
            float increaseAlpha = countdownTimer.IncreaseAlpha();
            fadeIn(increaseAlpha);
            if (increaseAlpha > 1f)
            {
                fadeAwayCount += 1;
                countdownTimer.ResetTimer(5);
            }

        }
    }

    void fadeAway(float alphaRemaining)
    {
        print(alphaRemaining);
        Color c = textUI.color;
        c.a = alphaRemaining;
        textUI.color = c;
    }
    void fadeIn(float increaseAlpha)
    {
        print(increaseAlpha);
        Color c = textUI.color;
        c.a = increaseAlpha;
        textUI.color = c;
    }
}
