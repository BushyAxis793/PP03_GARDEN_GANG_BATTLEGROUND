using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] GameObject bonePrefab, bonePosition;

    EnemySpawnController myRowSpawner;

    private void Start()
    {
        SetRowSpawner();
    }


    private void Update()
    {
        if (IsEnemyInRow())
        {
            Debug.Log("shoot");
        }
        else
        {
            Debug.Log("wait");
        }
    }

    public void Throw()
    {
        Instantiate(bonePrefab, bonePosition.transform.position, transform.rotation);
    }

    private bool IsEnemyInRow()
    {
        if (myRowSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    private void SetRowSpawner()
    {
        EnemySpawnController[] spawners = FindObjectsOfType<EnemySpawnController>();

        foreach (EnemySpawnController spawner in spawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if (isCloseEnough)
            {
                myRowSpawner = spawner;
            }
        }
    }
}
