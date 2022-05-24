using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject _player;

  
    private void FixedUpdate()
    {

        gameObject.transform.position = new Vector3(_player.transform.position.x, 0, -10);


        var targetPos = new Vector3(_player.transform.position.x, 0, -10);
        var targetXPos = Mathf.Clamp(targetPos.x, 1.3f, 34.8f);
        transform.position = new Vector3(targetXPos, targetPos.y, targetPos.z);
     
        if (_player.transform.position.y <= -4.9f)
        {
            targetPos = new Vector3(targetXPos, _player.transform.position.y+5, targetPos.z);
            var targetYPos = Mathf.Clamp(targetPos.y, -22f, 0.3f);
            transform.position = new Vector3(targetXPos, targetYPos, targetPos.z);
        }
    }
}
