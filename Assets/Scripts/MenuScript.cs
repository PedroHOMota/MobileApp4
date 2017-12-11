using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class MenuScript : MonoBehaviour 
{

    public Button startButton;
    public Button exitButton;

	void Start()
    {
		Debug.Log("Carregou");
        startButton = startButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();
	}
    public void StartLevel() 
    {
        SceneManager.LoadScene(1); //Load's game scene
    }
    public void ExitGame() 
    {
		Debug.Log("Chamou");
        Application.Quit(); //Exits the game
    }

	public void Test()
	{
		WWWForm form = new WWWForm();
		form.AddField("username", "Stan");
		form.AddField("userscore", "123456");

		
		UnityWebRequest www = UnityWebRequest.Post ("localhost:8080/uploadScores",form);
		www.Send();

		Debug.Log("Chamou");
	}

}
