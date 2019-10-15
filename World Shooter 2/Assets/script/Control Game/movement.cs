using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    //[SerializeField] private Transform _bulletPrefab;
    [SerializeField] private float _speed = 3f;
    //[SerializeField] private Transform _player;

    [SerializeField] private PlayControl _gameControls;
    private Vector2 _moveAxis;
    private Renderer[] _renderers;
    //private Vector3 _angles;

    private void Awake()
    {
        _gameControls = new PlayControl();
    }

    private void OnEnable()
    {
        _renderers = GetComponentsInChildren<Renderer>(); //for destruct

        //_gameControls.GamePlay.Shoot.performed += Fire;
        //_gameControls.GamePlay.Enable();

        _gameControls.GamePlay.Move.performed += MoveHorinzontal;
        _gameControls.GamePlay.Move.Enable();
    }

    private void OnDisable()
    {
        //_gameControls.GamePlay.Shoot.performed -= Fire;
        //_gameControls.GamePlay.Disable();

        _gameControls.GamePlay.Move.performed -= MoveHorinzontal;
        _gameControls.GamePlay.Move.Disable();
    }

    private void MoveHorinzontal(InputAction.CallbackContext obj)
    {
        _moveAxis = obj.ReadValue<Vector2>();
        Debug.Log($"Move axis {_moveAxis}");
    }

    //private void Fire(InputAction.CallbackContext obj)
    //{
    //    Instantiate(_bulletPrefab, transform.position, transform.rotation);
    //}

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_moveAxis.x * Time.deltaTime * _speed, 0, _moveAxis.y * Time.deltaTime * _speed);
    }
}
