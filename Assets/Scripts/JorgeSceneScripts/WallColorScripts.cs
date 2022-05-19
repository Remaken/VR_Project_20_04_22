using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using UnityEngine.XR.Interaction.Toolkit;

public class WallColorScripts : BaseInteractable
{
   [SerializeField] private Button _nextColorButton;
   [SerializeField] private Button _previousColorButton;
   [SerializeField] private Button _baseColorButton;
   [SerializeField] private Material[] WallColors;
   private Material _baseWallMaterial;
   private Material _currentWallMaterial;
   private int _materialNumber;
   private Vector3 _baseTabletPosition;
   private Quaternion _baseTabletRotation;


   [SerializeField] private GameObject[] Walls;
   [SerializeField] private GameObject _colorDisplay;

   private void Start()
   {
      _baseTabletPosition = this.gameObject.transform.position;
      _baseTabletRotation = transform.rotation;
      _baseWallMaterial = WallColors[0];
   }

   public void NextColorClicked()
   {
      if (_materialNumber<=WallColors.Length-1)
      {
         _materialNumber++;
         
         if (_materialNumber==WallColors.Length)
         {
            _materialNumber = 0;
         }
      }
      ApplyMaterial();
   }

   public void PreviousColorClicked()
   {
      if (_materialNumber>=0)
      {
         _materialNumber--;
         if (_materialNumber == -1)
         {
            _materialNumber = WallColors.Length-1;
         }
      }
      ApplyMaterial();
   }

   public void ResetColorClicked()
   {
      _currentWallMaterial = _baseWallMaterial;
      ApplyMaterial();
   }
   private void ApplyMaterial()
   {
      _currentWallMaterial = WallColors[_materialNumber];
      _colorDisplay.GetComponent<MeshRenderer>().material = _currentWallMaterial;
      for (int i = 0; i < Walls.Length; i++)
      {
         Walls[i].GetComponent<MeshRenderer>().material = _currentWallMaterial;
      }
   }

   protected override void ExitSelect(SelectExitEventArgs arg0)
   {
      base.ExitSelect(arg0);
      StartCoroutine(TabletTpBasePosition());
   }

   IEnumerator TabletTpBasePosition()
   {
      yield return new WaitForSeconds(4f);
      this.gameObject.transform.position = _baseTabletPosition;
      this.gameObject.transform.rotation = _baseTabletRotation;
   }
}
