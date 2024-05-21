using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidZone : MonoBehaviour
{
    [SerializeField] private string _triggerTag = "Player";
    private PlayerControler _other;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != _triggerTag)
            return;

        _other = other.GetComponent<PlayerControler>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        _other?.Fall();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        _other = null;
    }
}
