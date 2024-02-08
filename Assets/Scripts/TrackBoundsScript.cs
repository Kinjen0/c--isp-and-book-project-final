using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackBoundsScript : MonoBehaviour
{
    public void OnTriggerExit(Collider collision)
    {
       // Debug.Log("exiting play area");
        int lastScene = SceneManager.sceneCountInBuildSettings; // Unity Docs https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.html
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(lastScene - 1);
        }
    }
}
