using System;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public static event Action<Collectable> OnCollected;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger entered by: {other.name}");
        Collect();
    }

    void Collect()
    {
        Debug.Log($"{name} got collected");
        OnCollected?.Invoke(this);
        Destroy(gameObject);
    }
}
