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
	public InputField ipF;
	public Text leaderboradText;

	void Start()
    {
		startButton = startButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();

		if (ipF != null) //If null it means that the current scene is the main menu
						 // So there isn't any leaderboard to load
		{
			//GetLeaderboard ();
		}
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
	public void GetLeaderboard()//make a query to the webapi and loads the json 
	{
		UnityWebRequest www = UnityWebRequest.Get ("localhost:8080/uploadScores"); 
		leaderboradText.text = ipF.text;

		if(www.isNetworkError) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
 
            //byte[] results = www.downloadHandler.data;
        }
	}

	public void UploadScore() //Uploads user's score and reload game
	{
		ipF=ipF.GetComponent<InputField>();


		WWWForm form = new WWWForm();
		form.AddField("username", ipF.text);
		form.AddField("userscore", ScoreClass.score);

		
		UnityWebRequest www = UnityWebRequest.Post ("http://unitygame.pythonanywhere.com/uploadScores",form);
		www.Send();
		Debug.Log("Enviou");
		//StartLevel();
	}

}
