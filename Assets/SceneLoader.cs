using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public string SceneName;
    public void LoadDynamicScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);
    }
}
