using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hero : MonoBehaviour
{
    //����
    #region 
    [SerializeField] private float _speed;
    [SerializeField] private float _forceJump;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Vector3 _groundCheckPosition;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private float _lenghtOfTheJump;
    [SerializeField] private int _damageJumpSpeed;
    

    private Vector2 _direction;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private static readonly int _is_GroundKey = Animator.StringToHash("Is_Ground");
    private static readonly int _is_RunningKey = Animator.StringToHash("Is_Running");
    private static readonly int _is_VerticalVelocityKey = Animator.StringToHash("vertical_velocity");

    #endregion

    /// <summary>
    /// ��������� ������� ����������� ���� ��������� 
    /// </summary>
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>(); 
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    /// <summary>
    /// ��������� ����������� ������������ 
    /// </summary>
    /// <param name="direction"></param>
    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private void FixedUpdate()
    {   //����� ������ ������������ ������
        PlayerMovement();
        //����� ��������
        Animation();
    }

    /// <summary>
    /// �������� �������, ��� �������� ��������� �� �����
    /// </summary>
    /// <returns></returns>
    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position + _groundCheckPosition, _groundCheckRadius, Vector2.down, 0, _groundLayer);
        return hit.collider != null;
    }
    /// <summary>
    /// ��������� ������� ����� ��� �������������� ������� ���������� �� �����
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = IsGrounded() ? Color.green : Color.red;
        Gizmos.DrawSphere(transform.position + _groundCheckPosition, _groundCheckRadius);
    }

    /// <summary>
    /// ������� ��� ������ ��������
    /// </summary>
    private void Animation()
    {
        _animator.SetBool(_is_GroundKey, IsGrounded());
        _animator.SetBool(_is_RunningKey, _direction.x != 0);
        _animator.SetFloat(_is_VerticalVelocityKey, _rigidbody.velocity.y);
        //������� ��� ����� ����������� �������
        if (_direction.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_direction.x < 0) _spriteRenderer.flipX = true;
    }

    /// <summary>
    /// ����� ���������� ������ � ������������ ������
    /// </summary>
    private void PlayerMovement()
    {
        //������������ ������
        _rigidbody.velocity = new Vector2(_direction.x * _speed, _rigidbody.velocity.y);

        //������� ������
        bool isJumping = _direction.y > 0;
        if (isJumping)
        {
            if (IsGrounded()) _rigidbody.AddForce(Vector2.up * _forceJump, ForceMode2D.Impulse);
        }
        //������ � ���������� �� ������� ������� �������
        else if (_rigidbody.velocity.y > 0) { _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * _lenghtOfTheJump); }
    }

    public void TakeDamage()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _damageJumpSpeed);
    }


}

