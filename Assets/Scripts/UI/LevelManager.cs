using System.Collections.Generic;
using TMPro;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelManager : MonoBehaviour
{

    [SerializeField] public LevelProgress levelProgress;
    private List<Coins> listCoins;

    private void Awake()
    {
        listCoins = FindObjectsOfType<Coins>().ToList();
    }

    public void UpdateScore(int newScore)
    {
        levelProgress.ChangeScore(newScore);
        //ScoreText.text = newScore.ToString();
    }
}
