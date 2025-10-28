using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    List<Collectable> _collectables;
    int totalCollectables;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Collectable[] foundCollectables = FindObjectsByType<Collectable>(FindObjectsSortMode.None);
        _collectables = new(foundCollectables);
        totalCollectables = _collectables.Count;
    }

    public void OnCollectableCollected(Collectable collectable)
    {
        _collectables.Remove(collectable);

        int currentScore = totalCollectables - _collectables.Count;
        Debug.Log($"Collected {collectable.name}. Score: {currentScore}/{totalCollectables}");

        if (_collectables.Count == 0)
        {
            OnGameWon();
        }
    }

    void OnGameWon()
    {
        Debug.Log("VICTORY!");
        Invoke(nameof(RestartCurrentLevel), 2.5f);
    }

    void RestartCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}