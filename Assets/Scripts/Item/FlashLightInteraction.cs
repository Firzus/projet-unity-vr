using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FlashLightInteraction : MonoBehaviour
{
    [SerializeField] private GameObject _light;
    [SerializeField] private bool _isOn = true;
    [SerializeField] private int _power = 100;
    [SerializeField] private TextMeshPro _timerText;

    public int Power { get =>  _power; set { _power = value;} }
    void Start()
    {
        if(!_isOn)
        {
            _light.SetActive(false);
        }

        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(UseFlashLight);

        StartCoroutine(FlashlightDurability());
        UpdateText();
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

        AudioManager.Instance.PlaySFX("ToggleFlashlight");
        yield return new WaitForSeconds(refreshTime);
    }

    public IEnumerator FlashlightDurability()
    {
        if(_isOn && _power > 0)
        {
            _power--;
            UpdateText();

            if (_power <= 0)
            {

                _isOn = false;
                _light.SetActive(false);
            }
        }
        yield return new WaitForSeconds(3f);
        StartCoroutine(FlashlightDurability());
    }

    public void BoostPower(int batterie, GameObject pile = null)
    {
        _power += batterie;
        if( _power > 100 )
        {
            _power = 100;
        }
        if (pile != null)
        {
            Destroy(pile);
        }
        AudioManager.Instance.PlaySFX("Click");
        UpdateText();
    }

    public void UpdateText()
    {
        _timerText.text = _power.ToString()+"%";
    }
}
