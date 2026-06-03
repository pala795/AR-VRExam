using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    public static FadeScreen Instance;

    [SerializeField] private Image _fadeScreen;
    [SerializeField] private float _fadeDuration = 1f;

    private bool fadeIn;
    private Coroutine fadeRoutine;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;

        fadeIn = false;

        // Start fully transparent
        SetAlpha(0f);
    }

    private void Start()
    {
        FadeOut();
    }

    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (fadeIn) FadeOut();
            else FadeIn();

            fadeIn = !fadeIn;
        }
    }*/

    public void FadeIn()
    {
        Debug.Log("FadeIn");

        if (fadeRoutine != null)
            StopCoroutine(fadeRoutine);

        fadeRoutine = StartCoroutine(Fade(0f, 1f));
    }

    public void FadeOut()
    {
        Debug.Log("FadeOut");

        if (fadeRoutine != null)
            StopCoroutine(fadeRoutine);

        fadeRoutine = StartCoroutine(Fade(1f, 0f));
    }

    private IEnumerator Fade(float start, float end)
    {
        float time = 0f;

        while (time < _fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(start, end, time / _fadeDuration);
            SetAlpha(alpha);
            yield return null;
        }

        SetAlpha(end);
    }

    private void SetAlpha(float alpha)
    {
        Color c = _fadeScreen.color;
        c.a = alpha;
        _fadeScreen.color = c;
    }
}