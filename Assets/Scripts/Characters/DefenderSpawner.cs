using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    const string DEFENDER_PARENT = "Defenders";

    DefenderController defender;
    GameObject defenderParent;


    private void Start()
    {
        CreateDefenderParent();
    }
    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT);
        }
    }
    private void OnMouseDown()
    {
        TryToPlaceDefender(GetSquareClicked());
    }
    public void SetDefenderFromUI(DefenderController selectedDefender)
    {
        defender = selectedDefender;
    }
    private void TryToPlaceDefender(Vector2 gridPos)
    {
        var FodderDisplay = FindObjectOfType<FodderDisplay>();
        var defenderCost = defender.GetFodderCost();
        if (FodderDisplay.HaveEnoughFodder(defenderCost))
        {
            SpawnDefender(gridPos);
            FodderDisplay.ReduceFodder(defenderCost);
        }
    }
    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }
    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float xPos = Mathf.RoundToInt(rawWorldPos.x);
        float yPos = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(xPos, yPos);
    }
    private void SpawnDefender(Vector2 roundedPos)
    {
        DefenderController newDefender = Instantiate(defender, roundedPos, Quaternion.identity) as DefenderController;
        newDefender.transform.parent = defenderParent.transform;
    }
}
