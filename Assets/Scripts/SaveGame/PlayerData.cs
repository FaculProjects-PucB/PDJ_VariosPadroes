using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public PlayerData(int enemiesKilled, int life, Vector3 position, Vector3 rotation)
    {
        this.enemiesKilled = enemiesKilled;
        this.life = life;
        this.position = position;
        this.rotation = rotation;
    }

    public int enemiesKilled;
    public int life;
    public Vector3 position;
    public Vector3 rotation;
}