using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    [Header("Mouse Settings")]
    [Tooltip("The current sensitivity of the mouse.")]
    public float mouseSensitivity = 100f;

    [Header("UI Components")]
    [Tooltip("Slider used to adjust mouse sensitivity.")]
    public GameObject menuPanel;
    public Slider sensitivitySlider;
    public TextMeshProUGUI sensitivityNumber;

    private void Start()
    {
        // Initialize slider and set default value
        if (sensitivitySlider != null)
        {
            sensitivitySlider.minValue = 10f;
            sensitivitySlider.maxValue = 1000f;
            sensitivitySlider.value = mouseSensitivity;
            sensitivitySlider.onValueChanged.AddListener(OnSensitivityChanged);
        }

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenu();
        }
    }

    public void OpenMenu()
    {
        menuPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        //Remove Cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        menuPanel.SetActive(false);

        Time.timeScale = 1f;
    }

    private void OnSensitivityChanged(float newSensitivity)
    {
        mouseSensitivity = newSensitivity;
        sensitivityNumber.text = mouseSensitivity.ToString();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
