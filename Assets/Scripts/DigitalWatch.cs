using System;
using TMPro;
using UnityEngine;

public class DigitalWatch : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI watchTimerText;

    private void Update()
    {
        watchTimerText.text = DateTime.Now.ToString(format: "HH:mm:ss");
    }
}
