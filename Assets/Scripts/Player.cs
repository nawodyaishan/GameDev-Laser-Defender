using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    private Vector2 _rawInput;
    [SerializeField] private float moveSpeed = 6f;
    private Vector2 _minBound;
    private Vector2 _maxBound;

    [SerializeField] private float leftPadding;
    [SerializeField] private float rightPadding;
    [SerializeField] private float topPadding;
    [SerializeField] private float bottomPadding;

    private Shooter _shooter;

    private void Awake()
    {
        _shooter = GetComponent<Shooter>();
    }


    // Start is called before the first frame update
    void Start()
    {
        InitBounds();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        Vector2 delta = _rawInput * (moveSpeed * Time.deltaTime);
        Vector2 newPos = new Vector2();

        var position = transform.position;
        newPos.x = Mathf.Clamp(position.x + delta.x, _minBound.x + leftPadding, _maxBound.x - rightPadding);
        newPos.y = Mathf.Clamp(position.y + delta.y, _minBound.y + bottomPadding, _maxBound.y - topPadding);
        transform.position = newPos;
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        _minBound = mainCamera.ViewportToWorldPoint(Vector2.zero);
        _maxBound = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void OnMove(InputValue inputValue)
    {
        _rawInput = inputValue.Get<Vector2>();
    }

    void OnFire(InputValue fireInputValue)
    {
        if (_shooter)
        {
            _shooter.isFiring = fireInputValue.isPressed;
        }
        
    }
    
    
    
}