using System.Collections;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    [SerializeField] private bool _mFadeOnStart = true;
    [SerializeField] private float _mFadeDuration = 2;
    [SerializeField] private Color _mFadeColor;
    private Renderer _mRend;

    private void Start()
    {
        _mRend = GetComponent<Renderer>();
        if (_mFadeOnStart) FadeIn();
    }

    public void FadeIn()
    {
        GetComponent<MeshRenderer>().enabled = true;
        Fade(1, 0);
    }

    public void FadeOut() 
    {
        GetComponent<MeshRenderer>().enabled = true;
        Fade(0, 1);
    }

    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    public float FadeDuration()
    {
        return _mFadeDuration;
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;
        while (timer <= _mFadeDuration) 
        {
            Color newColor = _mFadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / _mFadeDuration);

            _mRend.material.SetColor("_Color", newColor);

            timer += Time.deltaTime;
            yield return null;
        }

        Color newColor2 = _mFadeColor;
        newColor2.a = alphaOut;
        _mRend.material.SetColor("_Color", newColor2);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
