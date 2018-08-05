using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour 
{
	public static int howManyPlayers;

	public GameObject ExitMenu;                                                                   

	public void Exit(){                     
		ExitMenu.SetActive (true);
	}

	public void yes(){
		Application.Quit ();
	}

	public void no(){
		ExitMenu.SetActive (false);
	}

	//*****************************************//

	void Start () 
	{
		if (Application.platform == RuntimePlatform.Android) {
			QualitySettings.vSyncCount = 1;
			Application.targetFrameRate = 30;
		}
		if (Application.platform == RuntimePlatform.IPhonePlayer) {			
			Application.targetFrameRate = 60;
		}
	}

	public void TwoPlayerMethod()
	{
		SoundManagerScript.buttonAudioSource.Play ();
		howManyPlayers = 2;
		SceneManager.LoadScene ("Snake Ladder");
	}

	public void ThreePlayerMethod()
	{
		SoundManagerScript.buttonAudioSource.Play ();
		howManyPlayers = 3;
		SceneManager.LoadScene ("Snake Ladder");
	}

	public void FourPlayerMethod()
	{
		SoundManagerScript.buttonAudioSource.Play ();
		howManyPlayers = 4;
		SceneManager.LoadScene ("Snake Ladder");		
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}
}
