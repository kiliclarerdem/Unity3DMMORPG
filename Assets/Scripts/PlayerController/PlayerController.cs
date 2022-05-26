using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Player Config")]

    [SerializeField] Transform _playerTransform;
    [SerializeField] float _speed, _jumpForce, _runSpeed;
    [SerializeField] Rigidbody _playerRigidbody;
    [SerializeField] Animator _animator;
    [SerializeField] GameObject _player;
    bool _isJumpActive, _surunme, _isRun;
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

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.W))
        {
            _surunme = true;
        }
        else
        {
            _surunme = false;
        }

        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
        {
            _isRun = true;

        }
        else
        {
            _isRun = false;
        }

    }
    private void FixedUpdate()
    {
        Walk();
        Jump();
        Surunme();
        Run();
    }

    void Walk()
    {

        _moveController.Horizontal(_playerTransform, _speed);
        _moveController.Vertical(_playerTransform, _speed);
        _animator.SetFloat("__Walk", Mathf.Abs(Input.GetAxis("Vertical")));


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


    void Surunme()
    {
        if (_surunme)
        {
            _player.GetComponent<CapsuleCollider>().direction = 2;
            _player.GetComponent<CapsuleCollider>().center = new Vector3(0, 0.40f);
            _animator.SetBool("__Surunme", true);
        }
        else
        {
            _player.GetComponent<CapsuleCollider>().direction = 1;
            _player.GetComponent<CapsuleCollider>().center = new Vector3(0, 0.9581256f);
            _animator.SetBool("__Surunme", false);
        }
    }

    void Run()
    {
        if (_isRun)
        {
            _moveController.Horizontal(_playerTransform, _runSpeed);
            _moveController.Vertical(_playerTransform, _runSpeed);
            _animator.SetBool("__isRun", true);
        }
        else
        {
            _animator.SetBool("__isRun", false);
        }
        
    }


    


}
