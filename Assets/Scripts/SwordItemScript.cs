using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordItemScript : MonoBehaviour
{
    public DoorScript door;
    public TutorialUIScript UI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UI.UISwap();
            door.OpenTrigger();
            Destroy(gameObject);
        }
    }

}
