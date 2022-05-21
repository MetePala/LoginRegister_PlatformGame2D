using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionSpawner : MonoBehaviour
{

    [SerializeField] float _spawntime;
    [SerializeField] GameObject _arrow;
    void Start()
    {

    }

    private void FixedUpdate()
    {
        _spawntime += Time.deltaTime;
        if (_spawntime >= 2.4f)
        {
            EagleSpawn();
            _spawntime = 0;
        }
    }

    void EagleSpawn()
    {
        Instantiate(_arrow, transform.position, _arrow.transform.rotation, transform);
    }
}
