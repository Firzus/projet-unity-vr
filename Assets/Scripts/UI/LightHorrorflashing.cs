using System.Collections;
using UnityEngine;

public class LightHorrorflashing : MonoBehaviour
{
    [SerializeField] private GameObject _light;
    [SerializeField] private float _cooldown_1 = 3f;
    [SerializeField] private float _cooldown_2 = 2f;
    void Start()
    {
        StartCoroutine(Flashing());
    }


    public IEnumerator Flashing()
    {
        _light.SetActive(false);
        yield return new WaitForSeconds(_cooldown_1);
        _light.SetActive(true);
        yield return new WaitForSeconds(_cooldown_2);
        StartCoroutine(Flashing());
    }
}
