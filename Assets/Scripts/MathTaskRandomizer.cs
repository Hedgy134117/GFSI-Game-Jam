using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MathTaskRandomizer : MonoBehaviour
{
    [SerializeField] TMP_Text[] equationTexts;
    [SerializeField] string[] equations = new string[3];
    [SerializeField] int[] answers = new int[3];
    [SerializeField] TMP_InputField[] inputFields;
    [SerializeField] string[] inputs = new string[3];
    public bool finished;

    private void Start() {
        int a, b;
        a = Random.Range(1, 100);
        b = Random.Range(1, 100);
        equations[0] = a + " + " + b;
        answers[0] = a + b;
        a = Random.Range(1, 100);
        b = Random.Range(1, 100);
        equations[1] = a + " - " + b;
        answers[1] = a - b;
        a = Random.Range(1, 20);
        b = Random.Range(1, 10);
        equations[2] = a + " * " + b;
        answers[2] = a * b;

        equationTexts[0].text = equations[0];
        equationTexts[1].text = equations[1];
        equationTexts[2].text = equations[2];
    }

    public void changeInput() {
        for (int i = 0; i < inputFields.Length; i++) {
            inputs[i] = inputFields[i].text;
        }
        
        checkInputs();
        checkIfFinished();
    }

    public void checkInputs() {
        for (int i = 0; i < inputs.Length; i++) {
            int num;
            bool _ = int.TryParse(inputs[i], out num);
            if (_) {
                if (num == answers[i]) {
                    equationTexts[i].gameObject.SetActive(false);
                }
            }
        }
    }

    public void checkIfFinished() {
        for (int i = 0; i < equationTexts.Length; i++) {
            if (equationTexts[i].gameObject.activeInHierarchy) {
                finished = false;
                return;
            }
        }
        finished = true;
    }
}
