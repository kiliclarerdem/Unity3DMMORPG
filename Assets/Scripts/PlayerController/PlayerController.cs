using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Player Config")] 

    [SerializeField] Transform _playerTransform;
    [SerializeField] float _speed, _jumpForce;
    [SerializeField] Rigidbody _playerRigidbody;
    [SerializeField] Animator _animator;
    bool _isJumpActive;
    MoveController _moveController;


    private void Awake()
    {
        _moveController = new MoveController();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJumpActive = true;
        }
        else
        {
            _isJumpActive = false;
        }
    }
    private void FixedUpdate()
    {
        Wall();
        Jump();
    }

    void Wall()
    {
        _moveController.Horizontal(_playerTransform, _speed);
        _moveController.Vertical(_playerTransform, _speed);
        
    }

    void Jump()
    {
        if (_isJumpActive)
        {
            _moveController.Jump(_playerRigidbody, _jumpForce);
            _animator.SetBool("__isJump", true);
        }
        else
        {
            _animator.SetBool("__isJump", false);
        }
        
    }





}
