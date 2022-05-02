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

    private void Awake()
    {
        _poignéePosition = this.gameObject.GetComponent<Tiroir>().transform.position;
        _tiroirRotation = this.gameObject.GetComponent<Tiroir>().transform.rotation;
        _tiroirRotationBase = new Quaternion(_tiroirRotation.x, _tiroirRotation.y, _tiroirRotation.z, _tiroirRotation.w);
    }
    protected override void ContinuousAction(Vector3 interactorPos)
    {
        base.ContinuousAction(interactorPos);
        _controllerDirection = _poignéePosition - interactorPos;
        _tiroirRotation = _tiroirRotationBase;
        _poignéePosition.z = interactorPos.z;

    }
}
