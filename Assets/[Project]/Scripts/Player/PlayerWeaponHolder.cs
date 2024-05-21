using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeaponHolder : MonoBehaviour
{
    [SerializeField] private Weapon _currentGun;
    [SerializeField] private List<Weapon> _prefabGunList;
    [SerializeField] private List<Weapon> _instantiateGunList;
    [SerializeField] private int _gunIndex = 0;
    [SerializeField] private AimPointer _aimPointer;

    void Start()
    {
        _aimPointer = transform.parent.GetComponentInChildren<AimPointer>();

        InstantiateGun();
        SwapGun(_gunIndex);
    }

    void Update()
    {
        TrackPointer();
        _currentGun.GetComponentInChildren<SpriteRenderer>().flipY = transform.right.x < 0;
    }

    private void TrackPointer() => transform.right = _aimPointer.GetPointerDireciton(transform.position);

    private void SwapGun(int index)
    {
        foreach (var item in _instantiateGunList)
            item.gameObject.SetActive(false);

        _currentGun = _instantiateGunList[index];
        _currentGun.gameObject.SetActive(true);
    }

    private void InstantiateGun()
    {
        //! Delete all existing instantiate gun
        if (_instantiateGunList.Count > 0)
        {
            foreach (var item in _instantiateGunList)
                Destroy(item);
            _instantiateGunList.Clear();
        }

        for (int i = 0; i < _prefabGunList.Count; i++)
        {
            Weapon newGun = Instantiate(_prefabGunList[i], transform);
            _instantiateGunList.Add(newGun);
        }
    }

    private void Shoot()
    {
        print("Holder Shoot");
        if (_currentGun.CanShoot())
            _currentGun.Shoot(transform);
    }

    //TODO Move le get des value dans l'update
    private void OnShoot(InputValue value)
    {
        if (value.Get<float>() > .5f)
        {
            print("Shoot Input");
            Shoot();
        }
    }

    private void OnGunSwap(InputValue value)
    {
        if (value.Get<float>() < .5)
            return;
        // print("GunSwap");
        _gunIndex = (_gunIndex + 1) % _instantiateGunList.Count;
        SwapGun(_gunIndex);
    }

    private void OnGunHide(InputValue value)
    {
        print("Gun Hide");
        if (value.Get<float>() > .5)
            _currentGun.Hide();
    }
}
