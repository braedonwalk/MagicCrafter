using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    static bool isGamePaused = false;

    [SerializeField] GameObject spellBookUI;

    private void Start() {
        spellBookUI.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    void resume()
    {
        spellBookUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void pause()
    {
        spellBookUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public bool getIsPaused()
    {
        return isGamePaused;
    }
}
