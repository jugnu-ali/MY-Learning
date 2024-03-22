using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Level : MonoBehaviour {

    [SerializeField] int pointsPerLevel = 200;
    int experiencePoints = 0;

    public event Action OnLevelUpAction;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(.2f);
            GainExperience(10);
        }
    }

    public void GainExperience(int points)
    {
        int level = GetLevel();
        experiencePoints += points;

        if(GetLevel() > level)
        {
            if(OnLevelUpAction != null)
            {
                OnLevelUpAction();
            }
        }
    }

    public int GetExperience()
    {
        return experiencePoints;
    }

    public int GetLevel()
    {
        return experiencePoints / pointsPerLevel;
    }
}