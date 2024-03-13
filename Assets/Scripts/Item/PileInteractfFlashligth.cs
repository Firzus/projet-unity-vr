using UnityEngine;

public class PileInteractfFlashligth : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Flashlight"))
        {
            other.GetComponent<FlashLightInteraction>().BoostPower(30);
            Destroy(this.gameObject);
        }
    }
}
