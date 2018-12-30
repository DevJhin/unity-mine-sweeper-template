using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{

    public static LoadManager instance;
  
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }

    public void LoadWaitScene() {
        SceneManager.LoadScene("WaitScene");
    }


    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    /// <summary>
    /// Load Stages by StageSettings
    /// </summary>
    /// <param name="settings"></param>
    public void LoadStage(StageSettings settings)
    {
        SceneManager.LoadScene(settings.GetStageName());
    }
}
