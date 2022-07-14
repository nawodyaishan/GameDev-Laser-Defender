using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 _rawInput;
    [SerializeField] private float moveSpeed = 6f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        Vector3 delta = _rawInput * (moveSpeed * Time.deltaTime);
        transform.position += delta;
    }


    void OnMove(InputValue inputValue)
    {
        _rawInput = inputValue.Get<Vector2>();
        Debug.Log(_rawInput);
    }
}