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
    private GameObject sword;
    private Health playerHealth;
    public bool hasSword = false;
    public bool hasShield = false;
    private string direction;
    //private bool isAttacking = false;

    void Start()
    {
        sword = new GameObject("PlayerSword");
        sword.AddComponent<PlayerSword>();
        sword.transform.SetParent(this.gameObject.transform);
        sword.transform.localPosition = new Vector3(0.0f, -0.75f, 0.0f);

        direction = "down";

        playerHealth = this.gameObject.AddComponent<Health>() as Health;
        playerHealth.maxHealth = 10;
        playerHealth.entityName = "Player";
    }

    // Update is called once per frame
    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // prevents diagonal movement
        if(movement.x != 0)
        {
            movement.y = 0;

            // set sword hitbox location and player direction
            if(movement.x > 0)
            {
                sword.transform.localPosition = new Vector3(0.75f, 0.0f, 0.0f);
                direction = "right";
            }
            else
            {
                sword.transform.localPosition = new Vector3(-0.75f, 0.0f, 0.0f);
                direction = "left";
            }
        }
        else if(movement.y != 0)
        {
            movement.x = 0;

            // set sword hitbox location and player direction
            if(movement.y > 0)
            {
                sword.transform.localPosition = new Vector3(0.0f, 0.75f, 0.0f);
                direction = "up";
            }
            else
            {
                sword.transform.localPosition = new Vector3(0.0f, -0.75f, 0.0f);
                direction = "down";
            }
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

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject player = this.gameObject;

        // when player collides with enemy
        if (col.gameObject.CompareTag("Enemy"))
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

            playerHealth.TakeDamage(2);
        }

        else if (col.gameObject.tag.Equals("Boss"))
        {
            bossScript npc = col.gameObject.GetComponent<bossScript>();

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

            playerHealth.TakeDamage(4);
        }

        if (col.gameObject.CompareTag("Sword"))
        {
            hasSword = true;
        }
    }

    void Attack()
    {
        animator.SetBool("hasSword", hasSword);
        animator.SetBool("hasShield", hasShield);
        animator.SetTrigger("isAttacking");
    }

    public string GetDirection()
    {
        return direction;
    }
}
