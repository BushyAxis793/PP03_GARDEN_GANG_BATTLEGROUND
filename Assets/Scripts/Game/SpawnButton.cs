using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnButton : MonoBehaviour
{
    [SerializeField] DefenderController prefab;


    private void Start()
    {
        CostLabel();
    }
    private void CostLabel()
    {
        Text costText = GetComponentInChildren<Text>();
        if (!costText)
        {
            //DO NOTHING
        }
        else
        {
            costText.text = prefab.GetFodderCost().ToString();
        }
    }
    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<SpawnButton>();
        foreach (SpawnButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetDefenderFromUI(prefab);
    }
}
