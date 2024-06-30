using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField]private ColorChanger _colorChanger;
    private CubeReturner _cubeReturner;
    private bool _isTouched;
    private int _maxDelay = 5;
    private int _minDelay = 2;
    private System.Random _random = new System.Random();

    public void Initialize(CubeReturner cubeReturner)
    {
        _cubeReturner = cubeReturner;
    }

    private void OnEnable()
    {
        _isTouched = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            if (_isTouched)
                return;

            Debug.Log("Касание с платформой");
            _colorChanger.ChangeColor();
            _isTouched = true;
            StartCoroutine(DestroingCubeWithDelay());
        }
    }

    private IEnumerator DestroingCubeWithDelay()
    {
        yield return new WaitForSeconds(_random.Next(_minDelay, _maxDelay));
        _cubeReturner.ReturnCube(this);
    }
}
