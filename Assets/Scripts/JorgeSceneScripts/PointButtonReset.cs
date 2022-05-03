using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointButtonReset : BaseInteractable
{
    public delegate void ScoreButtonPressed();

    public static event ScoreButtonPressed ScoreReset;
    private Color _baseButtonColor;

    private void Awake()
    {
        _baseButtonColor = this.gameObject.GetComponent<MeshRenderer>().material.GetColor("_BaseColor");
    }

    protected override void InstantAction()
    { 
        base.InstantAction();
       ScoreReset?.Invoke();
    }

    protected override void OnHovering()
    {
        base.OnHovering(); 
        this.gameObject.GetComponent<MeshRenderer>().material.SetColor("_BaseColor",Color.black);
        this.gameObject.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }

    protected override void ExitedHovering()
    {
        base.ExitedHovering();
        this.gameObject.GetComponent<MeshRenderer>().material.SetColor("_BaseColor",_baseButtonColor);
        this.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
    }
}
