using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class disparo : MonoBehaviour
{
    [SerializeField] private Transform _bulletPrefab;
    [SerializeField] private PlayControl _gameControls;
    private Renderer[] _renderers;

    private void Awake()
    {
        _gameControls = new PlayControl();
    }

    private void OnEnable()
    {
        _renderers = GetComponentsInChildren<Renderer>(); //for destruct

        _gameControls.GamePlay.Shoot.performed += Fire;
        _gameControls.GamePlay.Enable();
    }

    private void OnDisable()
    {
        _gameControls.GamePlay.Shoot.performed -= Fire;
        _gameControls.GamePlay.Disable();
    }

    private void Fire(InputAction.CallbackContext obj)
    {
        Instantiate(_bulletPrefab, transform.position, transform.rotation);
    }

}
