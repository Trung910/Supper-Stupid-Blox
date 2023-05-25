using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChucNang : MonoBehaviour
{
    public GameObject Panel;
    public GameObject HTPPanel;
    public GameObject VPanel;
    public GameObject Volume;
    public GameObject HowToPlay;


    public void Options() { Panel.SetActive(true); }
    public void Play() { SceneManager.LoadScene("Scene01"); }
    public void Exit() { Application.Quit(); }

    public void Close() { Panel.SetActive(false); }

    public void Volume1() { VPanel.SetActive(true); }
    public void volume2() { HowToPlay.SetActive(false);  }

    public void HowToPlay1() { HTPPanel.SetActive(true); }
    public void HowToPlay2() { Volume.SetActive(false); }

    public void OK() 
    { 
        HTPPanel.SetActive(false); 
        VPanel.SetActive(false);
        Volume.SetActive(true);
        HowToPlay.SetActive(true);
    
    }
}


