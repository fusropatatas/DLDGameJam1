using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldChestScript : MonoBehaviour
{
    public Animator animator;
    public PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("in");
            animator.SetBool("isChestOpen", true);
            player.hasShield = true;
            
            //potentially inventory addition
        }
    }
}
