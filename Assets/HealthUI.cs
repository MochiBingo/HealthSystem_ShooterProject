using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HealthUI : MonoBehaviour
{
    public TextMeshProUGUI UI;
    public static HealthUI instance;
    public void Awake()
    {
        UI = GetComponent<TextMeshProUGUI>();
        instance = this;
        UI.text = ("test?");
    }
}
