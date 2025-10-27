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
        Collect();
    }

    void Collect()
    {
        Debug.Log($"{name} got collected");
        GameManager.instance.OnCollectableCollected(this);
        Destroy(gameObject);
    }
}
