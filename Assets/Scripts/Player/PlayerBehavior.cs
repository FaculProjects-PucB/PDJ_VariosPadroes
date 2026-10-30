using System;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{


    void Awake()
    {
        GameManager.Instance.SetPlayer(this.gameObject);
    }
}
