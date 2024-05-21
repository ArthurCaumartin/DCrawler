using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject _bulletPrefabs;

    [Header("Stat :")]
    [SerializeField] protected float _bulletSpeed = 1;
    [SerializeField] protected float _damage = 1;
    [SerializeField] protected float _range = 1;
    [SerializeField] protected float _attackPerSecond = 1;

    [Header(" Show / Hide Sprite :")]
    [SerializeField] private Sprite _showSprite;
    [SerializeField] private Sprite _hideSprite;

    protected bool _canShoot;
    private float _attackTime;
    private bool _isGunShow = true;


    void OnEnable()
    {
        Hide(true);
    }

    public virtual void Shoot(Transform holderTransform = null)
    {
        _attackTime = 0;
        if (!_isGunShow)
            Hide(true);
    }

    public bool CanShoot() { return _attackTime > 1; }

    public virtual void Update()
    {
        _attackTime += Time.deltaTime * _attackPerSecond;
        _canShoot = _attackTime >= 1;
    }

    public void Hide(bool forceShow = false)
    {
        print("Hide");
        if (!_showSprite)
            return;

        if (forceShow)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = _showSprite;
            return;
        }

        _isGunShow = !_isGunShow;
        GetComponentInChildren<SpriteRenderer>().sprite = _isGunShow ? _showSprite : _hideSprite;
    }
}
