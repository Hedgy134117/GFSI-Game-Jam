using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    public List<string> text;
    public Sprite portrait;
    public List<string> options;
    public List<DialogueScriptableObject> optionsToDialogue;
    public DialogueScriptableObject nextDialogue;
    public bool goToNextDay;
    public bool endGame;
}
