using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private int score = 0;

    public void ChageScore(int amount)
    {
        score += amount;
    }
}
