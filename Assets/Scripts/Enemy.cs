using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Enemy : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime, Space.Self);
    }
}
