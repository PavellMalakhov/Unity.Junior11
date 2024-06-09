using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefabEnemy;
    [SerializeField] private GameObject Target;
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private float _delay = 2;
    [SerializeField] private int _numberNextSpawner;

    private void Awake()
    {
        _spawnPoints = FindObjectsOfType<SpawnPoint>();
    }

    private void Start()
    {
        StartCoroutine(Spawn(_delay));
    }

    private IEnumerator Spawn(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (enabled)
        {
            yield return wait;

            _numberNextSpawner = Random.Range(0, _spawnPoints.Length);
            _spawnPoints[_numberNextSpawner].transform.LookAt(Target.transform);

            Enemy enemy = Instantiate(_prefabEnemy);
            enemy.transform.SetPositionAndRotation(_spawnPoints[_numberNextSpawner].transform.position, _spawnPoints[_numberNextSpawner].transform.rotation);
        }
    }
}
