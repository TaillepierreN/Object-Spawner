using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject _object;
    [SerializeField] int _objectLimit;
    [SerializeField] float _spawnRadius, _spawnRate;
    public List<GameObject> spawnedObjects;

    Vector3 _spawnPoints;
    Color[] color = { Color.blue, Color.green, Color.yellow, Color.red, Color.white };
    GameObject _spawnedObject;
    int _numberOfObjects, _tableCount;


    private void Start()
    {

        InvokeRepeating("SpawnInSphere", 1f, _spawnRate);


    }

    private void SpawnInSphere()
    {
        if (_numberOfObjects < _objectLimit)
        {
            SpawnObjects();
            _numberOfObjects++;
        }
        else
        {
            if (_tableCount < _objectLimit - 1)
            {
                MoveObject();
                _tableCount++;
            } else {
                MoveObject();
                _tableCount = 0;
            }
        }

    }
    private void SpawnObjects()
    {
        _spawnPoints = Random.insideUnitSphere * _spawnRadius;
        _spawnedObject = Instantiate(_object, _spawnPoints, Quaternion.identity);
        _spawnedObject.GetComponent<Renderer>().material.color = color[Random.Range(0, 4)];
        spawnedObjects.Add(_spawnedObject);
    }
    private void MoveObject()
    {
        spawnedObjects[_tableCount].transform.position = Random.insideUnitSphere * _spawnRadius;
    }

}
