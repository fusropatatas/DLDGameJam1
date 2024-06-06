using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinKeyScript : MonoBehaviour
{

    public DoorScript door1;
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
            door1.OpenTrigger();
            Destroy(gameObject);
        }
    }
}
