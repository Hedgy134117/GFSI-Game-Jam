using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DayManager : MonoBehaviour
{
    public int day;
    IntroManager introManager;
    TaskManager taskManager;
    public Image fadeToBlack;

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
        fadeToBlack = GameObject.Find("FadeToBlack").GetComponent<Image>();
        introManager = GameObject.FindObjectOfType<IntroManager>();
        introManager.showDay(day);
        taskManager = GameObject.FindObjectOfType<TaskManager>();
        taskManager.generateDayTasks(day);
    }

    float t = 2;
    public bool transitioning;
    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            transitioning = true;
        }

        if (transitioning) {
            transitionToNextDay();
        }
    }

    public void transitionToNextDay() {
        if (t > 0) {
            fadeToBlack.color = new Color(fadeToBlack.color.r, fadeToBlack.color.g, fadeToBlack.color.b, 1 - t);
            t -= Time.deltaTime;
        }
        else {
            t = 2;
            transitioning = false;
            resetWorld();
        }
    }

    public void resetWorld() {
        day++;
        GameObject.FindObjectOfType<DialogueManager>().index = 0;
        SceneManager.LoadScene("Game");
    }
}
