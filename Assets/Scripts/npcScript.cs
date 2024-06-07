using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    private Transform npc;
    [SerializeField] private Animator animator;

    [SerializeField] private List<Vector2> positions;
    private int index;
    
    [SerializeField] private float speed;

    [SerializeField] private float aggroDistance;
    private bool isChasing;

    private string direction;

    private Health mobHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        npc = this.gameObject.transform;
        this.gameObject.AddComponent<BoxCollider2D>();
        
        // setting initial position
        npc.SetPositionAndRotation(new Vector3(positions[0].x, positions[0].y, 0.0f), Quaternion.identity);

        // identifying the next position based on its index in the lists
        index = 1;

        isChasing = false;

        direction = "down";

        mobHealth = this.gameObject.AddComponent<Health>() as Health;
        mobHealth.maxHealth = 10;
    }

    // Update is called once per frame
    void Update()
    {
        float targetX = 0;
        float targetY = 0;

        Vector3 currentPosition;
        Quaternion q;
        npc.GetPositionAndRotation(out currentPosition, out q);

        if (player != null && Vector3.Distance(currentPosition, player.transform.position) <= aggroDistance)
        {
            Vector3 playerPosition;
            Quaternion playerQ;
            player.transform.GetPositionAndRotation(out playerPosition, out playerQ);

            targetX = playerPosition.x;
            targetY = playerPosition.y;

            isChasing = true;
        }

        else if (positions.Count > 1)
        {
            targetX = positions[index].x;
            targetY = positions[index].y;

            isChasing = false;
        }

        // movement
        // move to left
        if (currentPosition.x > targetX)
        {
            npc.position -= new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);

            direction = "left";

            animator.SetFloat("Horizontal", -1);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", 1);

            npc.GetPositionAndRotation(out currentPosition, out q);

            // npc attacks
            if (currentPosition.x <= targetX)
            {
                npc.SetPositionAndRotation(new Vector3(targetX, currentPosition.y, 0.0f), Quaternion.identity);

                if(!isChasing)
                {
                    index++;

                    if(index == positions.Count)
                        index = 0;
                }
            }
        }

        // move to right
        else if (currentPosition.x < targetX)
        {
            npc.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);

            direction = "right";

            animator.SetFloat("Horizontal", 1);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", 1);

            npc.GetPositionAndRotation(out currentPosition, out q);

            if (currentPosition.x >= targetX)
            {
                npc.SetPositionAndRotation(new Vector3(targetX, currentPosition.y, 0.0f), Quaternion.identity);

                if(!isChasing)
                {
                    index++;

                    if(index == positions.Count)
                        index = 0;
                }
            }
        }

        else
        {
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Speed", 1);

            // move downwards
            if (currentPosition.y > targetY)
            {
                npc.position -= new Vector3(0.0f, speed * Time.deltaTime, 0.0f);

                direction = "down";

                animator.SetFloat("Vertical", -1);

                npc.GetPositionAndRotation(out currentPosition, out q);

                if (currentPosition.y <= targetY)
                {
                    npc.SetPositionAndRotation(new Vector3(currentPosition.x, targetY, 0.0f), Quaternion.identity);

                    if(!isChasing)
                    {
                        index++;

                        if(index == positions.Count)
                            index = 0;
                    }
                }
            }

            // move upwards
            else if (currentPosition.y < targetY)
            {
                npc.position += new Vector3(0.0f, speed * Time.deltaTime, 0.0f);

                direction = "up";

                animator.SetFloat("Vertical", 1);

                npc.GetPositionAndRotation(out currentPosition, out q);

                if (currentPosition.y >= targetY)
                {
                    npc.SetPositionAndRotation(new Vector3(currentPosition.x, targetY, 0.0f), Quaternion.identity);

                    if(!isChasing)
                    {
                        index++;

                        if(index == positions.Count)
                            index = 0;
                    }
                }
            }
       }
    }

    // temp function to show collision
    public void stop()
    {
        speed = 0;
    }

    public string GetDirection()
    {
        return direction;
    }
}
