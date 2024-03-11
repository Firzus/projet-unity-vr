using UnityEngine;

public class ConsoleIntro : MonoBehaviour
{
    [SerializeField] private Material _apparitionMaterial;
    private Material[] _originalMaterials;
    private MeshRenderer[] _childrenRenderers;

    void Start()
    {
        // Initialisation et stockage des mat�riaux originaux.
        _childrenRenderers = GetComponentsInChildren<MeshRenderer>();
        _originalMaterials = new Material[_childrenRenderers.Length];
        for (int i = 0; i < _childrenRenderers.Length; i++)
        {
            _originalMaterials[i] = _childrenRenderers[i].material;
        }

        // Application du mat�riau de dissolve.
        ApplyDissolveMaterial();
    }

    void ApplyDissolveMaterial()
    {
        foreach (MeshRenderer renderer in _childrenRenderers)
        {
            renderer.material = _apparitionMaterial;
        }

        // Supposons que votre effet de dissolve est termin� apr�s un certain d�lai.
        // Utilisez Invoke, Coroutine, ou tout autre m�canisme pour d�terminer quand l'effet est termin� et appeler RestoreOriginalMaterials.
        Invoke(nameof(RestoreOriginalMaterials), 3f); // Exemple: restauration apr�s 5 secondes.
    }

    void RestoreOriginalMaterials()
    {
        for (int i = 0; i < _childrenRenderers.Length; i++)
        {
            _childrenRenderers[i].material = _originalMaterials[i];
        }
    }
}
