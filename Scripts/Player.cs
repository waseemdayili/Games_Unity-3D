using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    [SerializeField] private float gravity = 20f;
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;
    [SerializeField] private float jump = 7f;
    [SerializeField] private float rotSpeed = 80f;
    [SerializeField] private float rot = 0f;
    public static int currentHealth = 100;
    public Slider healthBar;
    public GameObject backgroundEffect;

    
 


    CharacterController controller;
    Rigidbody rb;

    Vector3 moveDirection = Vector3.zero;

    // Start is called befor e the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    

        backgroundEffect.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(0, 0.0f, vertical);
            moveDirection *= speed;
            moveDirection = transform.TransformDirection(moveDirection);
        }

        if ((Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.Space))))
        {
            moveDirection = new Vector3(0, 0.0f, vertical);
            moveDirection *= speed;
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection.y = jump;

        }
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetButton("Jump"))
        {
            moveDirection.y = jump;
        }

        // update the health bar

        healthBar.value = currentHealth;


        // game over
        if (currentHealth < 0)
        {
            currentHealth = 100;
            RestartScene();
        }
        if (currentHealth > 100)
        {
            currentHealth = 100;
        }

    }

    public static void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
