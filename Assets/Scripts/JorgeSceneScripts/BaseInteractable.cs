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
    [SerializeField] private Vector3 _interactorPosition;
    
    

    protected void OnEnable()
    { 
        objetInteratable.selectEntered.AddListener(StartSelect);
        objetInteratable.selectExited.AddListener(ExitSelect);
    }
   
    protected void OnDisable()
    {
        objetInteratable.selectEntered.RemoveListener(StartSelect);
        objetInteratable.selectExited.RemoveListener(ExitSelect);
    }
    
    
    protected void StartSelect(SelectEnterEventArgs arg0)
    {
        if (!_instantInteraction)
        {
            _objectSelected = true;
            _interactorPosition = arg0.interactorObject.transform.position;
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
            _interactorPosition = Vector3.zero;
        }
        else
        {
            
        }
    }
   

    protected virtual void InstantAction()
    {
        
    }

    protected virtual void ContinuousAction(Vector3 interactorPos)
    {
        
    }

    private void Update()
    {
        if (_objectSelected)
        {
            ContinuousAction(_interactorPosition);
        }
    }

}
