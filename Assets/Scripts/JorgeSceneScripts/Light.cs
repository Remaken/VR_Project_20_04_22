using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : BaseInteractable
{
   [SerializeField] private Light roomLight;
   [SerializeField] private Renderer roomLightBulb;


   protected override void InstantAction()
   {
      base.InstantAction();
      if (roomLight.enabled)
      {
         roomLight.enabled = false;
         roomLightBulb.material.DisableKeyword("_EMISSION");
      }
      else
      {
         enabled = true;
         roomLightBulb.material.EnableKeyword("_EMISSION");
      }
   }
}
