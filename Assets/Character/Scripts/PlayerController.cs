using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    [SerializeField] private float speed;
    [SerializeField] private float jump;

    private Vector3 mouvD;
    private Vector3 velocity;

    [SerializeField] private float gravity;

    private CharacterController controller;

    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Mouv();

    }

    private void Mouv()
    {
        mouvD = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        mouvD = transform.TransformDirection(mouvD);
        mouvD *= speed;
        if (Input.GetButton("Jump") && controller.isGrounded)
        {
            playerAnimator.SetBool("SlowRunYes", false);
            playerAnimator.SetBool("JumpYes", true);
            velocity.y = Mathf.Sqrt(jump - 2f * gravity);
        }
        else if (controller.isGrounded == false)
        {
            playerAnimator.SetBool("JumpYes", true);
        }

        else
            playerAnimator.SetBool("JumpYes", false);

        if (Input.GetAxis("Vertical") > 0)
        {
            playerAnimator.SetBool("SlowRunYes", true);
            playerAnimator.SetBool("RunBackYes", false);
        }

        else if (Input.GetAxis("Vertical") == 0)
        {
            playerAnimator.SetBool("SlowRunYes", false);
            playerAnimator.SetBool("RunBackYes", false);
        }

        else
        {
            playerAnimator.SetBool("SlowRunYes", false);
            playerAnimator.SetBool("RunBackYes", true);
            if (Input.GetButton("Jump"))
            {
                playerAnimator.SetBool("JumpBackYes", true);
            }
            else
                playerAnimator.SetBool("JumpBackYes", false);
            playerAnimator.SetBool("RunBackYes", true);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            playerAnimator.SetBool("RightWalkYes", true);
            playerAnimator.SetBool("LeftWalkYes", false);
        }

        else if (Input.GetAxis("Horizontal") == 0)
        {
            playerAnimator.SetBool("RightWalkYes", false);
            playerAnimator.SetBool("LeftWalkYes", false);
        }

        else
        {
            playerAnimator.SetBool("RightWalkYes", false);
            playerAnimator.SetBool("LeftWalkYes", true);
        }

        controller.Move(mouvD * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}