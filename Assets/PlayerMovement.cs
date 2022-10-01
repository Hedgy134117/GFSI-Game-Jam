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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        vertical = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        transform.Translate(new Vector2(horizontal * speed, vertical * speed));
    }
}
