using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    PlayerMovement player;
    BoxCollider2D col;

    [SerializeField] private int dmg;

    void Start()
    {
        player = GetComponentInParent<PlayerMovement>();

        col = this.gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
        col.isTrigger = true;

        dmg = 5;
    }

    void Update()
    {
        if(player.GetDirection().Equals("up") || player.GetDirection().Equals("down"))
            col.size = new Vector2(0.75f, 1.0f);
        else
            col.size = new Vector2(1.0f, 0.75f);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(player.hasSword && player.animator.GetBool("isAttacking"))
        {
            if(col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("Boss"))
            {
                GameObject opp = col.gameObject;

                float offsetX = 0.0f;
                float offsetY = 0.0f;

                if (player.GetDirection().Equals("down"))
                    offsetY = -0.5f;

                else if (player.GetDirection().Equals("up"))
                    offsetY = 0.5f;

                else if (player.GetDirection().Equals("left"))
                    offsetX = -0.5f;

                else if (player.GetDirection().Equals("right"))
                    offsetX = 0.5f;

                opp.transform.position += new Vector3(offsetX, offsetY, 0.0f);

                if(opp.CompareTag("Enemy"))
                {
                    Health mobHealth = opp.GetComponent<Health>();
                    mobHealth.TakeDamage(dmg);
                }
                else
                {
                    Health bossHealth = opp.GetComponent<Health>();
                    bossHealth.TakeDamage(dmg);
                }
            }
        }
    }
}
