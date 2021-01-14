using UnityEngine;

[CreateAssetMenu(fileName = "New Stats", menuName = "Stats Object/Stats", order = 51)]
[System.Serializable]
public class ScriptableStats : ScriptableObject
{
    public int maxHealth;
    public int health;
    public int attack;
    public int defense;
    public int strength;
    public int vitality;
    public int intelligence;
}
