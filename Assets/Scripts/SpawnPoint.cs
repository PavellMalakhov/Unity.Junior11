using UnityEngine;

public class SpawnPoint : MonoBehaviour 
{
    [SerializeField] private Enemy _prefabEnemy;
    [SerializeField] private GameObject _target;

    public void InstEnemy()
    {
        Enemy enemy = Instantiate(_prefabEnemy);
        enemy.transform.position = transform.position;
        enemy.SetTarget(_target);
    }
}
