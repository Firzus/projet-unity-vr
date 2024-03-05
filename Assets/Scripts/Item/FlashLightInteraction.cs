using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FlashLightInteraction : MonoBehaviour
{
    [SerializeField] GameObject _light;
    [SerializeField] bool _isOn = true;
    void Start()
    {
        if(_light == false)
        {
            _light.SetActive(false);
        }

        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(UseFlashLight);
    }

    // Update is called once per frame
    void Update()
    {
        
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
