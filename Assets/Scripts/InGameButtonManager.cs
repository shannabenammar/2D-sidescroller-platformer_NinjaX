using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameButtonManager : MonoBehaviour{
    public GameObject SettingsPanel;
   public GameObject HelpPanel;
   bool helpState = false;
   bool settingsState = false;

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

   public void CloseSettingsPanel(){
       // Game is unpaused;
        Time.timeScale = 1;
        
        if(this.settingsState == true){
            settingsState = !settingsState;
            SettingsPanel.SetActive(settingsState);
        }
   }
    public void OpenSettingsPanel() {
        // Game is paused
        Time.timeScale = 0;
       
        if(this.settingsState == false){
            settingsState = !settingsState;
            SettingsPanel.SetActive(settingsState);
       } 
   }

   public void GoToMainMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
