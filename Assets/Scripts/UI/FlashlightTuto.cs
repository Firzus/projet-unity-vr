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

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //_text
        }
    }
}
