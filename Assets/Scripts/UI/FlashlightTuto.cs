using System.Collections;
using TMPro;
using UnityEngine;

public class FlashlightTuto : MonoBehaviour
{
    [SerializeField] private GameObject _pileToUse;
    [SerializeField] private TextMeshPro _text;

    void Update()
    {
        if(!_pileToUse)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ColorText());
        }
    }
    public IEnumerator ColorText()
    {
        AudioManager.Instance.PlaySFX("Error");
        _text.color = Color.red;
        yield return new WaitForSeconds(3f);
        _text.color = Color.white;
    }
}
