using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] int pointsPerIncrease = 100;
    int XP;
    int level;

    public event Action onLevelUpAction;

    public void GainExperience(int points)
    {
        XP += points;
        if (XP >= GetExperienceThreshold())
        {
            XP = 0;
            level++;

            if (onLevelUpAction != null)
            {
                onLevelUpAction();
            }
        }
    }

    public int GetExperienceThreshold()
    {
        int nextLevel = level + 1;
        return nextLevel * pointsPerIncrease;
    }

    public int GetLevel()
    {
        return level;
    }
}