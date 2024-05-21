using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public void Fall()
    {
        print("Fall");
        if(_playerMovement.IsDashing)
            return;
        
        Destroy(gameObject);
        GameManager.instance.ResetGame();
    }

    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }
}
