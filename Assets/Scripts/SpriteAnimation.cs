using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteAnimation : MonoBehaviour
{
   
    [SerializeField] private int _frameRate;
    [SerializeField] private bool _loop;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private UnityEvent OnComplete;

    private SpriteRenderer _spriteRenderer;
    private float _secondsPerFrame;
    private int _currentSpriteIndex;
    private float _nextFrameTime;

    private bool _isPlaying=true;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
       
    }

    private void OnEnable()
    {
        _secondsPerFrame = 1f / _frameRate;
        _nextFrameTime = Time.time + _secondsPerFrame;
        _currentSpriteIndex = 0;
    }

    private void Update()
    {
        if (!_isPlaying|| _nextFrameTime > Time.time) return;

        if (_currentSpriteIndex >= _sprites.Length)
        {
            if (_loop)
            {
                _currentSpriteIndex = 0;
            }
            else
            {
                _isPlaying = false;
                OnComplete?.Invoke();
            }
            
        }
        _spriteRenderer.sprite = _sprites[_currentSpriteIndex];
        _nextFrameTime += _secondsPerFrame;
        _currentSpriteIndex++;
    }
}
