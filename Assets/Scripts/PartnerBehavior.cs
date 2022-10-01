using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerBehavior : MonoBehaviour
{
    [SerializeField] int speed;
    public bool movingToPosition = false;
    void moveToPosition() {
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, speed * Time.deltaTime);
    }

    private void Update() {
        if (movingToPosition) {
            moveToPosition();
        }
    }
}
