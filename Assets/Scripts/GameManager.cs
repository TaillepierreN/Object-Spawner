using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //[SerializeField] [Range(0,3)]int _objectForm;
    //[SerializeField]List<Mesh> _Meshes;
    [SerializeField] float _distance;
    [Tooltip("0: cube form 1: Capsule 2: Cylinder 3: Sphere")]
    [SerializeField][Range(0, 3)] int _typeObj;
    [SerializeField] List<GameObject> _object;
    [SerializeField] int _maxObjectsLimit;
    int _objectLimit;
    public List<GameObject> _spawnedItems;
    Camera _camera;
    Vector3 _spawn;
    Vector3 _mousePos;

    int _tableCount;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            checkLimit();
        }
    }
    private void checkLimit()
    {
        if (_objectLimit < _maxObjectsLimit)
        {
            SpawnItem();
            _objectLimit++;
        }
        else
        {
            //Destroy(_spawnedItems[0]);
            //_spawnedItems.Remove(_spawnedItems[0]);
            //SpawnItem();
            GetMousePos();
            if (_tableCount < _maxObjectsLimit -1)
            {
                MoveOldObject();
                _tableCount++;
             }
            else{
                Debug.Log(_tableCount);
                MoveOldObject();
                _tableCount = 0;
            }
        }
    }
    private void SpawnItem()
    {
        GetMousePos();
        _spawn = _camera.ScreenToWorldPoint(_mousePos);
        //_object.GetComponent<MeshFilter>().mesh = _Meshes[_objectForm];
        var spawned = Instantiate(_object[_typeObj], _spawn, Quaternion.identity);
        _spawnedItems.Add(spawned);
    }
    private Vector3 GetMousePos()
    {
        _mousePos = Input.mousePosition;
        _mousePos.z = _distance;
        return _mousePos;
    }
    private void MoveOldObject()
    {
        _spawnedItems[_tableCount].transform.position = _camera.ScreenToWorldPoint(_mousePos);
    }

}

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
    //ressource
    //https://catlikecoding.com/unity/tutorials/object-management/spawn-zones/

}