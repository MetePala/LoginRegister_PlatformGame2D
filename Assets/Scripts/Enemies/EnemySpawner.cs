using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]float _spawntime;
    [SerializeField] GameObject _eagle;
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        _spawntime += Time.deltaTime;
        if(_spawntime >= 5)
        {
            EagleSpawn();
            _spawntime = 0;
        }
    }

    void EagleSpawn()
    {
        Instantiate(_eagle, transform.position, _eagle.transform.rotation, transform);
    }

}
