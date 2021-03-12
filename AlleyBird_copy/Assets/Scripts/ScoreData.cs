using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreData", menuName = "Score Data", order = 51)]
public class ScoreData : ScriptableObject
{
    [SerializeField] public int bestScore;
    [SerializeField] public int previousScore;
    [SerializeField] public int coins;
}
