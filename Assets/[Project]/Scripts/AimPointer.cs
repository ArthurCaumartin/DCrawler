using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimPointer : MonoBehaviour
{
    [SerializeField] private float _controlerPointerDistance = 3f;
    private Camera _mainCam;
    private Transform _pointer;

    void Start()
    {
        _mainCam = Camera.main;
        _pointer = transform.GetChild(0);
        _pointer.parent = null;
    }

    public Vector2 GetPointerDireciton(Vector3 position)
    {
        return (_pointer.position - position).normalized;
    }

    private void MouseAim(Vector2 worldPos)
    {
        _pointer.position = worldPos;
        _pointer.position = new Vector3(_pointer.position.x, _pointer.position.y, 0);
    }

    private void ControlerAim(Vector2 direction)
    {
        _pointer.position = direction * _controlerPointerDistance;
        _pointer.position = new Vector3(_pointer.position.x, _pointer.position.y, 0);
    }

    private void OnControlerAim(InputValue value)
    {
        ControlerAim(value.Get<Vector2>());
    }

    private void OnMouseAim(InputValue value)
    {
        MouseAim(_mainCam.ScreenToWorldPoint(value.Get<Vector2>()));
    }
}
