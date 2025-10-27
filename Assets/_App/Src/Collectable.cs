using System;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Game started");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger entered by: {other.name}");
    }
}
