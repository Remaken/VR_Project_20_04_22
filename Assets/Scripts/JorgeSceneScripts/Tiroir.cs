using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiroir : BaseInteractable
{
    private Vector3 _controllerDirection;
    private Vector3 _poignéePosition;
    private Quaternion _tiroirRotation;
    private Quaternion _tiroirRotationBase;
    private Vector3 _currentControllerPos;
    private Vector3 _previousControllerPos;

    private void Awake()
    {
        _poignéePosition = this.gameObject.GetComponent<Tiroir>().transform.position;
        _tiroirRotation = this.gameObject.GetComponent<Tiroir>().transform.rotation;
        _tiroirRotationBase = new Quaternion(_tiroirRotation.x, _tiroirRotation.y, _tiroirRotation.z, _tiroirRotation.w);
    }
    protected override void ContinuousAction(Vector3 interactorPos)
    {
        base.ContinuousAction(interactorPos);
        if (_previousControllerPos == null || _previousControllerPos == Vector3.zero)
        {
            _previousControllerPos = interactorPos;
        }
        _currentControllerPos = interactorPos;
        _controllerDirection = _currentControllerPos - _previousControllerPos;
        _previousControllerPos = _currentControllerPos;
        
        _tiroirRotation = _tiroirRotationBase;
        
        float delta = _controllerDirection.z;
        transform.position = new Vector3(_poignéePosition.x, _poignéePosition.y, Mathf.Clamp(transform.position.z+delta, -1.17f, -0.607f));

    }
}
