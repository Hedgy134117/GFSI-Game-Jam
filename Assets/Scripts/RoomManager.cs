using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField]
    private GameObject canvasContainer = null;

    private void Start() {
        setActiveChildren(false);
    }

    public void setActiveChildren(bool active) {
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(active);
        }
        if (canvasContainer != null) {
            canvasContainer.SetActive(active);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        setActiveChildren(true);
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }

    private void OnTriggerExit2D(Collider2D other) {
        setActiveChildren(false);
    }
}
