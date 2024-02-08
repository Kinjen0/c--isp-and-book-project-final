using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScrypt : MonoBehaviour
{
    public int nextScene;

    public void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void quit()
    {
        Application.Quit();
    }
}
