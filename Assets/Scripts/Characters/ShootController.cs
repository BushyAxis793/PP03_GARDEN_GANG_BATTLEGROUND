using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] GameObject bonePrefab, bonePosition;

    const string PROJECTILE_PARENT = "Projectile";

    EnemySpawnController myRowSpawner;
    GameObject projectileParent;

    private void Start()
    {
        SetRowSpawner();
        CreateProjectileParent();
    }
    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT);
        }
    }
    public void Throw()
    {
        GameObject newProjectile = Instantiate(bonePrefab, bonePosition.transform.position, transform.rotation) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
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
