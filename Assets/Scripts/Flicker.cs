using UnityEngine;

public class Flicker : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private float minAlpha = 0.6f;
    [SerializeField] private float maxAlpha = 1f;

    [SerializeField] private float flickerSpeed = 0.05f;

    private float timer;

    private void Start()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        SetTimer();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            Color color = spriteRenderer.color;

            color.a = Random.Range(minAlpha, maxAlpha);

            spriteRenderer.color = color;

            SetTimer();
        }
    }

    private void SetTimer()
    {
        timer = flickerSpeed;
    }
}
