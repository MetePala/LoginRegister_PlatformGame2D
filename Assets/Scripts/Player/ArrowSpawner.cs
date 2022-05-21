using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    [SerializeField] GameObject _arrow;
    public float time;
    private void FixedUpdate()
    {
        time += Time.deltaTime;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            TuzakSpawnStart();
        }
    }

    void TuzakSpawnStart()
    {
        if (time >= 0.7f && onGroundCheck.IsOnGroud) 
        {
          if(APlayerController._renderFlip == true)  
            {
                Instantiate(_arrow, transform.position, Quaternion.Euler(_arrow.transform.rotation.x, _arrow.transform.rotation.y, 180), transform);
            }
              else
            {
                Instantiate(_arrow, transform.position, _arrow.transform.rotation, transform);
            }
            time = 0;
        }

    }
}
