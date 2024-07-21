using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TImer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool isTimerRunning;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        isTimerRunning = true ;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString("00");
            string seconds = (t % 60).ToString("00");
            

            timerText.text = string.Format("{0}:{1}", minutes,seconds);
        }
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }
}
