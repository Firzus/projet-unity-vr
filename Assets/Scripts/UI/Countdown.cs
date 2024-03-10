using UnityEngine;
using TMPro;
using System.Collections;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshPro timerText;
    [SerializeField] private AudioSource beepSound;
    [SerializeField] private float remainingTimeInSeconds = 0.0f;
    [SerializeField] private int remainingTimeInMinutes = 0;
    [SerializeField] private int enterStressModeInSeconds = 0, enterStressModeInMinutes = 0;

    private IEnumerator sfx;
    private int minutes = 0, seconds = 0, timer = 0;
    private bool stressed = false, isPlayingSFXSound = false;
    public bool awake = false;

    void Start()
    {
        if (remainingTimeInMinutes > 0)
            remainingTimeInSeconds = remainingTimeInMinutes * 60;
        beepSound = transform.GetChild(2).GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!awake)
        {
            return;
        }
        sfx = SfxSound(1.0f);
        if (!stressed)
        {
            CountdownMethod();
            if (timer == 0 && remainingTimeInSeconds != 0 && !isPlayingSFXSound)// play bip sound to 60 seconds
            {
                StartCoroutine(sfx);
            }
            if (minutes == enterStressModeInMinutes && seconds == enterStressModeInSeconds)// pass to stress mode
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
        if (remainingTimeInSeconds > 0)// Countdown
        {
            remainingTimeInSeconds -= Time.deltaTime;
        }
        else if (remainingTimeInSeconds < 0)//when countdown is under 0 stop the countdown
        {
            remainingTimeInSeconds = 0;
            Explosion();
        }
        else if (remainingTimeInSeconds == 0)//return nothing if 0
        {
            remainingTimeInSeconds = 0;
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            return;
        }
        //convert and show the countdown
        minutes = Mathf.FloorToInt(remainingTimeInSeconds / 60);
        seconds = Mathf.FloorToInt(remainingTimeInSeconds % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        timer = seconds;
    }

    private void BipSound()
    {
        beepSound.Play();
    }
    private void StressMode()
    {
        if (timer != 0 && !isPlayingSFXSound)// bip for each seconds
        {
            StartCoroutine(sfx);
        }
        //beepSound.loop = true;
    }

    private void Explosion()
    {
        //play animation
        //desactivate input
        //return to the menu
        Debug.Log("explosion");
    }

    IEnumerator SfxSound(float time)
    {
        isPlayingSFXSound = true;
        yield return new WaitForSeconds(time);
        BipSound();
        isPlayingSFXSound = default;
        StopCoroutine(sfx);
    }
}
