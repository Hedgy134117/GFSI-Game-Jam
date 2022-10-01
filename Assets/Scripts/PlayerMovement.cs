using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private int speed;
    [SerializeField]
    private float horizontal;
    [SerializeField]
    private float vertical;
    [SerializeField]
    private Rigidbody2D rb;
    private PlayerManager playerManager;
    private bool isTouchingInteractableObject;
    public bool canMove = true;

    private void Start() {
        playerManager = gameObject.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerManager.dialogueManager.isDialogueActive() && !playerManager.taskManager.taskListIsVisible) {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }

        if (isTouchingInteractableObject) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                playerManager.dialogueManager.startDialogue();
                isTouchingInteractableObject = false;
            }
        }
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(horizontal, vertical).normalized * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other) {
        InteractableObject interactableData = other.gameObject.GetComponent<InteractableObject>();
        if (interactableData != null) {
            isTouchingInteractableObject = true;
            playerManager.dialogueManager.updateDialogue(interactableData.dialogue);
        }  
    }
    
    private void OnCollisionExit2D(Collision2D other) {
        isTouchingInteractableObject = false;    
    }
}
