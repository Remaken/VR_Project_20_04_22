using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BaseInteractable : MonoBehaviour
{

    public XRSimpleInteractable objetInteratable;
    [SerializeField] private bool _instantInteraction=true;
    [SerializeField] private bool _objectSelected = false;
    [SerializeField] protected Transform _interactorPosition;
    [SerializeField] protected bool _objectHovered = false;
    [SerializeField] protected GameObject _hoveringPrefab;
    private GameObject _hoveringText;
    private bool _textWasShown=false;
    private Transform _hoveringObjectTransform;


    private void Awake()
    {
    }

    protected void OnEnable()
    { 
        objetInteratable.selectEntered.AddListener(StartSelect);
        objetInteratable.selectExited.AddListener(ExitSelect);
        objetInteratable.hoverEntered.AddListener(ObjectHovered);
        objetInteratable.hoverExited.AddListener(ExitHovered);
    }

   

    protected  void OnDisable()
    {
        objetInteratable.selectEntered.RemoveListener(StartSelect);
        objetInteratable.selectExited.RemoveListener(ExitSelect);
        objetInteratable.hoverEntered.RemoveListener(ObjectHovered);
        objetInteratable.hoverExited.RemoveListener(ExitHovered);
    }
    
    
    protected void StartSelect(SelectEnterEventArgs arg0)
    {
        TextDestroyer();
        if (!_instantInteraction)
        {
            _objectSelected = true;
            _interactorPosition = arg0.interactorObject.transform;
        }
        else
        {
            InstantAction();
        }
    }


    protected void ExitSelect(SelectExitEventArgs arg0)
    {
        if (!_instantInteraction)
        {
            _objectSelected = false;
            _interactorPosition.position = Vector3.zero;
        }
        else
        {
            
        }
    }
    private void ObjectHovered(HoverEnterEventArgs arg0)
    {
        if (!_instantInteraction)
        {
            
        }
        else
        {
                _objectHovered = true;
                _hoveringObjectTransform = arg0.interactableObject.transform;
                
        }

    }
    private void ExitHovered(HoverExitEventArgs arg0)
    {
        if (!_instantInteraction)
        {
        }
        else
        {
            _objectHovered = false;
            _hoveringObjectTransform = null;
        }
    }

  

    protected virtual void InstantAction()
    {
        
    }

    protected virtual void ContinuousAction(Vector3 interactorPos)
    {
        
    }

    protected void Update()
    {
        if (_objectSelected)
        {
            ContinuousAction(_interactorPosition.position);
        }

        if (_objectHovered)
        {
            OnHovering();
        }
        else
        {
            ExitedHovering();
        }
    }
    
    protected virtual void OnHovering()
    {
        if (!_textWasShown)
        {
            _hoveringText = Instantiate(_hoveringPrefab, _hoveringObjectTransform.position,_hoveringObjectTransform.rotation);
            _textWasShown = true;
        }
    }
    protected virtual void ExitedHovering()
    {
      TextDestroyer();
      _textWasShown = false;
    }
    private void TextDestroyer()
    {
        if (_hoveringText!=null)
        {
            Destroy(_hoveringText);
        }
    }
}
