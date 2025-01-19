using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
     private Rigidbody2D rb;
     private Animator animator;

     private Vector2 movement;
     private string curentState;

     private void Start()
     {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
     }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        StateCheck();
    }

    private void StateCheck()
    {
        if(movement.x > 0.1)
        {
            ChangeAnimationState("Player_Right");
            movement.y = 0;
        }
        if(movement.x < -0.1)
        {
            ChangeAnimationState("Player_Left");
            movement.y = 0;
        }
        if(movement.y > 0.1)
        {
            ChangeAnimationState("Player_Up");
            movement.x = 0;
        }
        if(movement.y < -0.1)
        {
            ChangeAnimationState("Player_Down");
            movement.x = 0;
        }
        if(movement.y < 0.1 && movement.y > -0.1 && movement.x < 0.1 && movement.x > -0.1)
        {
            ChangeAnimationState("Player_Hold");
        }
        
    }

    public void ChangeAnimationState(string newState)
    {
        if (curentState == newState) return;

        animator.Play(newState);

        curentState = newState;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
