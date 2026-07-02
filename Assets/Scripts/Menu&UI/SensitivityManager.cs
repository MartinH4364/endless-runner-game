using TMPro;
using UnityEngine;

public class SensitivityManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float defaultSensitivity = 250;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateSensitivity(defaultSensitivity);
    }

    public void updateSensitivity(float sensitivity)
    {
        MouseLook.mouseSensitivity = sensitivity;
        text.text = sensitivity.ToString();
    }
}
