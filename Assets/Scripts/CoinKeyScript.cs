using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinKeyScript : MonoBehaviour
{
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
            //code for adding key to inv
            //code to call CoinKeyDoor OpenTrigger
            Destroy(gameObject);
        }
    }
}
