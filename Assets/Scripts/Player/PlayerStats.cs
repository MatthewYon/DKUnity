using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int HealthMax = 50;
    [SerializeField] private int Health;
    [SerializeField] private int level = 1;
    [SerializeField] private int exp;
    [SerializeField] private int current_aim_exp = 10;

    public int getHealth()
    {
        return Health;
    }

    // Update is called once per frame
    void Update()
    {
        if (exp >= current_aim_exp)
            LevelUp();
    }


    private void Death()
    {
        if(Health == 0)
        {

        }
    }

    private void LevelUp()
    {
        exp -= current_aim_exp;
        HealthMax += 10;
        Health = HealthMax;
        ++level;
        current_aim_exp += (current_aim_exp / 4);
    }
}
