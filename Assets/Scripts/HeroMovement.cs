using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroMovement : MonoBehaviour
{
    [SerializeField] private Hero _hero;
    HeroInput _heroInput;
    


    /// <summary>
    ///  ���������� inputPlayer � �������� 
    /// </summary>
    private void Awake()
    {
        _heroInput = new();
        _heroInput.Hero.HorizontalMovement.performed += OnHorizontalMovement;
        _heroInput.Hero.HorizontalMovement.canceled += OnHorizontalMovement;
    }
    private void OnEnable()
    {
        _heroInput.Enable();
    }
    
    /// <summary>
    /// ����� ��� ������� playerInput
    /// </summary>
    /// <param name="context"></param>
    public void OnHorizontalMovement(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();
        _hero.SetDirection(direction);
    }

    /// <summary>
    /// ����������� ������ ����� ���
    /// </summary>
    //void Update()
    //{
    //    var horizontal = Input.GetAxis("Horizontal");
    //    _hero.SetDirection(horizontal);
    //}

}
