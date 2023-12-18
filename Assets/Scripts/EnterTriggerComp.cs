using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnterTriggerComp : MonoBehaviour
{
    [SerializeField] private string _tag;
    [SerializeField] private UnityEvent _action;
    /// <summary>
    /// Сравниваем тег объекта, который задевает триггер и вызвваем метод перезапуска уровня через события юнити
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(_tag))
        {
            _action?.Invoke();
        }
    }
    
}
