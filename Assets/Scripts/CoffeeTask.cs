using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeTask : MonoBehaviour
{
    [SerializeField] TaskManager taskManager;
    [SerializeField] bool isBeingTouched;
    [SerializeField] Sprite finishedSprite;

    private void Update() {
        if (isBeingTouched) {
            if (Input.GetKeyDown(KeyCode.Space) && gameObject.GetComponent<SpriteRenderer>().sprite != finishedSprite) {
                taskManager.completeTask();
                gameObject.GetComponent<SpriteRenderer>().sprite = finishedSprite;
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
