using System.Collections;
using UnityEngine;

public class LightHorrorflashing : MonoBehaviour
{
    [SerializeField] private GameObject _light;
    void Start()
    {
        StartCoroutine(Flashing());
    }


    public IEnumerator Flashing()
    {
        _light.SetActive(false);
        yield return new WaitForSeconds(3f);
        _light.SetActive(true);
        yield return new WaitForSeconds(2f);
        StartCoroutine(Flashing());
    }
}
