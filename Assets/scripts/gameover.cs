using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gameover : MonoBehaviour
{
    public static gameover instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject gameUI;
    public GameObject gameoverUI;

    public bool lost=false;
    void Start()
    {
        gameUI.SetActive(true);
        gameoverUI.SetActive(false);
        lost = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && lost)
            reset();      
    }
    public void lose()
    {        
        gameoverUI.SetActive(true);
        gameUI.SetActive(false);
        Time.timeScale= 0f;
        lost= true;
    }
    public void reset()
    {
        gameUI.SetActive(true);
        gameoverUI.SetActive(false);
        Time.timeScale= 1f;
        lost= false;
        SceneManager.LoadScene(1);
    }
}
