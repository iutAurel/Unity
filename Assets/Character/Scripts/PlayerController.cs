using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6f;

    public float jumspeed = 8f;
    public float gravity = 20f;
    private Vector3 moveD = Vector3.zero;
    public CharacterController Cac;
    private Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        Cac = GetComponent<CharacterController>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Cac.isGrounded)
        {
            moveD = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveD = transform.TransformDirection(moveD);
            moveD *= speed;

            if (Input.GetButton("Jump"))
            {
                playerAnimator.SetBool("JumpYes", true);
                moveD.y = jumspeed;

                if(Input.GetAxis("Vertical") >= 0)
                {
                    moveD = new Vector3(0, 0, Input.GetAxis("Vertical"));
                    moveD = transform.TransformDirection(moveD);
                    moveD *= speed;
                }
            }
            else
                playerAnimator.SetBool("JumpYes", false);


            if (Input.GetAxis("Vertical") > 0.1)
            {
                playerAnimator.SetBool("SlowRunYes", true);
            }
            else if (Input.GetAxis("Vertical") < 0.1)
            {
                playerAnimator.SetBool("SlowRunYes", false);
            }
        }

        if (Input.GetButton("Jump"))
        {
            playerAnimator.SetBool("JumpYes", true);
        }
        else
        {
            playerAnimator.SetBool("JumpYes", false);
        }

        moveD.y -= gravity * Time.deltaTime;
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * speed * 10);
        Cac.Move(moveD * Time.deltaTime);
    }
}

