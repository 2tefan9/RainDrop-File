using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Istruction : MonoBehaviour
{
    [SerializeField]
    private GameObject MainMenuPanel;
    public GameObject istruction;
 public void OnMainMenu()
    {
        istruction.SetActive(false);
        MainMenuPanel.SetActive(true);
    }
}
