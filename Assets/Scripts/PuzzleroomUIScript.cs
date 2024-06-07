using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleroomUIScript : MonoBehaviour
{
    public LeverScript lever;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lever.isLeverOn)
        {
            Destroy(gameObject);
        }
    }
}
