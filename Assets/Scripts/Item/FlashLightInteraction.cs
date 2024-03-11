using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FlashLightInteraction : MonoBehaviour
{
    [SerializeField] private GameObject _light;
    [SerializeField] private bool _isOn = true;
    [SerializeField] private int _power = 100;
    void Start()
    {
        if(!_isOn)
        {
            _light.SetActive(false);
        }

        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(UseFlashLight);

        StartCoroutine(FlashlightDurability());
    }

    public void UseFlashLight(ActivateEventArgs arg)
    {
        StartCoroutine(CoolDown(1f));
    }

    public IEnumerator CoolDown(float refreshTime)
    {
        if (_isOn || _power <= 0)
        {

            _isOn = false;
            _light.SetActive(false);
        }
        else if(!_isOn && _power > 0)
        {
            _isOn = true;
            _light.SetActive(true);
        }

        yield return new WaitForSeconds(refreshTime);
    }

    public IEnumerator FlashlightDurability()
    {
        if(_isOn && _power > 0)
        {
            _power--;

            if(_power <= 0)
            {

                _isOn = false;
                _light.SetActive(false);
            }
        }
        yield return new WaitForSeconds(3f);
        StartCoroutine(FlashlightDurability());
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Pile"))
        {
            _power += 50;
            Destroy(collision.gameObject);
        }
    }
}
