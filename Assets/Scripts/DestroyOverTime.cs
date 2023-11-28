using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float _lifetime;
    void Start()
    {
        
    }

    void Update()
    {
        Destroy(gameObject, _lifetime);
    }
}
