using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    List<Collectable> _collectables;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Collectable[] foundCollectables = FindObjectsByType<Collectable>(FindObjectsSortMode.None);
        _collectables = new(foundCollectables);
    }

    public void OnCollectableCollected(Collectable collectable)
    {
        Debug.Log($"Collected {collectable.name}");
        _collectables.Remove(collectable);

        if (_collectables.Count == 0)
        {
            Debug.Log("VICTORY!");
        }
    }
}