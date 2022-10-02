using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathTask : MonoBehaviour
{
    [SerializeField] TaskManager taskManager;
    [SerializeField] MathTaskRandomizer mathPanel;
    bool updatedTaskManager;

    private void Update() {
        if (mathPanel.finished) {
            taskManager.completeTask();
            mathPanel.gameObject.SetActive(false);
            this.enabled = false;
        }
    }
}
