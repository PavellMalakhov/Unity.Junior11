using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabEnemy;
    [SerializeField] private GameObject _prefabTarget;
    [SerializeField] private Spawn[] _spawnes;
    [SerializeField] private float _delay = 2;
    [SerializeField] private int _numberNextSpawner;

    private void Awake()
    {
        _spawnes = FindObjectsOfType<Spawn>();
    }

    private void Start()
    {
        StartCoroutine(SpawnPrefab(_delay));
    }

    private IEnumerator SpawnPrefab(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (enabled)
        {
            yield return wait;

            _numberNextSpawner = Random.Range(0, _spawnes.Length);
            _spawnes[_numberNextSpawner].transform.LookAt(_prefabTarget.transform);

            GameObject enemy = Instantiate(_prefabEnemy);
            enemy.transform.position = _spawnes[_numberNextSpawner].transform.position;
            enemy.transform.rotation = _spawnes[_numberNextSpawner].transform.rotation;
        }
    }
}
