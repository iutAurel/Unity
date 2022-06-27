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


    private CharacterController c;

    private void Start()
    {
        c = GetComponent<CharacterController>();
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
        mouvD = new Vector3(0, 0, Input.GetAxis("Vertical"));
        mouvD = transform.TransformDirection(mouvD);
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * speed * 10);
        mouvD *= speed;
        if (Input.GetButton("Jump") && c.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jump - 2f *gravity);
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