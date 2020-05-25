using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderController : MonoBehaviour
{
    [SerializeField] int fodderCost = 50;

    public void AddFodder(int amount)
    {
        FindObjectOfType<FodderDisplay>().AddFodder(amount);
    }

    public int GetFodderCost()
    {
        return fodderCost;
    }
}
