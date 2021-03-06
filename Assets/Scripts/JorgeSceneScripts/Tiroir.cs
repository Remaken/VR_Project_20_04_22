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
        _poignéePosition = transform.position;
        _tiroirRotation = transform.rotation;
        
        /* _poignéePosition = this.gameObject.GetComponent<Tiroir>().transform.position;
        _tiroirRotation = this.gameObject.GetComponent<Tiroir>().transform.rotation;
        _tiroirRotationBase = new Quaternion(_tiroirRotation.x, _tiroirRotation.y, _tiroirRotation.z, _tiroirRotation.w);*/
    }
    protected override void ContinuousAction(Vector3 interactorPos)
    {
        base.ContinuousAction(interactorPos);
        if (_previousControllerPos.z == 0f)
        {
            _previousControllerPos.z = interactorPos.z;
        }

        float delta = Mathf.Clamp(interactorPos.z - _previousControllerPos.z, -0.01f, 0.01f);

        _previousControllerPos.z = interactorPos.z;
        transform.rotation = _tiroirRotation;
        transform.position = new Vector3(_poignéePosition.x, _poignéePosition.y, Mathf.Clamp(transform.position.z + delta, _poignéePosition.z - 0.57f, _poignéePosition.z));
        
        /*
        if (_previousControllerPos == null || _previousControllerPos == Vector3.zero)
        {
            _previousControllerPos = interactorPos;
        }
        _currentControllerPos = interactorPos;
        _controllerDirection = _currentControllerPos - _previousControllerPos;
        _previousControllerPos = _currentControllerPos;
        
        
        float delta = Mathf.Clamp(_controllerDirection.z,-0.01f,0.01f);
        transform.position = new Vector3(_poignéePosition.x, _poignéePosition.y, Mathf.Clamp(_poignéePosition.z+delta, _poignéePosition.z-0.57f, _poignéePosition.z));
        transform.rotation = _tiroirRotationBase;
        */

    }
}
