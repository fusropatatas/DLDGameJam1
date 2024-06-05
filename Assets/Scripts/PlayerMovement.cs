// Followed tutorial: https://youtu.be/whzomFgjT50?si=o4Prgv2zUEDy1Vb8

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // prevents diagonal movement
        if(movement.x != 0){
            movement.y = 0;
        } else if(movement.y != 0){
            movement.x = 0;
        }

        // Updates parameters of animator
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Horizontal", movement.x);

        // Flips sprite when going left/right
        if(movement.x > 0){
            sprite.flipX = false;
        } else if(movement.x < 0){
            sprite.flipX = true;
        }

    }

    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
