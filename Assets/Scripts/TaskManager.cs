using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField] int tasksCompleted;
    [SerializeField] int tasksToComplete;
    [SerializeField] GameObject taskListPanel;
    public bool taskListIsVisible = false;

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
