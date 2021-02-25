using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMPro.TextMeshProUGUI timer;
    public GameObject gamePausedText;

    public int timeToFinish = 120;
    int timeToEnd;
    bool paused = false;


    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        timeToEnd = timeToFinish;
        timer.text = timeToEnd.ToString();
        InvokeRepeating(nameof(Stopper), 1f, 1f);

        gamePausedText.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void Stopper()
    {
        timeToEnd--;
        timer.text = timeToEnd.ToString();
        Debug.Log("Time left: " + timeToEnd + " s");
        
        if (timeToEnd <= 0)
        {
            EndGame(false);
        }
    }

    void PauseGame()
    {
        Debug.Log("Game paused");
        gamePausedText.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    void ResumeGame()
    {
        Debug.Log("Resume game");
        gamePausedText.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    void EndGame(bool win) 
    {
        CancelInvoke(nameof(Stopper));

        if(win)
        {
            Debug.Log("You won!!!");
        }
        else
        {
            Debug.Log("You lost!!!");
        }

    }
    
    
}
