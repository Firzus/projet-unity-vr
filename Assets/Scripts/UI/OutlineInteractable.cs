using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineInteractable : MonoBehaviour
{
    private int _mTargetLayer = 6;

    private RaycastHit _mHit;
    private Transform _mHighlight;

    void Update()
    {
        Outlining();
    }

    void Outlining()
    {
        if (_mHighlight != null) 
        {
            _mHighlight.gameObject.GetComponent<Outline>().enabled = false;
            _mHighlight = null;
        }

        Ray ray = new Ray(transform.position, transform.forward);
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out _mHit))
        {
            _mHighlight = _mHit.transform;
            if (_mHighlight.gameObject.layer == _mTargetLayer) 
            {
                if (_mHighlight.gameObject.GetComponent<Outline>() != null) 
                {
                    _mHighlight.gameObject.GetComponent<Outline>().enabled = true;
                }
                else
                {
                    Outline outline = _mHighlight.gameObject.AddComponent<Outline>();
                    outline.enabled = true;
                }
            }
            else
            {
                _mHighlight = null;
            }
        }
    }
}
