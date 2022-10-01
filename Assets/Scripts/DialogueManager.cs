using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TMP_Text currentText;
    [SerializeField] private Image currentPortrait;
    [SerializeField] private GameObject optionsContainer;
    [SerializeField] private GameObject optionButtonPrefab; 
    [SerializeField] private DialogueScriptableObject dialogueSO;
    [SerializeField] private int index = 0;

    public void updateDialogue(DialogueScriptableObject dialogue) {
        this.dialogueSO = dialogue;
    }
    public void startDialogue() {
        currentText.gameObject.SetActive(true);
        currentPortrait.gameObject.SetActive(true);
        currentPortrait.sprite = dialogueSO.dialogue.portrait;
        nextLine();
    }
    public void nextLine() {
        if (index >= dialogueSO.dialogue.text.Count) {
            // dialogue with no options should finish the dialogue after it is over
            if (dialogueSO.dialogue.options.Count == 0) {
                stopDialogue();
            }
            // otherwise show the options
            else {
                startOptions();
            }
            return;
        }
        currentText.text = dialogueSO.dialogue.text[index];
        index++;
    }
    public void stopDialogue() {
        currentText.gameObject.SetActive(false);
        currentPortrait.gameObject.SetActive(false);
        Transform[] optionButtons = optionsContainer.GetComponentsInChildren<Transform>();
        if (optionButtons != null) {
            foreach (var transform in optionsContainer.GetComponentsInChildren<Transform>())
            {
                if (transform != optionsContainer.transform) {
                    Destroy(transform.gameObject);
                }
            }
        }
        index = 0;
    }

    public void startOptions() {
        // foreach (var option in dialogueSO.dialogue.options) {
        for (int i = 0; i < dialogueSO.dialogue.options.Count; i++) {
            string option = dialogueSO.dialogue.options[i];
            DialogueScriptableObject optionToDialogue = dialogueSO.dialogue.optionsToDialogue[i];
            GameObject button = Instantiate(optionButtonPrefab, optionsContainer.transform);
            DialogueOption buttonSettings = button.GetComponent<DialogueOption>();
            buttonSettings.setText(option);
            buttonSettings.dialogueManager = this;
            buttonSettings.optionToDialogue = optionToDialogue;
        }
        // flexbox like look
        optionsContainer.GetComponent<HorizontalLayoutGroup>().childControlWidth = true;
        optionsContainer.GetComponent<HorizontalLayoutGroup>().childControlWidth = false;
    }

    public bool isDialogueActive() {
        return currentText.gameObject.activeInHierarchy;
    }

    private void Update() {
        if (isDialogueActive() && Input.GetKeyDown(KeyCode.Space)) {
            nextLine();
        }
    }
}