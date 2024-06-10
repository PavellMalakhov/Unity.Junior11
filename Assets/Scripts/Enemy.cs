using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    private GameObject _target;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target.transform.position, _speed * Time.deltaTime);
    }

    public void SetTarget(GameObject target)
    {
        _target = target;
    }
}
