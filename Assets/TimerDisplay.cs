using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] float timerStart = 60f;
    float timerRounded;
    TextMeshProUGUI timerText;

    private void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        timerStart -= Time.deltaTime;
        timerRounded = Mathf.RoundToInt(timerStart);
        UpdateDisplay();
        bool timerFinished = (timerRounded <= 0);
        if (timerFinished)
        {
            Debug.Log("Level Ending");
        }
    }

    private void UpdateDisplay()
    {
        timerText.text = timerRounded.ToString();
    }
}
