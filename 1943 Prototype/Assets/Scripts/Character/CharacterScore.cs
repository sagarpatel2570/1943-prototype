using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScore : MonoBehaviour, IGiveScore
{
    public int pointsGiven;

    public void GiveScore()
    {
        ScoreSystem.AddScore(pointsGiven);
    }
}
