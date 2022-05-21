using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSpeed : MonoBehaviour
{
    Rigidbody2D _rigid2;
    [SerializeField] float _speed;
    private void Awake()
    {
        _rigid2 = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        EagleMove();
    }
    private void FixedUpdate()
    {

    }
    void EagleMove()
    {
           if(this.gameObject.CompareTag("eagle"))
        _rigid2.velocity = Vector2.right * _speed;
           else if(this.gameObject.CompareTag("lion"))
        {
            _rigid2.velocity = Vector2.left * _speed;
        }
    }

   
}
