using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public void SetScene(int scene)
    {
        StartCoroutine(FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, scene));
    }

    public void Replay(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitToMenu(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
