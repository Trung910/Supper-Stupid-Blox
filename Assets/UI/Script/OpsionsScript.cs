using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpsionsScript : MonoBehaviour
{
    public GameObject HowToPlayPanel;
    public GameObject ImformationPanel;
    public GameObject Panel;
    public void Close()
    { Panel.SetActive(false); }
    public void HowToPlay() { HowToPlayPanel.SetActive(true); }
    public void Imformation() { ImformationPanel.SetActive(true); }
}
