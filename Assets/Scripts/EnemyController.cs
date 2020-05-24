using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [Range(0f, 5f)] [SerializeField] float walkSpeed = 1f;
    private void Update()
    {
        transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
    }
}
