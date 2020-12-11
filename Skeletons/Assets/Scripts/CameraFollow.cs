using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    Transform _camera;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        _camera = gameObject.transform;
        offset = _camera.transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        _camera.position = player.position + offset;

    }
}
