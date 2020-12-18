using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuManager : MonoBehaviour
{
   public GameObject SettingsPanel;
   private bool settingsState = false;

    // void Update() {

    //     if(Input.GetKeyDown(KeyCode.Escape)){ 
    //         if(settingsState) 
    //             ClosePanel();
    //             else 
    //                 OpenPanel();
    //     }
    // }

   public void ClosePanel(){
       if(this.settingsState == true){
            settingsState = !settingsState;
            SettingsPanel.SetActive(settingsState);
        }
   }

   public void OpenPanel() {
       if(this.settingsState == false){
            settingsState = !settingsState;
            SettingsPanel.SetActive(settingsState);
       } 
   }

   public void QuitGame(){
       Debug.Log("Closing game...");
       Application.Quit();
   }
}
