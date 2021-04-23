using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;

    public float gravity = -9.8f;
    public Transform groundChecker;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Animator anim;
    public GameObject playerModel;
    public GameObject playerCamera;

    Vector3 velocity;
    bool isOnGround;

    public float jumpHeight = 3f;

    // Start is called before the first frame update
    void Start()
    {
        playerModel.SetActive(false);
        playerCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = Physics.CheckSphere(groundChecker.position, groundDistance, groundMask);

        if(isOnGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //"Is the player moving?" If so, set the moveSpeed to current speed so the correct animation will play
        if(x > 0)
        {
            anim.SetFloat("moveSpeed", x);
        }
        else if(z > 0)
        {
            anim.SetFloat("moveSpeed", z);
        }


        //handles if Z and X are negative
        if(x < 0)
        {
            anim.SetFloat("moveSpeed", x * -1);
        }
        else if(z < 0)
        {
            anim.SetFloat("moveSpeed", z * -1);
        }
        else if((z == 0) && (x == 0))
        {
            anim.SetFloat("moveSpeed", 0.0f);
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isOnGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}
