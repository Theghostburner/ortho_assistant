using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class downloadFormForAnalysis : MonoBehaviour
{
  public void downloadFormRedirection()
  {
    Application.OpenURL("https://drive.google.com/drive/folders/1IYD1bszMPYJ2VneP1w_qSnn_ufGm_9V4?usp=sharing");

  }
  public void exitApp()
  {
    Application.Quit();
  }
}
