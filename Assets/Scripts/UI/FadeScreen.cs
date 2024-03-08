using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    public float fadeDuration = 2;
    public Color fadeColor;
    private Renderer _mRend;

    private void Start()
    {
        _mRend = GetComponent<Renderer>();
    }

    public void Fade(float alphaIn, float alphaOut)
    {
        
    }

   //IENumerator
}
