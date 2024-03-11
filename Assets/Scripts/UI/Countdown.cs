using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshPro _timerText;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _remainingTimeInSeconds = 0.0f;
    [SerializeField] private int _remainingTimeInMinutes = 0;
    [SerializeField] private int _enterStressModeInSeconds = 0, _enterStressModeInMinutes = 0;
    [SerializeField] private InputActionProperty[] _inputAction;

    private IEnumerator _sfx;
    private int _minutes = 0, _seconds = 0, _timer = 0;
    private bool _stressed = false, _isPlayingSFXSound = false;
    public bool Awake = false;

    void Start()
    {
        _timerText = transform.GetChild(1).GetComponent<TextMeshPro>();
        _audioSource = transform.GetChild(2).GetComponent<AudioSource>();
        if (_remainingTimeInMinutes > 0)
            _remainingTimeInSeconds = _remainingTimeInMinutes * 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Awake)
        {
            return;
        }
        _sfx = BipSound(1.0f);
        if (!_stressed)
        {
            CountdownMethod();
            if (_timer == 0 && _remainingTimeInSeconds != 0 && !_isPlayingSFXSound)// play bip sound to 60 seconds
            {
                StartCoroutine(_sfx);
            }
            if (_minutes == _enterStressModeInMinutes && _seconds == _enterStressModeInSeconds + 1)// pass to stress mode
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
        if (_remainingTimeInSeconds < 0)//when countdown is under 0 stop the countdown
        {
            _sfx = Explosion(5.0f);
            StartCoroutine(_sfx);
            _remainingTimeInSeconds = 0;
        }
        if (_remainingTimeInSeconds == 0)//return nothing if 0
        {
            _timerText.text = string.Format("{0:00}:{1:00}", _minutes, _seconds);
            return;
        }
        //convert and show the countdown
        _minutes = Mathf.FloorToInt(_remainingTimeInSeconds / 60);
        _seconds = Mathf.FloorToInt(_remainingTimeInSeconds % 60);
        _timerText.text = string.Format("{0:00}:{1:00}", _minutes, _seconds);

        _timer = _seconds;
    }
    private void StressMode()
    {
        if (_timer != 0 && !_isPlayingSFXSound)// bip for each seconds
        {
            StartCoroutine(_sfx);
        }
        //beepSound.loop = true;
    }

    private IEnumerator Explosion(float time)
    {
        //play animation
        //desactivate input
        //return to the menu

        //disable input of player
        if (_inputAction != null)
        {
            for (int i = 0; i < _inputAction.Length; i++)
            {
                _inputAction[i].action.Disable();
            }
        }

        _isPlayingSFXSound = true;
        _audioSource = transform.GetChild(3).GetComponent<AudioSource>();
        _audioSource.Play();
        _isPlayingSFXSound = false;

        yield return new WaitForSeconds(time);
        //Destroyi all of the child

        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);

        SceneManager.LoadScene(0);
        StopCoroutine(_sfx);
    }

    private IEnumerator BipSound(float time)
    {
        _isPlayingSFXSound = true;
        yield return new WaitForSeconds(time);
        _audioSource.Play();
        _isPlayingSFXSound = default;
        StopCoroutine(_sfx);
    }
}
