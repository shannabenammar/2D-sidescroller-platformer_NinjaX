using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    public GameObject SettingsPanel;
   public GameObject HelpPanel;
   bool helpState = false;
   bool settingsState = false;

  
   public void CloseSettingsPanel(){
       if(this.settingsState == true){
            settingsState = !settingsState;
            SettingsPanel.SetActive(settingsState);
        }
   }
   public void CloseHelpPanel(){
       if(this.helpState == true){
            helpState = !helpState;
            HelpPanel.SetActive(helpState);
        }
   }

   public void OpenHelpPanel() {
       Debug.Log("Pabel OPen");

       if(this.helpState == false){
            helpState = !helpState;
            HelpPanel.SetActive(helpState);
       } 
   } 

   public void OpenSettingsPanel() {
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
