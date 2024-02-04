using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public PlayerMovement movement;
    
    public static PlayerMovement playerMovementInstance;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 0.8f;

    public Transform groundCheck;
    public float groundDistance = 0.01f;
    public LayerMask groundMask;

    public Vector3 velocity;
    bool isGrounded;

    private void Awake()
    {
        playerMovementInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (MagicScript.magicScriptInstance.levitating == false)
        {
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            velocity.y += gravity * Time.deltaTime;
        }
        else if (MagicScript.magicScriptInstance.levitating == true)
        {
            velocity.y += 0.25f * Time.deltaTime;
            MagicScript.magicScriptInstance.levitateDuration += 1f * Time.deltaTime;

            if (MagicScript.magicScriptInstance.levitateDuration > 4f)
            {
                MagicScript.magicScriptInstance.levitating = false;
                MagicScript.magicScriptInstance.levitateDuration = 0f;
                MagicScript.magicScriptInstance.canLevitate = true;
            }
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        controller.Move(velocity * Time.deltaTime);
    }
}
