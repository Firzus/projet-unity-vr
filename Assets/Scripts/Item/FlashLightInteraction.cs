using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FlashLightInteraction : MonoBehaviour
{
    [SerializeField] private GameObject _light;
    [SerializeField] private bool _isOn = true;
    void Start()
    {
        if(!_light)
        {
            _light.SetActive(false);
        }

        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(UseFlashLight);
    }

    public void UseFlashLight(ActivateEventArgs arg)
    {
        StartCoroutine(CoolDown(1f));
    }

    public IEnumerator CoolDown(float refreshTime)
    {
        if (_isOn)
        {
            _isOn = false;
            _light.SetActive(false);
        }
        else
        {
            _isOn = true;
            _light.SetActive(true);
        }

        yield return new WaitForSeconds(refreshTime);
    }
}
