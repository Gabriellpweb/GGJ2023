using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void SceneChange(string nextSceneName, string currentSceneName)
    {
        SceneManager.LoadSceneAsync(nextSceneName, LoadSceneMode.Single);
        //SceneManager.UnloadScene(currentSceneName);
    }
}
