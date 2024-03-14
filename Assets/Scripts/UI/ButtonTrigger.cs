using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider))]
public class ButtonTrigger : Button
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FingerTip"))
        {
            ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.submitHandler);
        }
    }
}
