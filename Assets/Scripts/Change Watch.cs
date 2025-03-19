using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeWatch : MonoBehaviour
{

    private bool isDigital = true;

    [SerializeField] private GameObject digitalWatch, analogWatch;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;

    public void ChangeTypeOfWatch()
    {
        if (isDigital == true)
        {
            digitalWatch.SetActive(false);
            analogWatch.SetActive(true);
            textMeshProUGUI.text = "Cambiar a digital";
            isDigital = false;
        }
        else
        {
            analogWatch.SetActive(false);
            digitalWatch.SetActive(true);
            textMeshProUGUI.text = "Cambiar a analógico";
            isDigital = true;
        }
    }
}
