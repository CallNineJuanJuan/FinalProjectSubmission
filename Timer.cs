using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public GameEnding gameEnding;

    float m_Timer;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime = 30;

    void Update()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            if(gameEnding.m_IsPlayerAtExit)
            {
                Debug.Log("Player reached the exit!");
                timerText.text = "Exited!";
                remainingTime = 1;
            }
        }
        else if (remainingTime <= 0)
        {
            remainingTime = 0;
            Debug.Log("Player failed to reach the exit.");
            timerText.color = Color.red;
            EndLevel(caughtBackgroundImageCanvasGroup, true);
        }
    }

    public void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart)
    {
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            m_Timer = 0;
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
