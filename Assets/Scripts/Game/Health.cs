using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            PlayDeathVFX();
            Destroy(gameObject);
        }
    }
    private void PlayDeathVFX()
    {
        if (!deathVFX)
        {
            return;
        }
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, 1f);
    }
}
