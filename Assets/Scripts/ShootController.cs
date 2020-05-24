using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] GameObject bonePrefab, bonePosition;

    public void Throw()
    {
        Instantiate(bonePrefab, bonePosition.transform.position, transform.rotation);
    }
}
