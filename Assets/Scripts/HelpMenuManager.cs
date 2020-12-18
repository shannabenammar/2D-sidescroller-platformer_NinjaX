using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenuManager : MonoBehaviour
{
   public GameObject HelpPanel;
   private bool helpState = false;

    // void Update() {

    //     if(Input.GetKeyDown(KeyCode.Escape)){ 
    //         if(helpState) 
    //             ClosePanel();
    //             else 
    //                 OpenPanel();
    //     }
    // }

   public void ClosePanel(){
       if(this.helpState == true){
            helpState = !helpState;
            HelpPanel.SetActive(helpState);
        }
   }

   public void OpenPanel() {
       if(this.helpState == false){
            helpState = !helpState;
            HelpPanel.SetActive(helpState);
       } 
   }
}
