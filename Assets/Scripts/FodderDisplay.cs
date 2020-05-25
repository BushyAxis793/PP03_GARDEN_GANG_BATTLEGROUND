using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FodderDisplay : MonoBehaviour
{
    [SerializeField] int fodder = 100;
    TextMeshProUGUI fodderText;

    private void Start()
    {
        fodderText = GetComponent<TextMeshProUGUI>();
        UpdateFodderText();
    }

    private void UpdateFodderText()
    {
        fodderText.text = fodder.ToString();
    }

    public bool HaveEnoughFodder(int amount)
    {
        return fodder >= amount;
    }

    public void AddFodder(int amount)
    {
        fodder += amount;
        UpdateFodderText();
    }

    public void ReduceFodder(int amount)
    {
        if (fodder >= amount)
        {
            fodder -= amount;
            UpdateFodderText();
        }
    }
}
