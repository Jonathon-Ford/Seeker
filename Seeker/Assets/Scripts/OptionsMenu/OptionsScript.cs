using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsScript : MonoBehaviour
{
     public GUISkin guiSkin;
     public Texture2D background, LOGO;
     public bool DragWindow = false;
 
 
     private string clicked = "";
     private Rect WindowRect = new Rect((Screen.width / 2) - 250, Screen.height / 3, 500, 200);
     private float volume = 1.0f;
 
     private void Start()
     {

     }
 
     private void OnGUI()
     {
         if (background != null)
             GUI.DrawTexture(new Rect(0,0,Screen.width , Screen.height),background);
 
         GUI.skin = guiSkin;
         if (clicked == "") { 

             WindowRect = GUI.Window(1, WindowRect, menuFunc, "Options");
         }
         else if (clicked == "graphics")
         {
             GUILayout.BeginVertical();
             for (int x = 0; x < Screen.resolutions.Length;x++ )
             {
                 if (GUILayout.Button(Screen.resolutions[x].width + "X" + Screen.resolutions[x].height))
                 {
                     Screen.SetResolution(Screen.resolutions[x].width,Screen.resolutions[x].height,true);
                 }
             }
             GUILayout.EndVertical();
             GUILayout.BeginHorizontal();
             if (GUILayout.Button("Back"))
             {
                 clicked = "";
             }
             GUILayout.EndHorizontal();
         }
         else if (clicked == "audio")
        {
            WindowRect = GUI.Window(1, WindowRect, audioMenuFunc, "Audio");
        }
     }
 
     private void menuFunc(int id)
     {
         if (GUILayout.Button("Audio"))
         {
             clicked = "audio";
         }
         if (GUILayout.Button("Graphics"))
         {
             clicked = "graphics";
         }
         if (GUILayout.Button("Back to Main Menu"))
         {

         }
         if (DragWindow)
             GUI.DragWindow(new Rect(0, 0, Screen.width, Screen.height));
     }

    private void audioMenuFunc(int id)
    {
        GUILayout.Box("Volume");
         volume = GUILayout.HorizontalSlider(volume ,0.0f,1.0f);
         AudioListener.volume = volume;
         if (GUILayout.Button("Back"))
         {
             clicked = "";
         }
    }

    private void graphicsMenuFunc(int id)
    {

    }
 
}
