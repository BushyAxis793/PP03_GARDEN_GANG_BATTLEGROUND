using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButton : MonoBehaviour
{
    [SerializeField] DefenderController prefab;

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
