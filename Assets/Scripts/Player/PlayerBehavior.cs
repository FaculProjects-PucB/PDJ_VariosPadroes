using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private GameObject shoot;
    [SerializeField] private float shootInterval;

    private bool isShooting;
    private float cooldown;

    void Awake()
    {
        GameManager.Instance.SetPlayer(this.gameObject);
    }

    void Start()
    {
        isShooting = false;
        cooldown = 0;
    }

    void Update()
    {
        cooldown -= Time.deltaTime;
        TryShoot();
    }

    public void Shoot(InputAction.CallbackContext cx)
    {
        if (cx.started)
        {
            isShooting = true;
            return;
        }

        if (cx.canceled)
        {
            isShooting = false;
            return;
        }
    }

    public void TryShoot()
    {
        if (cooldown > 0 || !isShooting) return;

        cooldown = shootInterval;

        Ray mouseRay = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(mouseRay, out RaycastHit hit))
        {
            GameObject s = Instantiate(shoot, transform.position, Quaternion.identity);
            s.transform.LookAt(new Vector3(
                hit.point.x,
                s.transform.position.y,
                hit.point.z
            ));
        }
    }

}
