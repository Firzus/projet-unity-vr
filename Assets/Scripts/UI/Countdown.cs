using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshPro timerText;
    [SerializeField] private float remainingTimeInFloat = 0.0f;
    [SerializeField] private int remainingTimeInInt = 0;
    private int minutes = 0, seconds = 0, timer = 0;
    private bool stressed = false;
    public bool awake = false;

    void Start()
    {
        if (remainingTimeInInt > 0)
            remainingTimeInFloat = remainingTimeInInt * 60;
        awake = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!awake)
        {
            return;
        }

        if (!stressed)
        {
            CountdownMethod();
            if (timer == 0 && remainingTimeInFloat != 0)// play bip sound to 60 seconds
            {
                Debug.Log("normal bip");
                BipSound();
            }
            if (minutes == 0 && seconds == 30)// pass to stress mode when 30 seconds remaining
            {
                stressed = true;
            }
        }
        else
        {
            CountdownMethod();
            StressMode();
        }

    }

    private void CountdownMethod()
    {
        if (remainingTimeInFloat > 0)// Countdown
        {
            remainingTimeInFloat -= Time.deltaTime;
        }
        else if (remainingTimeInFloat < 0)//when countdown is under 0 stop the countdown
        {
            remainingTimeInFloat = 0;
            Explosion();
        }
        else if (remainingTimeInFloat == 0)//return nothing if 0
        {
            return;
        }
        //convert and show the countdown
        minutes = Mathf.FloorToInt(remainingTimeInFloat / 60);
        seconds = Mathf.FloorToInt(remainingTimeInFloat % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        timer = seconds;
    }

    private void BipSound()
    {
        //Debug.Log("Bip");
    }
    private void StressMode()
    {
        if (timer != 0)// bip for each seconds
        {
            Debug.Log("stresss bip");
            BipSound();
        }
    }

    private void Explosion()
    {
        //play animation
        //desactivate input
        //return to the menu
        Debug.Log("explosion");
    }
}
