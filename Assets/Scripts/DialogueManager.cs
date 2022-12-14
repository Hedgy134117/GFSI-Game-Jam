using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject textBackground;
    [SerializeField] private TMP_Text currentText;
    [SerializeField] private Image currentPortrait;
    [SerializeField] private GameObject optionsContainer;
    [SerializeField] private GameObject optionButtonPrefab; 
    [SerializeField] private DialogueScriptableObject dialogueSO;
    [SerializeField] public int index = 0;
    [SerializeField] DayManager dayManager;

    public void updateDialogue(DialogueScriptableObject dialogue) {
        this.dialogueSO = dialogue;
    }
    public void startDialogue() {
        index = 0;
        textBackground.SetActive(true);
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
                // only start options if they don't exist yet
                if (optionsContainer.transform.childCount == 0) {
                    startOptions();
                }
            }
            if (dialogueSO.dialogue.nextDialogue != null) {
                stopDialogue();
                updateDialogue(dialogueSO.dialogue.nextDialogue);
                startDialogue();
            }
            if (dialogueSO.dialogue.endGame) {
                SceneManager.LoadScene("TitleScene");
            }
            return;
        }
        currentText.text = dialogueSO.dialogue.text[index];
        index++;
    }
    public void stopDialogue() {
        textBackground.SetActive(false);
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
        if (dialogueSO.dialogue.goToNextDay) {
            dayManager = GameObject.FindObjectOfType<DayManager>();
            dayManager.transitioning = true;
        }
    }

    public void startOptions() {
        GameObject.Find("FadeToBlack").SetActive(false);
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
        optionsContainer.GetComponent<HorizontalLayoutGroup>().childControlHeight = true;
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
