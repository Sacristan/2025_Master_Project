using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    private IEnumerator Start()
    {
        Collectable.OnCollected += CollectableOnOnCollected;

        yield return new WaitUntil(() => GameManager.instance.IsReady);
        UpdateScore();
    }

    private void OnDestroy()
    {
        Collectable.OnCollected -= CollectableOnOnCollected;
    }

    private void CollectableOnOnCollected(Collectable collectable)
    {
        Invoke(nameof(UpdateScore), 0.1f);
    }

    void UpdateScore()
    {
        int totalCollectables = GameManager.instance.TotalCollectables;
        int currentScore = totalCollectables - GameManager.instance.CurrentCollectablesInLevel;
        scoreText.text = $"Collected {currentScore}/{totalCollectables}";
    }
}