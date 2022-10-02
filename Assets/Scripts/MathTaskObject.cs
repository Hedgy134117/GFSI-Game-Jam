using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathTaskObject : MonoBehaviour
{
    [SerializeField] GameObject mathPanel;

    [SerializeField] bool isBeingTouched;

    private void Update() {
        if (isBeingTouched) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                mathPanel.SetActive(true);
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
