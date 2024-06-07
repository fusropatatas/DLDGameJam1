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
    public bool hasSword = false;
    public bool hasShield = false;
    //private bool isAttacking = false;
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

        if(movement.x != 0 || movement.y != 0){
            animator.SetFloat("LastX", movement.x);
            animator.SetFloat("LastY", movement.y);
        }

        // Player Attacks
        if(Input.GetKeyDown("space")){
            Attack();
        }
        
    }

    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // put this function in player controller script
    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject player = this.gameObject;

        // when player collides with enemy
        if (col.gameObject.tag.Equals("Enemy"))
        {
            npcScript npc = col.gameObject.GetComponent<npcScript>();

            float offsetX = 0.0f;
            float offsetY = 0.0f;

            if (npc.GetDirection().Equals("down"))
                offsetY = -0.5f;

            else if (npc.GetDirection().Equals("up"))
                offsetY = 0.5f;

            else if (npc.GetDirection().Equals("left"))
                offsetX = -0.5f;

            else if (npc.GetDirection().Equals("right"))
                offsetX = 0.5f;

            player.transform.position += new Vector3(offsetX, offsetY, 0.0f);
        }
    }

    void Attack()
    {
        animator.SetBool("hasSword", hasSword);
        animator.SetBool("hasShield", hasShield);
        animator.SetTrigger("isAttacking");
    }
}
