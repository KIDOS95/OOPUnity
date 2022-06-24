using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = Player.Instance;
    }


    private void LateUpdate()
    {
        Vector3 temp = transform.position;
        if (_player != null) 
        temp.x = _player.transform.position.x;
        temp.x = Mathf.Clamp(temp.x, -3f, 3f);

        transform.position = temp;
    }
}
