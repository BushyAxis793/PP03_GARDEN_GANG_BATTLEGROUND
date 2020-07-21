using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [Range(0f, 5f)] float currentSpeed = 1f;

    const string ATTACK_BOOL = "isAttacking";

    GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<GameController>().EnemySpawned();
    }
    private void OnDestroy()
    {
        GameController gameController = FindObjectOfType<GameController>();
        if (gameController != null)
        {
            gameController.EnemyKilled();
        }
    }
    private void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        SwitchAnimation();
    }
    private void SwitchAnimation()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool(ATTACK_BOOL, false);
        }
    }
    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }
    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool(ATTACK_BOOL, true);
        currentTarget = target;
    }
    public void AttackTarget(float damage)
    {
        if (!currentTarget)
        {
            return;
        }

        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.TakeDamage(damage);
        }
    }
}
