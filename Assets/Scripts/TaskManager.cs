using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField] int tasksCompleted;
    [SerializeField] int tasksToComplete;

    public void completeTask() {
        tasksCompleted++;
        Debug.Log("TASK COMPLETED");
    }
}
