using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public bool isLeverOn;
    public DoorScript door1;
    public DoorScript door2;
    public Animator animator;
    //int toggle = 1;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            door1.OpenTrigger();
            door2.OpenTrigger();
            isLeverOn = !isLeverOn;
            animator.SetBool("ActualToggle", isLeverOn);
        }
    }

    public void OnTriggerExit(Collider other)
    {

    }
}
