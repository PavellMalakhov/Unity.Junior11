using System.Collections;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private bool _spawnerOn = true;
    
    public static event Action<int> NextCube;
    private Spawner[] _spawners;
    private int _numberNextSpawner;
    private float _delay = 1;

    private void Awake()
    {
        _spawners = FindObjectsOfType<Spawner>();
    }

    private void Start()
    {
        StartCoroutine(SpawnerEnemy(_delay));
    }

    private void OnEnable()
    {
        Spawner.NextCube += SetNextSpawner;
    }

    private void OnDisable()
    {
        Spawner.NextCube -= SetNextSpawner;
    }

    private void SetNextSpawner(int numberNextSpawner)
    {
        _numberNextSpawner = numberNextSpawner;
    }

    private IEnumerator SpawnerEnemy(float delay)
    {
        while (_spawnerOn)
        {
            var wait = new WaitForSeconds(delay);

            yield return wait;

            if (this.gameObject.name == _spawners[_numberNextSpawner].name)
            {
                Quaternion angle = Quaternion.identity;
                angle.eulerAngles = new Vector3(0, UnityEngine.Random.value * 360, 0);
                transform.rotation = angle;

                GameObject enemy = Instantiate(_enemy);
                enemy.transform.position = transform.position;
                enemy.transform.rotation = transform.rotation;

                _numberNextSpawner = UnityEngine.Random.Range(0, _spawners.Length);

                yield return wait;

                NextCube?.Invoke(_numberNextSpawner);
            }
            else
            {
                yield return wait;
            }
        }
    }
}
