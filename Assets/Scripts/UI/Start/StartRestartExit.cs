using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartRestartExit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reload()
    {
        SceneManager.LoadScene("TestScene", LoadSceneMode.Single);
    }

    public void Launch()
    {
        SceneManager.LoadScene("TestScene", LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
