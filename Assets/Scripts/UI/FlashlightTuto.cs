using UnityEngine;

public class FlashlightTuto : MonoBehaviour
{
    [SerializeField] private GameObject _pileToUse;

    void Update()
    {
        if(!_pileToUse)
        {
            Destroy(gameObject);
        }
    }
}
