using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    public Slider slider;
    public string entityName;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;

        if(slider != null)
            slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount) 
    {
        health -= amount;
        
        if(slider != null)
            slider.value = health;
        
        if(health <=0) 
        {
            if(entityName.Equals("Player"))
                SceneManager.LoadScene("Death Screen");
            else
                Destroy(gameObject);
        }
    }
}
