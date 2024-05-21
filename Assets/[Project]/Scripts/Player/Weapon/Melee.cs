using DG.Tweening;
using UnityEngine;

public class Melee : Weapon
{
    [SerializeField] private float _rotateSpeed = 50;
    private Vector2 _worldSpaceTarget;
    private bool _canThrow = true;
    private SpriteRenderer _sprite;

    void Start()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    public override void Update()
    {
        base.Update();
        
        if (!_canThrow)
        {
            _sprite.transform.Rotate(new Vector3(0, 0, Time.deltaTime * _bulletSpeed * _rotateSpeed));
        }
        else
            _sprite.transform.localEulerAngles = Vector3.zero;
    }

    public override void Shoot(Transform holderTransform = null)
    {
        base.Shoot(holderTransform);
        if (!_canThrow)
            return;

        _canThrow = false;
        _worldSpaceTarget = transform.TransformPoint(transform.localPosition + new Vector3(_range, 0, 0));
        // Debug.DrawLine(transform.position, _worldSpaceTarget, Color.red, 3f);

        transform.DOMove(_worldSpaceTarget, _bulletSpeed)
        .SetSpeedBased()
        .OnComplete(() =>
        {
            transform.DOLocalMove(Vector3.zero, _bulletSpeed)
            .SetSpeedBased()
            .OnComplete(() => _canThrow = true);
        });
    }
}
