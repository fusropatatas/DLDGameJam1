using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    //public Animator animator;
    bool isDoorOpen = false;
    public GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Testing, delete later
        if (Input.GetKeyDown(KeyCode.Q)){
            isDoorOpen = !isDoorOpen;
            go.GetComponentInChildren<SpriteRenderer>().enabled = isDoorOpen;
        }
    }

    public void Trigger()
    {
        if (GetComponent<BoxCollider2D>().enabled)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
