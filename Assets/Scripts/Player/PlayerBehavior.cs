using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private GameObject shoot;

    void Awake()
    {
        GameManager.Instance.SetPlayer(this.gameObject);
    }

    public void Shoot(InputAction.CallbackContext cx)
    {
        GameObject s = Instantiate(shoot, transform.position, transform.rotation);
    }
}
