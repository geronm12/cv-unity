using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMenuController : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;

    [Header("Menu References")]
    public RectTransform cursor;

    public TextMeshProUGUI[] options;

    [Header("Cursor Offset")]
    public Vector2 cursorOffset;

    private int selectedIndex = 0;

    void Start()
    {
        UpdateSelection();
    }

    void Update()
    {
        HandleInput();
        AnimateSelection();
    }

    void HandleInput()
    {
     
        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            selectedIndex--;

            if (selectedIndex < 0)
                selectedIndex = options.Length - 1;

            audioSource.Play();

            UpdateSelection();
        }

        
        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            selectedIndex++;

            if (selectedIndex >= options.Length)
                selectedIndex = 0;

            audioSource.Play();

            UpdateSelection();
        }

       
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            SelectOption();
        }
    }

    void UpdateSelection()
    {
        RectTransform selectedOption =
            options[selectedIndex].GetComponent<RectTransform>();

        cursor.position =
            selectedOption.position + (Vector3)cursorOffset;
    }

    void AnimateSelection()
    {
        for (int i = 0; i < options.Length; i++)
        {
            if (i == selectedIndex)
            {
                // TITILEO
                float alpha =
                    0.75f + Mathf.Sin(Time.time * 8f) * 0.25f;

                options[i].alpha = alpha;

                // PEQUEÑO ESCALADO
                float scale =
                    1f + Mathf.Sin(Time.time * 8f) * 0.03f;

                options[i].transform.localScale =
                    Vector3.one * scale;
            }
            else
            {
                options[i].alpha = 1f;

                options[i].transform.localScale =
                    Vector3.one;
            }
        }
    }

    void SelectOption()
    {
        switch (selectedIndex)
        {
            case 0:
                Debug.Log("NEW GAME");
                break;

            case 1:
                Debug.Log("SETTINGS");
                break;
        }
    }
}