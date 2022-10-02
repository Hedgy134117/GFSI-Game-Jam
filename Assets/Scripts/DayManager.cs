using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DayManager : MonoBehaviour
{
    public int day;
    IntroManager introManager;
    TaskManager taskManager;

    public static DayManager instance;

    private void Start() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this) {
            Destroy(gameObject);
            return;
        }
        showDialogue(new Scene(), LoadSceneMode.Single);
        SceneManager.sceneLoaded += showDialogue;
    }

    

    public void showDialogue(Scene scene, LoadSceneMode mode) {
        introManager = GameObject.FindObjectOfType<IntroManager>();
        introManager.showDay(day);
        taskManager = GameObject.FindObjectOfType<TaskManager>();
        taskManager.generateDayTasks(day);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            nextDay();
        }
    }

    public void nextDay() {
        resetWorld();
    }

    public void resetWorld() {
        day++;
        SceneManager.LoadScene("Game");
    }
}
