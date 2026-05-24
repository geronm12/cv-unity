using System.Collections;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    [Header("Scenes")]
    public GameObject MenuScene;
    public GameObject MainScene;

    [Header("Transition")]
    public SpriteRenderer fadeOverlay;
    public float fadeDuration = 1f;

    private bool isTransitioning = false;

    private void Start()
    {
        SetFadeAlpha(0f);

        MainScene.SetActive(false);
    }

    public void StartGame()
    {
        if (!isTransitioning)
            StartCoroutine(TransitionToMainScene());
    }

    private IEnumerator TransitionToMainScene()
    {
        isTransitioning = true;

        // FADE TO BLACK
        yield return StartCoroutine(Fade(0f, 1f));

        // CAMBIO ESCENA
        MenuScene.SetActive(false);
        MainScene.SetActive(true);

        // FADE FROM BLACK
        yield return StartCoroutine(Fade(1f, 0f));

        isTransitioning = false;
    }

    private IEnumerator Fade(float start, float end)
    {
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;

            float alpha = Mathf.Lerp(start, end, elapsed / fadeDuration);

            SetFadeAlpha(alpha);

            yield return null;
        }

        SetFadeAlpha(end);
    }

    private void SetFadeAlpha(float alpha)
    {
        Color color = fadeOverlay.color;
        color.a = alpha;
        fadeOverlay.color = color;
    }
}