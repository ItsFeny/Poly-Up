using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public CharacterController characterController;
   
    private void OnTriggerStay(Collider other) 
   {
     if (other.gameObject.tag == "Ground")
     {
         characterController.canJump = true;
     }
   }
   private void OnTriggerExit(Collider other) 
   {
      if (other.gameObject.tag == "Ground")
     {
        characterController.canJump = false;
     }
      
   }
}
