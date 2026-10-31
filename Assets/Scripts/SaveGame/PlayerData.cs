using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public PlayerData(int enemiesKilled, int life)
    {
        this.enemiesKilled = enemiesKilled;
        this.life = life;
    }

    public int enemiesKilled;
    public int life;
}