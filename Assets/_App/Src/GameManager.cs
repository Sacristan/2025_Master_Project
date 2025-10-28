using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    List<Collectable> _collectables;
    int totalCollectables;

    public bool IsReady { get; private set; }
    public int CurrentCollectablesInLevel => _collectables.Count;
    public int TotalCollectables => totalCollectables;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Collectable[] foundCollectables = FindObjectsByType<Collectable>(FindObjectsSortMode.None);
        _collectables = new(foundCollectables);
        totalCollectables = _collectables.Count;

        Collectable.OnCollected += OnCollectableCollected;
        IsReady = true;
    }

    private void OnDestroy()
    {
        Collectable.OnCollected -= OnCollectableCollected;
    }

    void OnCollectableCollected(Collectable collectable)
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