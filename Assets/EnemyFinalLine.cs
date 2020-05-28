using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFinalLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<LivesDisplay>().ReduceLives();
    }
}
