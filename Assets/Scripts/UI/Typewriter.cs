using System.Collections;
using TMPro;
using UnityEngine;

public class Typewriter : MonoBehaviour
{
    [Tooltip("The TextMeshPro component to apply the typewriter effect to.")]
    public TMP_Text textMeshPro;

    [Tooltip("The speed at which characters appear (characters per second).")]
    public float typeSpeed = 50f;

    private string _fullText;
    private Coroutine _typingCoroutine;

    private void Start()
    {
        // Cache the full text to display
        if (textMeshPro != null)
        {
            _fullText = textMeshPro.text;
            textMeshPro.text = ""; // Start with an empty string
            StartTyping();
        }
        else
        {
            Debug.LogError("TextMeshPro component is not assigned!");
        }
    }

    public void StartTyping()
    {
        // Stop any existing typing coroutine and start a new one
        if (_typingCoroutine != null)
            StopCoroutine(_typingCoroutine);

        _typingCoroutine = StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        textMeshPro.text = ""; // Ensure text starts blank
        float delay = 1f / typeSpeed;

        foreach (char c in _fullText)
        {
            textMeshPro.text += c; // Add the next character
            yield return new WaitForSeconds(delay); // Wait before adding the next
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}