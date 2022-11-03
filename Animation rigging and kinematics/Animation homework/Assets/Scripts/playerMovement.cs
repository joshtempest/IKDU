using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D rigBody;
    private Animator myAnimator;
    public int speed = 5;

    void Awake()
    {
        rigBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();

        if (movement.x != 0 || movement.y != 0)
        {
            myAnimator.SetFloat("x",movement.x);
            myAnimator.SetFloat("y",movement.y);
            myAnimator.SetBool("isWalking", true);
        }
        else
        {
            myAnimator.SetBool("isWalking", false);
        }
    }

    void FixedUpdate()
    {
        rigBody.velocity = movement * speed;
    }
}
