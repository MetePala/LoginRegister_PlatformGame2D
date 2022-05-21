using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class APlayerController : MonoBehaviour
{

    private AMoveController _AmoveController;
    public float _hSpeed, _vSpeed,_JumpSpeed;
    public bool _hActive, _vActive,_jActive ;
    [SerializeField]Rigidbody2D rgb;
    [SerializeField] SpriteRenderer _renderer;
    [SerializeField] Animator _playeranim;
    float _attacktime;
    bool attack;
    public static bool _renderFlip;
    private void Awake()
    {
        _AmoveController = new AMoveController();
    }
   
    private void FixedUpdate()
    {
        _Horizontal();
        _Vertical();
        PlayerFlip();

        float _horiziontalvalue1 = Mathf.Abs(Input.GetAxis("Horizontal"));
        _playeranim.SetFloat("__isWalk", _horiziontalvalue1);

      
        if(attack==true)
        {
                _attacktime += Time.deltaTime;
            if(_attacktime>=0.5f)
            {
                _playeranim.SetBool("__isAttack", false);
            }
            if(_attacktime>=0.7f)
            {
                attack = false;
                _attacktime = 0;
            }
                
        }
        

       
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jActive = onGroundCheck.IsOnGroud;
              _Jump();


        }
        if (onGroundCheck.IsOnGroud)
            _playeranim.SetBool("__isJump", false);
        else
            _playeranim.SetBool("__isJump", true);
        if (attack==false)
        {
           
            if (Input.GetKeyDown(KeyCode.O))
            {
                if(onGroundCheck.IsOnGroud)
                {
                _playeranim.SetBool("__isAttack", true);
                attack = true;
                }
                
            }
        }
       
    }


    public void PlayerFlip()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {

            _renderer.flipX = true;
            _renderFlip = true;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            
            _renderer.flipX = false;
            _renderFlip = false;

        }
    }

    public void _Horizontal()
    {
        _AmoveController.HorizontalAxis(this.transform, _hSpeed, _hActive);
    }
    public void _Vertical()
    {
        _AmoveController.VerticalAxis(this.transform, _vSpeed, _vActive);
    }
    public void _Jump()
    {
        _AmoveController.JumpAxis(rgb, _JumpSpeed,_jActive);
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ladder"))
        {
            _vActive = true;
            rgb.gravityScale = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ladder"))
        {
            _vActive = false;
            rgb.gravityScale = 1;
        }
    }


}
