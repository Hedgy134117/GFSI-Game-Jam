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
        Color c = new Color(150 / 255f, 188 / 255f, 255 / 255f, 255 / 255f);
        gameObject.GetComponent<SpriteRenderer>().color = c;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        isBeingTouched = true;
    }
    private void OnCollisionExit2D(Collision2D other) {
        isBeingTouched = false;
    }
}
