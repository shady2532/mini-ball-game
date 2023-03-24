using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public static Timer instance;
    private void Awake()
    {
        instance = this;
    }

    public Text timerText;
    public float timer = 10f;
    public void addTime(float x)
    {
        timer += x;
        timerText.text = timer.ToString("F2");
    }
    void Update()
    {

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("F2");            
        }
        else
        {
            timer = 0;
            timerText.text = timer.ToString("F2");
            gameover.instance.lose();
        }

    }
}
