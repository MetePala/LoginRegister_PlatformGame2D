using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onGroundCheck : MonoBehaviour
{
    [SerializeField] Transform[] _translates; //Sprite'�n ayaklar�n�n alt�nda 3 tane yoklay�c� oldu�u i�in.
    [SerializeField] bool _IsOnGroud = false;
    [SerializeField] float _maxDistance;
    [SerializeField] LayerMask _layerMask;
    public static bool IsOnGroud;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform footTransform in _translates)
        {
            CheckFootOnGroud(footTransform);

            if (_IsOnGroud) break;
        }
        IsOnGroud = _IsOnGroud;

    }

    void CheckFootOnGroud(Transform footTransform)
    {
        RaycastHit2D hit = Physics2D.Raycast(footTransform.position, footTransform.forward, _maxDistance, _layerMask);
        Debug.DrawRay(footTransform.position, footTransform.forward * _maxDistance, Color.red);

        if (hit.collider != null)
        {
            _IsOnGroud = true;
        }
        else
        {
        _IsOnGroud = false;
        }
            

    }
}
