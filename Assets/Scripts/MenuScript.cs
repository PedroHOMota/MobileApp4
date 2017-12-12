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
			
			ipF=ipF.GetComponent<InputField>();
			StartCoroutine(GetLeaderboard ());
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

	IEnumerator GetLeaderboard()//make a query to the webapi and loads the json 
	{
		UnityWebRequest www = UnityWebRequest.Get("http://unitygame.pythonanywhere.com/GetScores");
		yield return www.Send();

		if(www.isNetworkError) {
            Debug.Log(www.error);
        }
        else 
		{
			
            // Show results as text
			string json = www.downloadHandler.text;
			Debug.Log (json);
			json ="{ \"infos\" : "+json+" }";
			Debug.Log (json);
			UserInfoCollection lInfo = JsonUtility.FromJson<UserInfoCollection>(json);
			Debug.Log (lInfo.infos [0].username);
			for (int i = 0; i < lInfo.infos.Length; i++) 
			{
				Debug.Log (lInfo.infos [i].username + "\t" + lInfo.infos [i].score);
				leaderboradText.text +=lInfo.infos[i].username +"\t"+lInfo.infos[i].score+"\n";
			}
            //byte[] results = www.downloadHandler.data;
			//Debug.Log (results [0]);
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
		StartLevel();
	}

}
