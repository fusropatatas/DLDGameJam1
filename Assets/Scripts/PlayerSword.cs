using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    PlayerMovement player;
    BoxCollider2D col;

    void Start()
    {
        player = GetComponentInParent<PlayerMovement>();

        col = this.gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
        col.isTrigger = true;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(player.hasSword && player.animator.GetBool("isAttacking"))
        {
            if(col.gameObject.CompareTag("Enemy"))
            {
                Destroy(col.gameObject);
            }
        }
    }
}
