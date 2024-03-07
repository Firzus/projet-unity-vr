using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioSource _mAudioSource;
    [SerializeField] private Slider _mMasterVolume;
    [SerializeField] private Slider _mSFXVolume;
}
