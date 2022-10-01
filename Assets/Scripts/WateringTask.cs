using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringTask : MonoBehaviour
{
    [SerializeField] TaskManager taskManager;
    [SerializeField] WateringTaskObject[] pineapples;
    [SerializeField] bool finishedTask = false;
    [SerializeField] bool updatedTaskManager = false;
    private void Start() {
        pineapples = GetComponentsInChildren<WateringTaskObject>();
    }
    private void Update() {
        if (finishedTask && updatedTaskManager == false) {
            taskManager.completeTask();
            updatedTaskManager = true;
        }
        else if (!finishedTask && updatedTaskManager == false) {
            foreach (WateringTaskObject pineapple in pineapples) {
                if (!pineapple.isWatered) {
                    finishedTask = false;
                    break;
                }
                else {
                    finishedTask = true;
                }
            }
        }
    }
}
