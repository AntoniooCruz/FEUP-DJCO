using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText = null;
    private float startTime;
    private bool on;
    public float increaseScoreTime;
    private float nextActionTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        on = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {

            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString("00");
            string seconds = ((int)t % 60).ToString("00");
            string miliseconds = ((t * 100) % 60).ToString("00");

            timerText.text = minutes + ":" + seconds + ":" + miliseconds;
            if(t > nextActionTime)
            {
                nextActionTime += increaseScoreTime;
                GameController.GetInstance().AddScore(10);
            }
        }
        
    }

    public void TimerStop()
    {
        on = false;
    }

    public void TimerStart()
    {
        on = true;
    }

    public string getTime() {
        return timerText.text;
    }
}
