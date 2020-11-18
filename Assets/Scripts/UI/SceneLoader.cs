using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public Scene scene;

    public void SwitchScene()
    {
        SceneManager.LoadScene(scene.name);
    }

}
