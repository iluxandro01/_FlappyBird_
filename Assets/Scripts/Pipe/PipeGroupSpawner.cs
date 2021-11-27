using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeGroupSpawner : MonoBehaviour
{
    [SerializeField] private PipeGroupFactory _pipeGroupFactory;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnRate; 
    [Range(0, 5)] [SerializeField] private float _maxShiftY;

    public void StartSpawner()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(_spawnRate);
        }
    }

    private void Spawn()
    {
        var pipeGroup = _pipeGroupFactory.Create();

        SetSpawnPosition(pipeGroup);
    }

    private void SetSpawnPosition(PipeGroup pipeGroup)
    {
        var pointPosition = _spawnPoint.position;
        var shiftedSpawnPosition = new Vector2(pointPosition.x, pointPosition.y + GetShiftY());

        pipeGroup.transform.position = shiftedSpawnPosition;
    }

    private float GetShiftY()
    {
        return -Random.Range(0, _maxShiftY);
    }
}