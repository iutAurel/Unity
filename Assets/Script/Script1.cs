using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script1 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jump;

    private Vector3 mouvD;
    private Vector3 velocity;

    [SerializeField] private float gravity;
    private bool col;
    private Transform tp;

    private Animator playerAnimator;

    private CharacterController c;

    private void Start()
    {
        c = GetComponent<CharacterController>();
        playerAnimator = GetComponent<Animator>();
        col = false;
    }

    private void Update()
    {
        Debug.Log(col);
        if (col == true)
        {
            c.transform.position = new Vector3(1.5f, 1.25f, 8);//tp.transform.position;
            col = false;
        }
        else
        {
            Mouv();
        }
    }

    private void Mouv()
    {
        mouvD = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        mouvD = transform.TransformDirection(mouvD);
        mouvD *= speed;
        if (Input.GetButton("Jump") && c.isGrounded)
        {
            playerAnimator.SetBool("SlowRunYes", false);
            playerAnimator.SetBool("JumpYes", true);
            velocity.y = Mathf.Sqrt(jump - 2f *gravity);
        }

        else if (c.isGrounded == false)
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

        c.Move(mouvD * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        c.Move(velocity * Time.deltaTime);
    }

    void OnControllerColliderHit(ControllerColliderHit collision)
    {
        if (collision.gameObject.tag == "sol")
            col = true;
    }

}