using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Vector3 move;
    Vector3 playerVelocity;
    public bool isGrounded;
    public float mouseSensitivy = 5.0f;
    private float jumpHeight = 2f;
    private CharacterController controller;
    private Animator animator;
    private float walkSpeed = 5;
    private float runSpeed = 8;
    public Vector3 gravity;
    public float gravityVal = -9.18f;
    //public int maxJumpCount = 1;
    public bool canDoubleJump = false;
    public bool isOnGround = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();     
        animator = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRotation();
        if (animator.applyRootMotion == false) 
        {
            ProcessMovement();
        }
        ProcessGravity();

    }

     public void LateUpdate() 
     {
         UpdateAnimator();
     }

    void DisableRootMotion()
    {
        animator.applyRootMotion = false;  
    }

    void UpdateAnimator()
    {
        isOnGround = controller.isGrounded;
        Vector3 characterXandZMotion = new Vector3(playerVelocity.x, 0.0f, playerVelocity.z);
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.0f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.0f)
        {
            if (Input.GetButton("Fire3"))
            {
                animator.SetFloat("Speed", 1.0f);
            } 
            else
            {
                animator.SetFloat("Speed", 0.5f);
            }
        }
        else
        {
            animator.SetFloat("Speed", 0.0f);
        }
        //animator.SetBool("IsGrounded", isOnGround);
        //if (Input)
    }

    void UpdateRotation() 
    {
        transform.Rotate(0, Input.GetAxis("Mouse X")* mouseSensitivy, 0, Space.Self); 
    }

    void ProcessMovement()
    {
        float speed = GetMovementSpeed();
 
        // Get the camera's forward and right vectors
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
 
        // Make sure to flatten the vectors so that they don't contain any vertical component
        cameraForward.y = 0;
        cameraRight.y = 0;
 
        // Normalize the vectors to ensure consistent speed in all directions
        cameraForward.Normalize();
        cameraRight.Normalize();
 
        // Calculate the movement direction based on input and camera orientation
        Vector3 moveDirection = (cameraForward * Input.GetAxis("Vertical")) + (cameraRight * Input.GetAxis("Horizontal"));
 
        // Apply the movement direction and speed
        move = moveDirection.normalized * speed * Time.deltaTime;

        playerVelocity = move;

        // Vector3 move = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;

        // move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // if (move != Vector3.zero)
        // {
        //     gameObject.transform.forward = move;
        // }
        // Debug.Log("movement" + movement);
        // Debug.Log("movement   2" + );
    }

    public bool DoubleJump()
    {
        return canDoubleJump = true;
    }

    public void ProcessGravity()
    {
        // Since there is no physics applied on character controller we have this applies to reapply gravity
        isGrounded = controller.isGrounded;
        if (isGrounded)
        {
            gravity.y = -1.0f;
            if (Input.GetButtonDown("Jump")) // Code to jump
            {
                animator.SetBool("IsGrounded", false);
                Debug.Log("Single JUMP");
                gravity.y +=  Mathf.Sqrt(jumpHeight * -3.0f * gravityVal);
            } 
            else
            {
                animator.SetBool("IsGrounded", true);
            }
        }
        else // if not grounded
        {
            if (Input.GetButtonDown("Jump") && canDoubleJump)
            {
                animator.SetBool("IsDoubleJump", true);
                Debug.Log("Double JUMP");
                gravity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityVal);
                canDoubleJump = false;
            } 
            else
            {
                animator.SetBool("IsDoubleJump", false);
                gravity.y += gravityVal * Time.deltaTime; // brings character down
            }
        }
        
        playerVelocity.y = gravity.y * Time.deltaTime;
        controller.Move(playerVelocity);
    }

    float GetMovementSpeed()
    {
        if (Input.GetButton("Fire3"))// Left shift
        // if (Input.GetKey(KeyCode.LeftControl))
        {
            return runSpeed;
        }
        else
        {
            return walkSpeed;
        }
    }
}
