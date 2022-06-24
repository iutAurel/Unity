using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 6f;

    public float jumspeed = 8f;
    public float gravity = 20f;
    private Vector3 moveD = Vector3.zero;
    public CharacterController Cac;
    // Start is called before the first frame update
    void Start()
    {
        Cac = GetComponent<CharacterController>();
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
                moveD.y = jumspeed;
            }
            {

            }
        }
        moveD.y -= gravity * Time.deltaTime;
        
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * speed * 10);
        Cac.Move(moveD * Time.deltaTime);
    }
}
