﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] float timerStart = 60f;
    TextMeshProUGUI timerText;

    float timerRounded;
    bool triggerLevelFinished = false;

    private void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        if (triggerLevelFinished)
        {
            return;
        }
        timerStart -= Time.deltaTime;
        timerRounded = Mathf.RoundToInt(timerStart);
        UpdateDisplay();
        bool timerFinished = (timerRounded <= 0);
        if (timerFinished)
        {
            FindObjectOfType<GameController>().TimerFinished();
            triggerLevelFinished = true;
        }
    }
    private void UpdateDisplay()
    {
        timerText.text = timerRounded.ToString();
    }
}
