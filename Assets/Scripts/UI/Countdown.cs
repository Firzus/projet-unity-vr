using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshPro timerText;
    [SerializeField] private float remainingTime = 0.0f;
    [SerializeField] private int minutes = 0, seconds = 0, timer = 0;
    [SerializeField] private bool stressed = false;
    public bool awake = false;

    void Start()
    {
        awake = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (awake && remainingTime > 0)// Countdown
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)//when countdown is 0
        {
            remainingTime = 0;
            Explosion();
        }
        //convert and show the countdown
        minutes = Mathf.FloorToInt(remainingTime / 60);
        seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        timer = seconds;

        if (!stressed && timer == 0)// play bip sound to 60 seconds
        {
            BipSound();
        }
        if (minutes == 0 && seconds == 30)// pass to stress mode when 30 seconds remaining
        {
            stressed = true;
        }
        if (stressed)
        {
            StressMode();
        }

    }

    private void BipSound()
    {
        Debug.Log("Bip");
    }
    private void StressMode()
    {
        if (stressed && timer != 0)// bip for each seconds
        {
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
