using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int healthMax = 50;
    [SerializeField] private int health;
    [SerializeField] private int level = 1;
    [SerializeField] private int exp;
    [SerializeField] private int currentAimExp = 10;
    [SerializeField] private int healthPerLevel = 10;

    public int getHealth()
    {
        return health;
    }

    // Update is called once per frame
    void Update()
    {
        if (exp >= currentAimExp)
            LevelUp();
    }


    private void Death()
    {
        if(health == 0)
        {

        }
    }

    private void LevelUp()
    {
        exp -= currentAimExp;
        healthMax += healthPerLevel;
        health = healthMax;
        ++level;
        currentAimExp += (currentAimExp / 4);
    }
}
