using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private ScriptableStats playerStats;

    [SerializeField] private int healthMax = 50;
    [SerializeField] private int health;
    [SerializeField] private int level = 1;
    [SerializeField] private int exp = 0;
    [SerializeField] private int currentAimExp = 10;
    [SerializeField] private int healthPerLevel = 10;

    private void Awake()
    {
        playerStats.maxHealth = healthMax;
        playerStats.health = healthMax;
    }


    // Update is called once per frame
    void Update()
    {
        if (currentAimExp == exp)
        {
            LevelUp();
        }
        if (playerStats.health < 1)
        {
            Death();
        }
    }

    public int getDamage()
    {
        return playerStats.attack;
    }

    private void Death()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("DefeatScene", LoadSceneMode.Single);
    }

    private void LevelUp()
    {
        exp -= currentAimExp;
        healthMax += healthPerLevel;
        health = healthMax;
        ++level;
        currentAimExp *= (currentAimExp / 4);
    }
}
