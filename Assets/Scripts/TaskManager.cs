using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    [SerializeField] int tasksCompleted;
    [SerializeField] int tasksToComplete;
    [SerializeField] GameObject taskListPanel;
    [SerializeField] GameObject taskTextPrefab;
    public bool taskListIsVisible = false;
    
    public List<string> tasks;

    public void generateDayTasks(int day) {
        switch(day) {
            case 1:
                tasks = new List<string> {"Water the Pineapples"};
                break;
            case 2:
                tasks = new List<string> {"Water the Pineapples", "Do Math Research"};
                break;
            case 3:
                tasks = new List<string> {"Water the Pineapples", "Do Math Research", "Brew Coffee"};
                break;
        }

        foreach (var task in tasks) {
            GameObject taskText = Instantiate(taskTextPrefab, taskListPanel.transform);
            taskText.GetComponent<TMP_Text>().text = task;
        }
        GameObject hintText = Instantiate(taskTextPrefab, taskListPanel.transform);
        hintText.GetComponent<TMP_Text>().text = "(press space to close)";
        tasksToComplete = tasks.Count;
        tasksCompleted = 0;
    }

    public void completeTask() {
        tasksCompleted++;
        Debug.Log("TASK COMPLETED");
    }

    private void Update() {
        if (taskListPanel.GetComponent<Animator>().isActiveAndEnabled) {
            taskListIsVisible = true;
            if (Input.GetKeyDown(KeyCode.Space)) {
                taskListPanel.SetActive(false);
                taskListIsVisible = false;
            }
        }
    }
}
