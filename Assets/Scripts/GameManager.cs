using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float _distance;
    //[SerializeField] [Range(0,3)]int _objectForm;
    //[SerializeField]List<Mesh> _Meshes;
    [Tooltip("0: cube form 1: Capsule 2: Cylinder 3: Sphere")]
    [SerializeField][Range(0,3)] int _typeObj;
    [SerializeField] List<GameObject> _object;


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
        //_object.GetComponent<MeshFilter>().mesh = _Meshes[_objectForm];
        Instantiate(_object[_typeObj],_spawn,Quaternion.identity);
    }
}
