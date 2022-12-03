using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Attempts : MonoBehaviour
{
    public static int attempts = 0;
    public TextMeshProUGUI attemptsText;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        attemptsText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        attemptsText.text = "Attempts " + attempts;
    }
}
