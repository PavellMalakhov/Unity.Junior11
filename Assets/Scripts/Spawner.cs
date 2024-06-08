using System.Collections;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    public static event Action<int> NumberNextSpawnerChanged;
    private Spawner[] _spawners;
    private int _numberNextSpawner;
    private float _delay = 1;

    private void Awake()
    {
        _spawners = FindObjectsOfType<Spawner>();
    }

    private void Start()
    {
        StartCoroutine(SpawnPrefab(_delay));
    }

    private void OnEnable()
    {
        Spawner.NumberNextSpawnerChanged += SetNextSpawner;
    }

    private void OnDisable()
    {
        Spawner.NumberNextSpawnerChanged -= SetNextSpawner;
    }

    private void SetNextSpawner(int numberNextSpawner)
    {
        _numberNextSpawner = numberNextSpawner;
    }

    private IEnumerator SpawnPrefab(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (enabled)
        {
            yield return wait;

            if (this == _spawners[_numberNextSpawner])
            {
                Quaternion angle = Quaternion.identity;
                angle.eulerAngles = new Vector3(0, UnityEngine.Random.value * 360, 0);
                transform.rotation = angle;

                GameObject enemy = Instantiate(_prefab);
                enemy.transform.position = transform.position;
                enemy.transform.rotation = transform.rotation;

                yield return wait;

                _numberNextSpawner = UnityEngine.Random.Range(0, _spawners.Length);
                NumberNextSpawnerChanged?.Invoke(_numberNextSpawner);
            }
            else
            {
                yield return wait;
            }
        }
    }
}
