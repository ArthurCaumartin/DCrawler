using UnityEngine;

public class Door : MonoBehaviour
{
    private Room _room;

    void Start()
    {
        _room = GetComponentInParent<Room>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControler playerControler = other.GetComponent<PlayerControler>();
        if(playerControler)
            _room.SwitchRoom();
    }
}
