using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AMoveController : IMover
{
    public float Horizontal => Input.GetAxis("Horizontal") * Time.deltaTime;
    public float Vertical => Input.GetAxis("Vertical") * Time.deltaTime;

    public float Jump => Input.GetAxis("Jump");

    public void HorizontalAxis(UnityEngine.Transform _transform, float _hSpeed, bool _isHorizontalActive)
    {
       
        switch (_isHorizontalActive)
        {
            case true:
                _transform.position += new Vector3(Horizontal * _hSpeed, 0);
                break;

            default:
                _isHorizontalActive = false;
                break;
        }
       
    }
    public void VerticalAxis(UnityEngine.Transform _transform, float _vSpeed, bool _isVerticalActive)
    {

        switch (_isVerticalActive)
        {
            case true:
                _transform.position += new Vector3(0,Vertical * _vSpeed);
                break;

            default:
                _isVerticalActive = false;
                break;
        }

    }
    public void JumpAxis(Rigidbody2D _rjump, float _vSpeed , bool _isJumpActive)
    {
        switch (_isJumpActive)
        {
            case true:
                _rjump.AddForce(Vector2.up * _vSpeed);
                break;

            default:
                _isJumpActive = false;
                break;
        }

    }
}
