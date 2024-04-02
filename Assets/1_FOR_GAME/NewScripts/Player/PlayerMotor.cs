using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float initialSpeed = 5f;
    public float currentSpeed = 5f;
    public float increasedSpeed = 8f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = increasedSpeed;
        }
        else
        {
            currentSpeed = initialSpeed;
        }
    }
    //receive the inputs for our InputManager.cs and apply them to our charactor controller.
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x; 
        moveDirection.z = input.y; 
        controller.Move(transform.TransformDirection(moveDirection) * currentSpeed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0) 
            playerVelocity.y = -2f;
        controller.Move(playerVelocity * Time.deltaTime);
        Debug.Log(playerVelocity.y);
    }
    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    public float boostMultiplier = 2f;
    private bool isJumpBoosted = false;

    public void StartJumpBoost()
    {
        if (!isJumpBoosted)
        {
            StartCoroutine(ApplyJumpBoost());
        }
    }
    IEnumerator ApplyJumpBoost()
    {
        // Store original jump force
        float originalJumpForce = jumpHeight;

        // Modify jump force with the boost multiplier
        jumpHeight *= boostMultiplier;

        // Set jump boost flag
        isJumpBoosted = true;

        // Wait for the specified duration (10 seconds)
        yield return new WaitForSeconds(10f);

        // Reset jump force to its original value
        jumpHeight = originalJumpForce;

        // Reset jump boost flag
        isJumpBoosted = false;
    }
}
