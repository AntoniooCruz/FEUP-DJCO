using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    private float startTime;
    private bool on;
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
        }
        
    }

    public void timerStop()
    {
        on = false;
    }

    public void timerStart()
    {
        on = true;
    }
}
