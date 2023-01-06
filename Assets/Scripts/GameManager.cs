using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _cube;
    [SerializeField] float _distance;
    Camera _camera;
    Vector3 _spawn;
    Vector3 _mousePos;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SpawnCube();
        }
    }
    private void SpawnCube()
    {
        _mousePos = Input.mousePosition;
        _mousePos.z = _distance;
        _spawn = _camera.ScreenToWorldPoint(_mousePos);
        Debug.Log(_spawn);
        Instantiate(_cube,_spawn,Quaternion.identity);
    }
}
