using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineInteractable : MonoBehaviour
{
    int targetLayer = 6;

    private RaycastHit hit;
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
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out hit))
        {
            _mHighlight = hit.transform;
            if (_mHighlight.gameObject.layer == targetLayer) 
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
