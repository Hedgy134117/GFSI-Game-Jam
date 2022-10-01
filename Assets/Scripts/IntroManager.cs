using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] DialogueScriptableObject introDialogue;
    [SerializeField] GameObject partner;
    [SerializeField] GameObject taskList;

    private void Start() {
        dialogueManager.updateDialogue(introDialogue);
        dialogueManager.startDialogue();
    }

    private void FixedUpdate() {
        if (!dialogueManager.isDialogueActive()) {
            partner.GetComponent<PartnerBehavior>().movingToPosition = true;
            showTaskList();
            gameObject.SetActive(false);
        }
    }

    private void showTaskList() {
        taskList.GetComponent<Animator>().enabled = true;
    }
}
