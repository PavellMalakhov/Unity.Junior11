using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    private Vector3 _target;

    private void Update()
    {
        transform.Translate(_target * _speed * Time.deltaTime, Space.World);
    }

    public void SetTarget(Vector3 target)
    {
        _target = target;
    }
}
