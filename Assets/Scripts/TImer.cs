using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TImer : MonoBehaviour
{
    public Text timerText; // The variable that will contain the parameters for the timer.
    private float startTime; // the float that conatins the timer start.
    private bool isTimerRunning; // the bool to check if the timer is running or not.

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
