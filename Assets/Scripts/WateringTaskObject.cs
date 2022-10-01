using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringTaskObject : MonoBehaviour
{
    public bool isWatered = false;
    [SerializeField] bool isBeingTouched;

    private void Update() {
        if (isBeingTouched) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                water();
            }
        }
    }

    public void water() {
        isWatered = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        isBeingTouched = true;
    }
    private void OnCollisionExit2D(Collision2D other) {
        isBeingTouched = false;
    }
}
