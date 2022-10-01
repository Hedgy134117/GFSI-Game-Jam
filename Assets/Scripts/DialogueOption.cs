using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueOption : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    public DialogueManager dialogueManager;
    public DialogueScriptableObject optionToDialogue;

    public void setText(string text) {
        this.text.text = text;
    } 

    public void click() {
        dialogueManager.stopDialogue();
        dialogueManager.updateDialogue(optionToDialogue);
        dialogueManager.startDialogue();
    }
}
