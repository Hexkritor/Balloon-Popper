using System;
using UnityEngine;

public class BalloonScoreLogic : MonoBehaviour
{
    [SerializeField]
    private int tapScore;
    [SerializeField]
    private int killScore;

    public event Action<int> OnGainScore = delegate { };

    public void AddTapScore()
    {
        OnGainScore(tapScore);
    }

    public void AddKillScore()
    {
        OnGainScore(killScore);
    }
}
