using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenuButton : MonoBehaviour
{
    [SerializeField] string gameScene;
    public void start() {
        SceneManager.LoadScene(gameScene);
    }

    public void quit() {
        Application.Quit();
    }
}
