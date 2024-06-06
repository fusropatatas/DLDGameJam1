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
 
    }

    public void OpenTrigger()
    {
        isDoorOpen = !isDoorOpen;
        go.GetComponentInChildren<SpriteRenderer>().enabled = !isDoorOpen;
        GetComponent<BoxCollider2D>().enabled = !isDoorOpen;
    }
}
