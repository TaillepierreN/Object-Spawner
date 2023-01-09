using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject _object;
    [SerializeField] GameObject _spawnAreaCenter;
    [SerializeField] float _spawnRadius;
    

    public Vector3 SpawnPoints{
        get{
            return Random.insideUnitSphere * _spawnRadius;
        }
    }

    private void Start() {
        Debug.Log("hello");
    }
    //ressource
    //https://catlikecoding.com/unity/tutorials/object-management/spawn-zones/
}
