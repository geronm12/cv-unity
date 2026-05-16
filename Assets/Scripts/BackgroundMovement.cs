using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0.2f;
    [SerializeField] private float moveX = 1f;
    [SerializeField] private float moveY = 1f;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float x = Mathf.Sin(Time.time * speed) * moveX;
        float y = Mathf.Cos(Time.time * speed) * moveY;

        transform.position =
            startPosition + new Vector3(x, y, 0);
    }
}
