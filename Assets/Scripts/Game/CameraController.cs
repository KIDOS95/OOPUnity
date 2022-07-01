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

        transform.position = temp;
    }
}
