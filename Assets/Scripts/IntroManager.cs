using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] DialogueScriptableObject introDialogue;
    [SerializeField] DialogueScriptableObject dayTwoDialogue;
    [SerializeField] DialogueScriptableObject dayThreeDialogue;
    [SerializeField] GameObject partner;
    [SerializeField] GameObject taskList;

    public void showDay(int day) {
        DialogueScriptableObject dialogue = null;
        switch (day) {
            case 1:
                dialogue = introDialogue;
                break;
            case 2:
                dialogue = dayTwoDialogue;
                break;
            case 3:
                dialogue = dayThreeDialogue;
                break;
        }
        dialogueManager.updateDialogue(dialogue);
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
