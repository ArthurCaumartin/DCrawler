using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _roomPrefabs;
    [Space]
    [SerializeField] private Vector2Int _floorSize;
    [SerializeField] private float _spacing;

    private GameObject[,] _roomArray;

    void Start()
    {
        _roomArray = new GameObject[_floorSize.x, _floorSize.y];

        for (int x = 0; x < _floorSize.x; x++)
        {
            for (int y = 0; y < _floorSize.y; y++)
            {
                GameObject newRoom = Instantiate(_roomPrefabs, transform);
                newRoom.transform.position = new Vector3(x * _spacing, y * _spacing, 0);
                _roomArray[x, y] = newRoom;
            }
        }
    }

    public GameObject GetNextRoom(Vector2Int gridPosition, Vector2 direction)
    {
        if (direction == Vector2.up)
            return _roomArray[gridPosition.x, gridPosition.y + 1];

        if (direction == Vector2.down)
            return _roomArray[gridPosition.x, gridPosition.y - 1];

        if (direction == Vector2.left)
            return _roomArray[gridPosition.x - 1, gridPosition.y];

        if (direction == Vector2.right)
            return _roomArray[gridPosition.x + 1, gridPosition.y];
        
        return null;
    }
}
