/**
 * Currently this whole thing is untestable as Unity does not play nice with what I'm trying to do
 * and I don't really feel like taming this beast so I'm going to leave this file as is and hope
 * Something will work out in the future.
 * 
 * Update: This script is now abandoned until further notice. Not worth the time to fix.
 **/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UnityEngine;
using Debug = UnityEngine.Debug; //To fix this: 'Debug' is an ambiguous reference between 'UnityEngine.Debug' and 'System.Diagnostics.Debug'

public class SettingsLoader : MonoBehaviour
{
    // Start is called before the first frame update
    // Check For config file, create one if not.
    void Start()
    {
        //Variables
        string CurrentDirectory = Directory.GetCurrentDirectory();
        string targetFile = "Settings.cfg";
        String path = CurrentDirectory + "\\" + targetFile;

        Debug.Log("Current Directory: "+path);
        Debug.Log("Attempting to look for "+path+"\\"+targetFile);
        //Not exists
        if (File.Exists(path) == false)
        {
            Debug.Log("Settings.cfg does not exist, attempting to create one.");
            try
            {
                //Unity doesn't seem to like doing this, unable to test for now.
                using (FileStream fs = File.Create(path))
                {
                    //Write to .cfg file line per line
                    string[] defaultSetting =
                     {
                        "Volume=100",
                        "SFX=100",
                        "Music=100"
                     };
                    System.IO.File.WriteAllLines(path, defaultSetting);
                }

            }
            catch (Exception ex)
            {
                Debug.Log(ex.ToString());
            }
        } else
        {
            //Purely for debugging sake
            Debug.Log("Settings.cfg found!");
        }
        // TODO: Now we need to load from .cfg file
        SettingObj Setting1 = new SettingObj(path);
    }
}

//A setting obj to hold and ref values from
public class SettingObj
{
    public double volumeVal;
    public double SFXVal;
    public double MusicVal;

    //Init
    public SettingObj(String path)
    {
        
        //We assume the file exists to begin with. This is checked by SettingsLoader
        //Attempting to read cfg file and dump each line into an array
        try {
            String[] arr = File.ReadAllLines(path);
            debugReading(arr);

            volumeVal = Convert.ToDouble(arr[0]);
            SFXVal = Convert.ToDouble(arr[1]);

        } catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }
    }

    //In case we need to check contents of what we read.
    private static void debugReading(String[] arr)
    {
        foreach (String s in arr){
            Debug.Log(s);
        }
    }
}
