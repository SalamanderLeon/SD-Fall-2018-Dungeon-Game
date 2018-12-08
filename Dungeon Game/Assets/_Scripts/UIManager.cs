using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public Button StartButton;
    public Button ControlButton;
    public Button CreditButton;
    public Button ExitButton;
    public Button Exit;

    // Use this for initialization
    void Start () {
        StartButton.onClick.AddListener(MoveToStart);
        ControlButton.onClick.AddListener(MoveToControl);
        CreditButton.onClick.AddListener(MoveToCredit);
        ExitButton.onClick.AddListener(MoveToMainmenu);
        Exit.onClick.AddListener(ExitGame);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void MoveToStart()
    {
        SceneManager.LoadScene("Dugeon1");
        SceneManager.LoadScene("GameUI", LoadSceneMode.Additive);
        Debug.Log("clicked start");
    }
    void MoveToCredit()
    {
        SceneManager.LoadScene("Credit");
        Debug.Log("clicked credits");
    }
    void MoveToMainmenu()
    {
        SceneManager.LoadScene("Main");
        Debug.Log("clicked exit");
    }
    void MoveToControl()
    {
        SceneManager.LoadScene("Control");
        Debug.Log("clicked option");
    }
    void ExitGame()
    {
        Application.Quit();
        Debug.Log("clicked closeGame");
       
    }
}