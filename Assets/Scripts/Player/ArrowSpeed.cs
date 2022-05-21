using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpeed : MonoBehaviour
{
    Rigidbody2D _rigid2;
    [SerializeField] float _speed;
   
    private void Awake()
    {
        _rigid2 = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        ArrowMove();
    }
    private void FixedUpdate()
    {
       
    }
    void ArrowMove()
    {
        
            if ( APlayerController._renderFlip == false)
                {
                _rigid2.velocity = Vector2.right * _speed;
               }
            else
             _rigid2.velocity = Vector2.left * _speed;

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("frog"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        if (col.gameObject.CompareTag("foreground"))
        {
            Destroy(gameObject);
        }
       
    }
}
