using UnityEngine;
using TMPro;
using System.Collections;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshPro _timerText;
    [SerializeField] private AudioSource _beepSound;
    [SerializeField] private float _remainingTimeInSeconds = 0.0f;
    [SerializeField] private int _remainingTimeInMinutes = 0;
    [SerializeField] private int _enterStressModeInSeconds = 0, _enterStressModeInMinutes = 0;

    private IEnumerator _sfx;
    private int _minutes = 0, _seconds = 0, _timer = 0;
    private bool _stressed = false, _isPlayingSFXSound = false;
    public bool Awake = false;

    void Start()
    {
        if (_remainingTimeInMinutes > 0)
            _remainingTimeInSeconds = _remainingTimeInMinutes * 60;
        _beepSound = transform.GetChild(2).GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Awake)
        {
            return;
        }
        _sfx = SfxSound(1.0f);
        if (!_stressed)
        {
            CountdownMethod();
            if (_timer == 0 && _remainingTimeInSeconds != 0 && !_isPlayingSFXSound)// play bip sound to 60 seconds
            {
                StartCoroutine(_sfx);
            }
            if (_minutes == _enterStressModeInMinutes && _seconds == _enterStressModeInSeconds)// pass to stress mode
            {
                _stressed = true;
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
        if (_remainingTimeInSeconds > 0)// Countdown
        {
            _remainingTimeInSeconds -= Time.deltaTime;
        }
        else if (_remainingTimeInSeconds < 0)//when countdown is under 0 stop the countdown
        {
            _remainingTimeInSeconds = 0;
            Explosion();
        }
        else if (_remainingTimeInSeconds == 0)//return nothing if 0
        {
            _remainingTimeInSeconds = 0;
            _timerText.text = string.Format("{0:00}:{1:00}", _minutes, _seconds);
            return;
        }
        //convert and show the countdown
        _minutes = Mathf.FloorToInt(_remainingTimeInSeconds / 60);
        _seconds = Mathf.FloorToInt(_remainingTimeInSeconds % 60);
        _timerText.text = string.Format("{0:00}:{1:00}", _minutes, _seconds);

        _timer = _seconds;
    }

    private void BipSound()
    {
        _beepSound.Play();
    }
    private void StressMode()
    {
        if (_timer != 0 && !_isPlayingSFXSound)// bip for each seconds
        {
            StartCoroutine(_sfx);
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
        _isPlayingSFXSound = true;
        yield return new WaitForSeconds(time);
        BipSound();
        _isPlayingSFXSound = default;
        StopCoroutine(_sfx);
    }
}
