using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathTask : MonoBehaviour
{
    [SerializeField] TaskManager taskManager;
    [SerializeField] MathTaskRandomizer mathPanel;
    bool updatedTaskManager;
    [SerializeField] GameObject ftb;

    private void Update() {
        if (mathPanel.finished) {
            ftb.SetActive(true);    
            taskManager.completeTask();
            mathPanel.gameObject.SetActive(false);
            this.enabled = false;
        }
        else if (mathPanel.gameObject.activeInHierarchy) {
            ftb.SetActive(false);
        }
    }
}
