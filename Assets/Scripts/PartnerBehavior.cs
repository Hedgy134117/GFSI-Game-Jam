using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerBehavior : MonoBehaviour
{
    [SerializeField] int speed;
    public bool movingToPosition = false;
    
    [SerializeField] bool isBeingTouched;
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] DayManager dayManager;
    [SerializeField] TaskManager taskManager;

    [Header("Dialogues")]
    [SerializeField] DialogueScriptableObject notFinishedYet;
    [SerializeField] DialogueScriptableObject day1;
    [SerializeField] DialogueScriptableObject day2;
    [SerializeField] DialogueScriptableObject day3;
    
    private void Start() {
        dialogueManager = GameObject.FindObjectOfType<DialogueManager>();
        taskManager = GameObject.FindObjectOfType<TaskManager>();
        dayManager = GameObject.FindObjectOfType<DayManager>();
    }

    void moveToPosition() {
        transform.position = Vector3.MoveTowards(
            transform.position, 
            new Vector3(0, 0, -1f), 
            speed * Time.deltaTime
        );
    }

    private void Update() {
        if (movingToPosition) {
            moveToPosition();
        }
        if (isBeingTouched) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                if (!taskManager.isFinished()) {
                    dialogueManager.updateDialogue(notFinishedYet);
                }
                else {
                    switch (dayManager.day) {
                        case 1:
                            dialogueManager.updateDialogue(day1);
                            break;
                        case 2:
                            dialogueManager.updateDialogue(day2);
                            break;
                        case 3:
                            dialogueManager.updateDialogue(day3);
                            break;
                    }
                }
                dialogueManager.startDialogue();
                isBeingTouched = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        isBeingTouched = true;
    }
    private void OnCollisionExit2D(Collision2D other) {
        isBeingTouched = false;
    }
}
