using System.Collections.Generic;
using UnityEngine;

public class CorridorLightOff : MonoBehaviour
{
    [SerializeField] private List<GameObject> _lightOff;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            TurnOffLight();
            Destroy(gameObject);
        }
    }

    public void TurnOffLight()
    {
        AudioManager.Instance.PlaySFX("CoupureCourant");

        foreach (GameObject light in _lightOff)
        {
            light.GetComponentInChildren<Light>().enabled = false;
        }
    }
}
