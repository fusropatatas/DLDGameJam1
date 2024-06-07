using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroToSpawnLogicScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goToSpawnScene()
    {
        SceneManager.LoadScene("Spawnroom");
    }

    public void goToIntroScene()
    {
        SceneManager.LoadScene("Intro Screen");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
