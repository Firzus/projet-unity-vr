using UnityEngine;

public class ConsoleIntro : MonoBehaviour
{
    [SerializeField] private Material _apparitionMaterial;
    private Material[] _originalMaterials;
    private MeshRenderer[] _childrenRenderers;

    void Start()
    {
        // Initialisation et stockage des matériaux originaux.
        _childrenRenderers = GetComponentsInChildren<MeshRenderer>();
        _originalMaterials = new Material[_childrenRenderers.Length];
        for (int i = 0; i < _childrenRenderers.Length; i++)
        {
            _originalMaterials[i] = _childrenRenderers[i].material;
        }

        // Application du matériau de dissolve.
        ApplyDissolveMaterial();
    }

    void ApplyDissolveMaterial()
    {
        foreach (MeshRenderer renderer in _childrenRenderers)
        {
            renderer.material = _apparitionMaterial;
        }

        // Supposons que votre effet de dissolve est terminé après un certain délai.
        // Utilisez Invoke, Coroutine, ou tout autre mécanisme pour déterminer quand l'effet est terminé et appeler RestoreOriginalMaterials.
        Invoke(nameof(RestoreOriginalMaterials), 3f); // Exemple: restauration après 5 secondes.
    }

    void RestoreOriginalMaterials()
    {
        for (int i = 0; i < _childrenRenderers.Length; i++)
        {
            _childrenRenderers[i].material = _originalMaterials[i];
        }
    }
}
