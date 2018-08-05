using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SnakeLadderScript : MonoBehaviour {

	public Image RollDice; // Dice Color
	public GameObject rollDiceOuterFrame; // Dice outer frame
	public GameObject[] snakePath_68,snakePath_52,snakePath_98,snakePath_46,snakePath_59,snakePath_83,snakePath_64,snakePath_93,snakePath_89;

	private Vector3[] snake_68,snake_52 ,snake_98,snake_46,snake_59,snake_83,snake_64,snake_93,snake_89;

	public static string redPlayerAtBlock,greenPlayerAtBlock,bluePlayerAtBlock, yellowPlayerAtBlock,generalPlayerAtBlock;
	public static bool redGotLadder, greenGotLadder, blueGotLadder, yellowGotLadder;

	public GameObject ladderTop_8,ladderTop_19,ladderTop_21,ladderTop_28,ladderTop_36,ladderTop_43,
					  ladderTop_50,ladderTop_54,ladderTop_61,ladderTop_62,ladderTop_66;

	public GameObject redPlayer, greenPlayer, bluePlayer, yellowPlayer;
	public GameObject redPlayerFrameUI, greenPlayerFrameUI, bluePlayerFrameUI, yellowPlayerFrameUI;

	public List<GameObject> blockNumber = new List<GameObject> ();

	// Animated Dice Gameobjects....
	public GameObject dice1Animation, dice2Animation, dice3Animation, dice4Animation, dice5Animation, dice6Animation;

	// Steps covered by Each players....
	private int redPlayerSteps, greenPlayerSteps, bluePlayerSteps, yellowPlayerSteps; 

	private int selectDiceNumber;
	private string currenPlayerTurn;
	GameObject currentPlayerGameObject;

	public GameObject confirmScreen; //  Are you Sure? Yes No
	public static List<string> playersRank = new List<string>();

	public GameObject TwoPlayersWinScreen,ThreePlayersWinScreen,FourPlayersWinScreen;
	public Text TwoPlayer_WinningPlayerText; // Winner of 2 player game
	public Text ThreePlayer_RankOneText,ThreePlayer_RankTwoText,ThreePlayer_RankThreeText;
	public Text FourPlayer_RankOneText, FourPlayer_RankTwoText, FourPlayer_RankThreeText, FourPlayer_RankFourText;

	//================== UI BUTTONS ==========================//*******************************************************************************************************************************************
	public void ExitMethod()
	{
		SoundManagerScript.buttonAudioSource.Play ();
		confirmScreen.SetActive (true);
	}

	public void YesMethod()
	{
		SoundManagerScript.buttonAudioSource.Play ();
		SceneManager.LoadScene ("Main Menu");
	}

	public void NoMethod()
	{
		SoundManagerScript.buttonAudioSource.Play ();
		confirmScreen.SetActive (false);
	}

	public void YesMethod_WinScreen()
	{
		SceneManager.LoadScene ("Snake Ladder");
	}

	public void NoMethod_WinScreen()
	{
		SceneManager.LoadScene ("Main Menu");
	}
	//=======================================================

	IEnumerator DiceShiftRoutine()
	{
		yield return new WaitForSeconds (1.0f);

		switch (MainMenuScript.howManyPlayers) 
		{	
			case 2:
				switch(currenPlayerTurn)
				{
					case "Red":
						if (redPlayerSteps == 0) 
						{
							if (selectDiceNumber != 6) 
							{
								currenPlayerTurn = "Green";
								RollDice.color = Color.green;
								dice1Animation.SetActive (false);
								dice2Animation.SetActive (false);
								dice3Animation.SetActive (false);
								dice4Animation.SetActive (false);
								dice5Animation.SetActive (false);
								dice6Animation.SetActive (false);
								rollDiceOuterFrame.SetActive (true);
							}
							if (selectDiceNumber == 6) 
							{
								currenPlayerTurn = "Red";
								RollDice.color = Color.red;
								redPlayerFrameUI.SetActive (true);
								greenPlayerFrameUI.SetActive (false);															
							}
						} 
						else 
						{
							if (blockNumber.Count - redPlayerSteps >= selectDiceNumber) 
							{
								redPlayerFrameUI.SetActive (true);
								greenPlayerFrameUI.SetActive (false);	
							}
							else
							{
								InitializeDice ();
							}
						}
						break;

					case "Green":
						if (greenPlayerSteps == 0) 
						{
							if(selectDiceNumber != 6)
							{
								currenPlayerTurn = "Red";
								RollDice.color = Color.red;
								dice1Animation.SetActive (false);
								dice2Animation.SetActive (false);
								dice3Animation.SetActive (false);
								dice4Animation.SetActive (false);
								dice5Animation.SetActive (false);
								dice6Animation.SetActive (false);
								rollDiceOuterFrame.SetActive (true);
							}
							if (selectDiceNumber == 6) 
							{
								currenPlayerTurn = "Green";
								RollDice.color = Color.green;
								redPlayerFrameUI.SetActive (false);
								greenPlayerFrameUI.SetActive (true);															
							}
						}
						else
						{
							if (blockNumber.Count - greenPlayerSteps >= selectDiceNumber) 
							{
								redPlayerFrameUI.SetActive (false);
								greenPlayerFrameUI.SetActive (true);
							}
							else
							{
								InitializeDice ();	
							}
						}
						break;
				}	
				break;

			case 3:
				switch(currenPlayerTurn)
				{
					case "Red":
						if (redPlayerSteps == 0) 
						{
							if (selectDiceNumber != 6) 
							{								
								currenPlayerTurn = "Green";
								RollDice.color = Color.green;
								
								dice1Animation.SetActive (false);
								dice2Animation.SetActive (false);
								dice3Animation.SetActive (false);
								dice4Animation.SetActive (false);
								dice5Animation.SetActive (false);
								dice6Animation.SetActive (false);
								rollDiceOuterFrame.SetActive (true);
							}
							if (selectDiceNumber == 6) 
							{
								currenPlayerTurn = "Red";
								RollDice.color = Color.red;
								redPlayerFrameUI.SetActive (true);
								greenPlayerFrameUI.SetActive (false);
								bluePlayerFrameUI.SetActive (false);								
							}
						} 
						else 
						{
							if (blockNumber.Count - redPlayerSteps >= selectDiceNumber) 
							{
								redPlayerFrameUI.SetActive (true);
								greenPlayerFrameUI.SetActive (false);
								bluePlayerFrameUI.SetActive (false);
							}
							else
							{
								InitializeDice ();
							}
						}
						break;

					case "Green":
						if (greenPlayerSteps == 0) 
						{
							if(selectDiceNumber != 6)
							{								
								currenPlayerTurn = "Blue";
								RollDice.color = new Color(85f/255f,77f/255f,189f/255f);
								
								dice1Animation.SetActive (false);
								dice2Animation.SetActive (false);
								dice3Animation.SetActive (false);
								dice4Animation.SetActive (false);
								dice5Animation.SetActive (false);
								dice6Animation.SetActive (false);
								rollDiceOuterFrame.SetActive (true);
							}
							if (selectDiceNumber == 6) 
							{
								currenPlayerTurn = "Green";
								RollDice.color = Color.green;
								redPlayerFrameUI.SetActive (false);
								greenPlayerFrameUI.SetActive (true);
								bluePlayerFrameUI.SetActive (false);								
							}
						}
						else
						{
							if (blockNumber.Count - greenPlayerSteps >= selectDiceNumber) 
							{
								redPlayerFrameUI.SetActive (false);
								greenPlayerFrameUI.SetActive (true);
								bluePlayerFrameUI.SetActive (false);	
							}
							else
							{
								InitializeDice ();
							}
						}
						break;

					case "Blue":
						if (bluePlayerSteps == 0) 
						{
							if(selectDiceNumber != 6)
							{								
								currenPlayerTurn = "Red";
								RollDice.color = Color.red;
								
								dice1Animation.SetActive (false);
								dice2Animation.SetActive (false);
								dice3Animation.SetActive (false);
								dice4Animation.SetActive (false);
								dice5Animation.SetActive (false);
								dice6Animation.SetActive (false);
								rollDiceOuterFrame.SetActive (true);
							}
							if (selectDiceNumber == 6) 
							{
								currenPlayerTurn = "Blue";
								RollDice.color = new Color(85f/255f,77f/255f,189f/255f);
								redPlayerFrameUI.SetActive (false);
								greenPlayerFrameUI.SetActive (false);
								bluePlayerFrameUI.SetActive (true);								
							}
						}
						else
						{
							if (blockNumber.Count - bluePlayerSteps >= selectDiceNumber) 
							{
								redPlayerFrameUI.SetActive (false);
								greenPlayerFrameUI.SetActive (false);
								bluePlayerFrameUI.SetActive (true);	
							}
							else
							{
								InitializeDice ();
							}
						}		
						break;
				}	
				break;

			case 4:
				switch(currenPlayerTurn)
				{
					case "Red":
						if (redPlayerSteps == 0) 
						{
							if (selectDiceNumber != 6) 
							{								
								currenPlayerTurn = "Green";
								RollDice.color = Color.green;
								
								dice1Animation.SetActive (false);
								dice2Animation.SetActive (false);
								dice3Animation.SetActive (false);
								dice4Animation.SetActive (false);
								dice5Animation.SetActive (false);
								dice6Animation.SetActive (false);
								rollDiceOuterFrame.SetActive (true);
							}
							if (selectDiceNumber == 6) 
							{
								currenPlayerTurn = "Red";
								RollDice.color = Color.red;
								redPlayerFrameUI.SetActive (true);
								greenPlayerFrameUI.SetActive (false);
								bluePlayerFrameUI.SetActive (false);
								yellowPlayerFrameUI.SetActive (false);
							}
						} 
						else 
						{
							if (blockNumber.Count - redPlayerSteps >= selectDiceNumber) 
							{
								redPlayerFrameUI.SetActive (true);
								greenPlayerFrameUI.SetActive (false);
								bluePlayerFrameUI.SetActive (false);
								yellowPlayerFrameUI.SetActive (false);
							}
							else
							{
								InitializeDice ();
							}
						}
						break;

					case "Green":
						if (greenPlayerSteps == 0) 
						{
							if(selectDiceNumber != 6)
							{								
								currenPlayerTurn = "Blue";
								RollDice.color = new Color(85f/255f,77f/255f,189f/255f);								

								dice1Animation.SetActive (false);
								dice2Animation.SetActive (false);
								dice3Animation.SetActive (false);
								dice4Animation.SetActive (false);
								dice5Animation.SetActive (false);
								dice6Animation.SetActive (false);
								rollDiceOuterFrame.SetActive (true);
							}
							if (selectDiceNumber == 6) 
							{
								currenPlayerTurn = "Green";
								RollDice.color = Color.green;
								redPlayerFrameUI.SetActive (false);
								greenPlayerFrameUI.SetActive (true);
								bluePlayerFrameUI.SetActive (false);
								yellowPlayerFrameUI.SetActive (false);
							}
						}
						else
						{
							if (blockNumber.Count - greenPlayerSteps >= selectDiceNumber) 
							{
								redPlayerFrameUI.SetActive (false);
								greenPlayerFrameUI.SetActive (true);
								bluePlayerFrameUI.SetActive (false);
								yellowPlayerFrameUI.SetActive (false);
							}
							else
							{
								InitializeDice ();
							}
						}									
						break;

					case "Blue":
						if (bluePlayerSteps == 0) 
						{
							if(selectDiceNumber != 6)
							{
								currenPlayerTurn = "Yellow";
								RollDice.color = Color.yellow;								

								dice1Animation.SetActive (false);
								dice2Animation.SetActive (false);
								dice3Animation.SetActive (false);
								dice4Animation.SetActive (false);
								dice5Animation.SetActive (false);
								dice6Animation.SetActive (false);
								rollDiceOuterFrame.SetActive (true);
							}
							if (selectDiceNumber == 6) 
							{
								currenPlayerTurn = "Blue";
								RollDice.color = new Color(85f/255f,77f/255f,189f/255f);
								redPlayerFrameUI.SetActive (false);
								greenPlayerFrameUI.SetActive (false);
								bluePlayerFrameUI.SetActive (true);
								yellowPlayerFrameUI.SetActive (false);
							}
						}
						else
						{
							if (blockNumber.Count - bluePlayerSteps >= selectDiceNumber) 
							{
								redPlayerFrameUI.SetActive (false);
								greenPlayerFrameUI.SetActive (false);
								bluePlayerFrameUI.SetActive (true);
								yellowPlayerFrameUI.SetActive (false);
							}
							else
							{
								InitializeDice ();
							}
						}						
						break;

					case "Yellow":
						if (yellowPlayerSteps == 0) 
						{
							if(selectDiceNumber != 6)
							{
								currenPlayerTurn = "Red";
								RollDice.color = Color.red;
								
								dice1Animation.SetActive (false);
								dice2Animation.SetActive (false);
								dice3Animation.SetActive (false);
								dice4Animation.SetActive (false);
								dice5Animation.SetActive (false);
								dice6Animation.SetActive (false);
								rollDiceOuterFrame.SetActive (true);
							}
							if (selectDiceNumber == 6) 
							{
								currenPlayerTurn = "Yellow";
								RollDice.color = Color.yellow;
								redPlayerFrameUI.SetActive (false);
								greenPlayerFrameUI.SetActive (false);
								bluePlayerFrameUI.SetActive (false);
								yellowPlayerFrameUI.SetActive (true);
							}
						}
						else
						{
							if (blockNumber.Count - yellowPlayerSteps >= selectDiceNumber) 
							{
								redPlayerFrameUI.SetActive (false);
								greenPlayerFrameUI.SetActive (false);
								bluePlayerFrameUI.SetActive (false);
								yellowPlayerFrameUI.SetActive (true);
							}
							else
							{
								InitializeDice ();
							}
						}						
						break;
				}	
				break;
		}
	}

	System.Random diceRandom;

	public void RollDiceMethod()
	{
		rollDiceOuterFrame.SetActive (false);
		SoundManagerScript.diceAudioSource.Play ();
		selectDiceNumber = diceRandom.Next (1,7);

		switch (selectDiceNumber) 
		{
			case 1:
				dice1Animation.SetActive (true);
				break;

			case 2:
				dice2Animation.SetActive (true);
				break;

			case 3:
				dice3Animation.SetActive (true);
				break;

			case 4:
				dice4Animation.SetActive (true);
				break;

			case 5:
				dice5Animation.SetActive (true);
				break;

			case 6:
				dice6Animation.SetActive (true);
				break;
		}

		StartCoroutine ("DiceShiftRoutine");
	}

	void Check_Snake_Ladder()
	{		
		switch (currenPlayerTurn) 
		{
			case "Red":
				generalPlayerAtBlock = redPlayerAtBlock;
				currentPlayerGameObject = redPlayer;
				break;

			case "Green":
				generalPlayerAtBlock = greenPlayerAtBlock;
				currentPlayerGameObject = greenPlayer;
				break;

			case "Blue":
				generalPlayerAtBlock = bluePlayerAtBlock;
				currentPlayerGameObject = bluePlayer;
				break;

			case "Yellow":
				generalPlayerAtBlock = yellowPlayerAtBlock;
				currentPlayerGameObject = yellowPlayer;
				break;
		}

		switch (generalPlayerAtBlock) {
		case "8":
			SoundManagerScript.ladderAudioSource.Play ();
			iTween.MoveTo (currentPlayerGameObject, iTween.Hash ("position", ladderTop_8.transform.position, "speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
			switch (currenPlayerTurn) {
				case "Red":
					redPlayerSteps = 26;
					break;
				case "Green":
					greenPlayerSteps = 26;
					break;
				case "Blue":
					bluePlayerSteps = 26;
					break;
				case "Yellow":
					yellowPlayerSteps = 26;
					break;
			}
			break;
		case "19":
			SoundManagerScript.ladderAudioSource.Play ();
			iTween.MoveTo (currentPlayerGameObject, iTween.Hash ("position", ladderTop_19.transform.position, "speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
			switch (currenPlayerTurn) {
				case "Red":
					redPlayerSteps = 38;
					break;
				case "Green":
					greenPlayerSteps = 38;
					break;
				case "Blue":
					bluePlayerSteps = 38;
					break;
				case "Yellow":
					yellowPlayerSteps = 38;
					break;
			}
			break;
		case "21":
			SoundManagerScript.ladderAudioSource.Play ();
			iTween.MoveTo (currentPlayerGameObject, iTween.Hash ("position", ladderTop_21.transform.position, "speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
			switch (currenPlayerTurn) {
				case "Red":
					redPlayerSteps = 82;
					break;
				case "Green":
					greenPlayerSteps = 82;
					break;
				case "Blue":
					bluePlayerSteps = 82;
					break;
				case "Yellow":
					yellowPlayerSteps = 82;
					break;
			}
			break;
		case "28":
			SoundManagerScript.ladderAudioSource.Play ();
			iTween.MoveTo (currentPlayerGameObject, iTween.Hash ("position", ladderTop_28.transform.position, "speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
			switch (currenPlayerTurn) {
				case "Red":
					redPlayerSteps = 53;
					break;
				case "Green":
					greenPlayerSteps = 53;
					break;
				case "Blue":
					bluePlayerSteps = 53;
					break;
				case "Yellow":
					yellowPlayerSteps = 53;
					break;
			}
			break;
		case "36":
			SoundManagerScript.ladderAudioSource.Play ();
			iTween.MoveTo (currentPlayerGameObject, iTween.Hash ("position", ladderTop_36.transform.position, "speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
			switch (currenPlayerTurn) {
				case "Red":
					redPlayerSteps = 57;
					break;
				case "Green":
					greenPlayerSteps = 57;
					break;
				case "Blue":
					bluePlayerSteps = 57;
					break;
				case "Yellow":
					yellowPlayerSteps = 57;
					break;
			}
			break;
		case "43":
			SoundManagerScript.ladderAudioSource.Play ();
			iTween.MoveTo (currentPlayerGameObject, iTween.Hash ("position", ladderTop_43.transform.position, "speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
			switch (currenPlayerTurn) {
				case "Red":
					redPlayerSteps = 77;
					break;
				case "Green":
					greenPlayerSteps = 77;
					break;
				case "Blue":
					bluePlayerSteps = 77;
					break;
				case "Yellow":
					yellowPlayerSteps = 77;
					break;
			}
			break;
		case "50":
			SoundManagerScript.ladderAudioSource.Play ();
			iTween.MoveTo (currentPlayerGameObject, iTween.Hash ("position", ladderTop_50.transform.position, "speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
			switch (currenPlayerTurn) {
				case "Red":
					redPlayerSteps = 91;
					break;
				case "Green":
					greenPlayerSteps = 91;
					break;
				case "Blue":
					bluePlayerSteps = 91;
					break;
				case "Yellow":
					yellowPlayerSteps = 91;
					break;
			}
			break;
		case "54":
			SoundManagerScript.ladderAudioSource.Play ();
			iTween.MoveTo (currentPlayerGameObject, iTween.Hash ("position", ladderTop_54.transform.position, "speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
			switch (currenPlayerTurn) {
				case "Red":
					redPlayerSteps = 88;
					break;
				case "Green":
					greenPlayerSteps = 88;
					break;
				case "Blue":
					bluePlayerSteps = 88;
					break;
				case "Yellow":
					yellowPlayerSteps = 88;
					break;
			}
			break;
		case "61":
			SoundManagerScript.ladderAudioSource.Play ();
			iTween.MoveTo (currentPlayerGameObject, iTween.Hash ("position", ladderTop_61.transform.position, "speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
			switch (currenPlayerTurn) {
				case "Red":
					redPlayerSteps = 99;
					break;
				case "Green":
					greenPlayerSteps = 99;
					break;
				case "Blue":
					bluePlayerSteps = 99;
					break;
				case "Yellow":
					yellowPlayerSteps = 99;
					break;
			}
			break;
		case "62":
			SoundManagerScript.ladderAudioSource.Play ();
			iTween.MoveTo (currentPlayerGameObject, iTween.Hash ("position", ladderTop_62.transform.position, "speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
			switch (currenPlayerTurn) {
				case "Red":
					redPlayerSteps = 96;
					break;
				case "Green":
					greenPlayerSteps = 96;
					break;
				case "Blue":
					bluePlayerSteps = 96;
					break;
				case "Yellow":
					yellowPlayerSteps = 96;
					break;
			}
			break;
		case "66":
			SoundManagerScript.ladderAudioSource.Play ();
			iTween.MoveTo (currentPlayerGameObject, iTween.Hash ("position", ladderTop_66.transform.position, "speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
			switch (currenPlayerTurn) {
				case "Red":
					redPlayerSteps = 87;
					break;
				case "Green":
					greenPlayerSteps = 87;
					break;
				case "Blue":
					bluePlayerSteps = 87;
					break;
				case "Yellow":
					yellowPlayerSteps = 87;
					break;
			}
			break;
			//==================================== SNAKES PATH ANIMATION====================================
		case "68":
			SoundManagerScript.snakeAudioSource.Play ();
			iTween.MoveTo (currentPlayerGameObject, iTween.Hash ("path", snake_68, "speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
			switch (currenPlayerTurn) {
				case "Red":
					redPlayerSteps = 2;
					break;
				case "Green":
					greenPlayerSteps = 2;
					break;
				case "Blue":
					bluePlayerSteps = 2;
					break;
				case "Yellow":
					yellowPlayerSteps = 2;
					break;
			}
			break;

		case "98":
			SoundManagerScript.snakeAudioSource.Play ();
			iTween.MoveTo (currentPlayerGameObject, iTween.Hash ("path", snake_98, "speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
			switch (currenPlayerTurn) {
				case "Red":
					redPlayerSteps = 13;
					break;
				case "Green":
					greenPlayerSteps = 13;
					break;
				case "Blue":
					bluePlayerSteps = 13;
					break;
				case "Yellow":
					yellowPlayerSteps = 13;
					break;
			}
			break;

		case "93":
			SoundManagerScript.snakeAudioSource.Play ();
			iTween.MoveTo (currentPlayerGameObject, iTween.Hash ("path", snake_93, "speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
			switch (currenPlayerTurn) {
				case "Red":
					redPlayerSteps = 37;
					break;
				case "Green":
					greenPlayerSteps = 37;
					break;
				case "Blue":
					bluePlayerSteps = 37;
					break;
				case "Yellow":
					yellowPlayerSteps = 37;
					break;
			}
			break;

		case "83":
			SoundManagerScript.snakeAudioSource.Play ();
			iTween.MoveTo (currentPlayerGameObject, iTween.Hash ("path", snake_83, "speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
			switch (currenPlayerTurn) {
				case "Red":
					redPlayerSteps = 22;
					break;
				case "Green":
					greenPlayerSteps = 22;
					break;
				case "Blue":
					bluePlayerSteps = 22;
					break;
				case "Yellow":
					yellowPlayerSteps = 22;
					break;
			}
			break;

		case "59":
			SoundManagerScript.snakeAudioSource.Play ();
			iTween.MoveTo (currentPlayerGameObject, iTween.Hash ("path", snake_59, "speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
			switch (currenPlayerTurn) {
				case "Red":
					redPlayerSteps = 18;
					break;
				case "Green":
					greenPlayerSteps = 18;
					break;
				case "Blue":
					bluePlayerSteps = 18;
					break;
				case "Yellow":
					yellowPlayerSteps = 18;
					break;
			}
			break;

		case "64":
			SoundManagerScript.snakeAudioSource.Play ();
			iTween.MoveTo (currentPlayerGameObject, iTween.Hash ("path", snake_64, "speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
			switch (currenPlayerTurn) {
				case "Red":
					redPlayerSteps = 24;
					break;
				case "Green":
					greenPlayerSteps = 24;
					break;
				case "Blue":
					bluePlayerSteps = 24;
					break;
				case "Yellow":
					yellowPlayerSteps = 24;
					break;
			}
			break;

		case "46":
			SoundManagerScript.snakeAudioSource.Play ();
			iTween.MoveTo (currentPlayerGameObject, iTween.Hash ("path", snake_46, "speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
			switch (currenPlayerTurn) {
				case "Red":
					redPlayerSteps = 17;
					break;
				case "Green":
					greenPlayerSteps = 17;
					break;
				case "Blue":
					bluePlayerSteps = 17;
					break;
				case "Yellow":
					yellowPlayerSteps = 17;
					break;
			}
			break;

		case "89":
			SoundManagerScript.snakeAudioSource.Play ();
			iTween.MoveTo (currentPlayerGameObject, iTween.Hash ("path", snake_89, "speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
			switch (currenPlayerTurn) {
				case "Red":
					redPlayerSteps = 51;
					break;
				case "Green":
					greenPlayerSteps = 51;
					break;
				case "Blue":
					bluePlayerSteps = 51;
					break;
				case "Yellow":
					yellowPlayerSteps = 51;
					break;
			}
			break;

		case "52":
			SoundManagerScript.snakeAudioSource.Play ();
			iTween.MoveTo (currentPlayerGameObject, iTween.Hash ("path", snake_52, "speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
			switch (currenPlayerTurn) {
				case "Red":
					redPlayerSteps = 11;
					break;
				case "Green":
					greenPlayerSteps = 11;
					break;
				case "Blue":
					bluePlayerSteps = 11;
					break;
				case "Yellow":
					yellowPlayerSteps = 11;
					break;
			}
			break;

		default:
			InitializeDice ();
			break;
		}
	}
	// Dice initialization after player finished his turn....
	void InitializeDice()
	{
		switch (MainMenuScript.howManyPlayers) 
		{	
		case 2://=============================
			switch(currenPlayerTurn)
			{
			case "Red":
				if (selectDiceNumber != 6) 
				{
					currenPlayerTurn = "Green";		
					RollDice.color = Color.green;
				} 
				else 
				{
					currenPlayerTurn = "Red";
					RollDice.color = Color.red;
				}					
				break;

			case "Green":
				if (selectDiceNumber != 6) 
				{
					currenPlayerTurn = "Red";
					RollDice.color = Color.red;
				}
				else
				{
					currenPlayerTurn = "Green";
					RollDice.color = Color.green;
				}					
				break;
			}
			dice1Animation.SetActive (false);
			dice2Animation.SetActive (false);
			dice3Animation.SetActive (false);
			dice4Animation.SetActive (false);
			dice5Animation.SetActive (false);
			dice6Animation.SetActive (false);				
			selectDiceNumber = 0;
			break;

		case 3://=============================
			switch(currenPlayerTurn)
			{
			case "Red":
				if (selectDiceNumber != 6) 
				{
					if (blockNumber.Count - greenPlayerSteps >= selectDiceNumber || (blockNumber.Count - greenPlayerSteps) > 0) {
						currenPlayerTurn = "Green";
						RollDice.color = Color.green;
					} else {	
						if (blockNumber.Count - bluePlayerSteps >= selectDiceNumber || (blockNumber.Count - bluePlayerSteps) > 0) {
							currenPlayerTurn = "Blue";
							RollDice.color = new Color (85f / 255f, 77f / 255f, 189f / 255f);
						} else {
							currenPlayerTurn = "Red";	
							RollDice.color = Color.red;
						}
					}
				}
				else
				{
					currenPlayerTurn = "Red";	
					RollDice.color = Color.red;
				}					
				break;

			case "Green":
				if (selectDiceNumber != 6) 
				{
					if (blockNumber.Count - bluePlayerSteps >= selectDiceNumber || (blockNumber.Count - bluePlayerSteps) > 0) {
						currenPlayerTurn = "Blue";
						RollDice.color = new Color(85f/255f,77f/255f,189f/255f);
					} else {
						if (blockNumber.Count - redPlayerSteps >= selectDiceNumber || (blockNumber.Count - redPlayerSteps) > 0) {
							currenPlayerTurn = "Red";
							RollDice.color = Color.red;
						} else {
							currenPlayerTurn = "Green";		
							RollDice.color = Color.green;
						}
					}
				}
				else
				{
					currenPlayerTurn = "Green";		
					RollDice.color = Color.green;
				}					
				break;

			case "Blue":
				if (selectDiceNumber != 6) 
				{
					if (blockNumber.Count - redPlayerSteps >= selectDiceNumber || (blockNumber.Count - redPlayerSteps) > 0) {
						currenPlayerTurn = "Red";
						RollDice.color = Color.red;
					} else {
						if (blockNumber.Count - greenPlayerSteps >= selectDiceNumber  || (blockNumber.Count - greenPlayerSteps) > 0) {
							currenPlayerTurn = "Green";
							RollDice.color = Color.green;
						} else {
							currenPlayerTurn = "Blue";	
							RollDice.color = new Color(85f/255f,77f/255f,189f/255f);
						}
					}
				}
				else
				{
					currenPlayerTurn = "Blue";	
					RollDice.color = new Color(85f/255f,77f/255f,189f/255f);
				}
				break;
			}
			dice1Animation.SetActive (false);
			dice2Animation.SetActive (false);
			dice3Animation.SetActive (false);
			dice4Animation.SetActive (false);
			dice5Animation.SetActive (false);
			dice6Animation.SetActive (false);				
			selectDiceNumber = 0;
			break;

		case 4://=============================
			switch(currenPlayerTurn)
			{
			case "Red":
				if (selectDiceNumber != 6) 
				{
					if (blockNumber.Count - greenPlayerSteps >= selectDiceNumber || (blockNumber.Count - greenPlayerSteps) > 0) {
						currenPlayerTurn = "Green";
						RollDice.color = Color.green;
					} else {
						if (blockNumber.Count - bluePlayerSteps >= selectDiceNumber || (blockNumber.Count - bluePlayerSteps) > 0) {
							currenPlayerTurn = "Blue";
							RollDice.color = new Color (85f / 255f, 77f / 255f, 189f / 255f);
						} else {
							if (blockNumber.Count - yellowPlayerSteps >= selectDiceNumber || (blockNumber.Count - yellowPlayerSteps) > 0) {
								currenPlayerTurn = "Yellow";
								RollDice.color = Color.yellow;
							} else {
								currenPlayerTurn = "Red";
								RollDice.color = Color.red;
							}
						}
					}
				}
				else
				{
					currenPlayerTurn = "Red";
					RollDice.color = Color.red;
				}					
				break;

			case "Green":
				if (selectDiceNumber != 6) 
				{
					if (blockNumber.Count - bluePlayerSteps >= selectDiceNumber || (blockNumber.Count - bluePlayerSteps) > 0) {
						currenPlayerTurn = "Blue";
						RollDice.color = new Color(85f/255f,77f/255f,189f/255f);
					} else {
						if (blockNumber.Count - yellowPlayerSteps >= selectDiceNumber || (blockNumber.Count - yellowPlayerSteps) > 0) {
							currenPlayerTurn = "Yellow";
							RollDice.color = Color.yellow;
						} else {
							if (blockNumber.Count - redPlayerSteps >= selectDiceNumber || (blockNumber.Count - redPlayerSteps) > 0) {
								currenPlayerTurn = "Red";
								RollDice.color = Color.red;
							} else {
								currenPlayerTurn = "Green";
								RollDice.color = Color.green;
							}
						}
					}
				}
				else
				{
					currenPlayerTurn = "Green";
					RollDice.color = Color.green;
				}					
				break;

			case "Blue":
				if (selectDiceNumber != 6) 
				{
					if (blockNumber.Count - yellowPlayerSteps >= selectDiceNumber || (blockNumber.Count - yellowPlayerSteps) > 0) {
						currenPlayerTurn = "Yellow";
						RollDice.color = Color.yellow;
					} else {
						if (blockNumber.Count - redPlayerSteps >= selectDiceNumber || (blockNumber.Count - redPlayerSteps) > 0) {
							currenPlayerTurn = "Red";
							RollDice.color = Color.red;
						} else {
							if (blockNumber.Count - greenPlayerSteps >= selectDiceNumber || (blockNumber.Count - greenPlayerSteps) > 0) {
								currenPlayerTurn = "Green";
								RollDice.color = Color.green;
							} else {
								currenPlayerTurn = "Blue";
								RollDice.color = new Color(85f/255f,77f/255f,189f/255f);
							}
						}
					}
				} 
				else 
				{
					currenPlayerTurn = "Blue";
					RollDice.color = new Color(85f/255f,77f/255f,189f/255f);
				}
				break;

			case "Yellow":
				if (selectDiceNumber != 6) 
				{
					if (blockNumber.Count - redPlayerSteps >= selectDiceNumber || (blockNumber.Count - redPlayerSteps) > 0) {
						currenPlayerTurn = "Red";
						RollDice.color = Color.red;
					} else {
						if (blockNumber.Count - greenPlayerSteps >= selectDiceNumber || (blockNumber.Count - greenPlayerSteps) > 0) {
							currenPlayerTurn = "Green";
							RollDice.color = Color.green;
						} else {
							if (blockNumber.Count - bluePlayerSteps >= selectDiceNumber || (blockNumber.Count - bluePlayerSteps) > 0) {
								currenPlayerTurn = "Blue";
								RollDice.color = new Color(85f/255f,77f/255f,189f/255f);
							} else {
								currenPlayerTurn = "Yellow";
								RollDice.color = Color.yellow;
							}
						}
					}
				} 
				else 
				{
					currenPlayerTurn = "Yellow";
					RollDice.color = Color.yellow;
				}
				break;
			}	
			dice1Animation.SetActive (false);
			dice2Animation.SetActive (false);
			dice3Animation.SetActive (false);
			dice4Animation.SetActive (false);
			dice5Animation.SetActive (false);
			dice6Animation.SetActive (false);

			selectDiceNumber = 0;				
			break;
		}

		//================= FINAL WIN SCREEN CONDITION HERE..==================
		switch (MainMenuScript.howManyPlayers) {
		case 2:
			if (playersRank.Count >= 1) {
				switch (playersRank [0]) {
				case "Red":
					ThreePlayer_RankOneText.color = Color.red;
					break;
				case "Green":
					ThreePlayer_RankOneText.color = Color.green;
					break;
				case "Blue":
					ThreePlayer_RankOneText.color = Color.blue;
					break;
				}
				TwoPlayer_WinningPlayerText.text = playersRank [0];
				TwoPlayersWinScreen.SetActive (true);
			} else {
				// 2 player match is not finished yet.
			}
			break;
		case 3:
			if (playersRank.Count >= 2) {
				switch (playersRank [0]) {
				case "Red":
					ThreePlayer_RankOneText.color = Color.red;
					break;
				case "Green":
					ThreePlayer_RankOneText.color = Color.green;
					break;
				case "Blue":
					ThreePlayer_RankOneText.color = Color.blue;
					break;
				}
				switch (playersRank [1]) {
				case "Red":
					ThreePlayer_RankTwoText.color = Color.red;
					break;
				case "Green":
					ThreePlayer_RankTwoText.color = Color.green;
					break;
				case "Blue":
					ThreePlayer_RankTwoText.color = Color.blue;
					break;
				}

				ThreePlayer_RankOneText.text = playersRank [0];
				ThreePlayer_RankTwoText.text = playersRank [1];
				ThreePlayersWinScreen.SetActive (true);			
			} else {
				// 3 player match is not finished yet.
			}
			break;
		case 4:			
			if (playersRank.Count >= 3) {
				switch (playersRank [0]) {
				case "Red":
					FourPlayer_RankOneText.color = Color.red;
					break;
				case "Green":
					FourPlayer_RankOneText.color = Color.green;
					break;
				case "Blue":
					FourPlayer_RankOneText.color = Color.blue;
					break;
				case "Yellow":
					FourPlayer_RankOneText.color = Color.yellow;
					break;
				}
				switch (playersRank [1]) {
				case "Red":
					FourPlayer_RankTwoText.color = Color.red;
					break;
				case "Green":
					FourPlayer_RankTwoText.color = Color.green;
					break;
				case "Blue":
					FourPlayer_RankTwoText.color = Color.blue;
					break;
				case "Yellow":
					FourPlayer_RankTwoText.color = Color.yellow;
					break;
				}
				switch (playersRank [2]) {
				case "Red":
					FourPlayer_RankThreeText.color = Color.red;
					break;
				case "Green":
					FourPlayer_RankThreeText.color = Color.green;
					break;
				case "Blue":
					FourPlayer_RankThreeText.color = Color.blue;
					break;
				case "Yellow":
					FourPlayer_RankThreeText.color = Color.yellow;
					break;
				}

				FourPlayer_RankOneText.text = playersRank [0];
				FourPlayer_RankTwoText.text = playersRank [1];
				FourPlayer_RankThreeText.text = playersRank [2];
				FourPlayersWinScreen.SetActive (true);
			} else {
				// 4 player match is not finished yet.
			}
			break;
		}
		rollDiceOuterFrame.SetActive (true);
	}

	//========================== PLAYER AS UI BUTTON ========================================================================
	public void RedPlayer_UI()
	{
		SoundManagerScript.playerAudioSource.Play ();
		redPlayerFrameUI.SetActive (false);

		if ((redPlayerSteps == 0 && selectDiceNumber == 6) || (redPlayerSteps > 0 && selectDiceNumber == 1)) {			

			iTween.MoveTo (redPlayer, iTween.Hash ("position", blockNumber [redPlayerSteps].transform.position, "speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "Check_Snake_Ladder", "oncompletetarget", this.gameObject));

			redPlayerSteps++;
		} 
		else 
		{
			Vector3[] redPlayer_Path = new Vector3[selectDiceNumber];

			for (int i = 0; i < selectDiceNumber; i++) {
				redPlayer_Path [i] = blockNumber [redPlayerSteps+i].transform.position;
			}

			iTween.MoveTo (redPlayer,iTween.Hash("path",redPlayer_Path,"speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "Check_Snake_Ladder", "oncompletetarget", this.gameObject));

			redPlayerSteps += selectDiceNumber;
		}			
	}
	//========================== GREEN PLAYER AS UI BUTTON ========================================================================
	public void GreenPlayer_UI()
	{
		SoundManagerScript.playerAudioSource.Play ();
		greenPlayerFrameUI.SetActive (false);
		if ((greenPlayerSteps == 0 && selectDiceNumber == 6) || (greenPlayerSteps > 0 && selectDiceNumber == 1)) {			

			iTween.MoveTo (greenPlayer, iTween.Hash ("position", blockNumber [greenPlayerSteps].transform.position, "speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "Check_Snake_Ladder", "oncompletetarget", this.gameObject));

			greenPlayerSteps++;
		} 
		else 
		{
			Vector3[] greenPlayer_Path = new Vector3[selectDiceNumber];

			for (int i = 0; i < selectDiceNumber; i++) {
				greenPlayer_Path [i] = blockNumber [greenPlayerSteps+i].transform.position;
			}

			iTween.MoveTo (greenPlayer,iTween.Hash("path",greenPlayer_Path,"speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "Check_Snake_Ladder", "oncompletetarget", this.gameObject));

			greenPlayerSteps += selectDiceNumber;
		}			
	}
	//========================== BLUE PLAYER AS UI BUTTON ========================================================================
	public void BluePlayer_UI()
	{
		SoundManagerScript.playerAudioSource.Play ();
		bluePlayerFrameUI.SetActive (false);
		if ((bluePlayerSteps == 0 && selectDiceNumber == 6) || (bluePlayerSteps > 0 && selectDiceNumber == 1)) {			

			iTween.MoveTo (bluePlayer, iTween.Hash ("position", blockNumber [bluePlayerSteps].transform.position, "speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "Check_Snake_Ladder", "oncompletetarget", this.gameObject));

			bluePlayerSteps++;
		} 
		else 
		{
			Vector3[] bluePlayer_Path = new Vector3[selectDiceNumber];

			for (int i = 0; i < selectDiceNumber; i++) {
				bluePlayer_Path [i] = blockNumber [bluePlayerSteps+i].transform.position;
			}

			iTween.MoveTo (bluePlayer,iTween.Hash("path",bluePlayer_Path,"speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "Check_Snake_Ladder", "oncompletetarget", this.gameObject));

			bluePlayerSteps += selectDiceNumber;
		}			
	}
	//========================== YELLOW PLAYER AS UI BUTTON ========================================================================
	public void YellowPlayer_UI()
	{
		SoundManagerScript.playerAudioSource.Play ();
		yellowPlayerFrameUI.SetActive (false);
		if ((yellowPlayerSteps == 0 && selectDiceNumber == 6) || (yellowPlayerSteps > 0 && selectDiceNumber == 1)) {			

			iTween.MoveTo (yellowPlayer, iTween.Hash ("position", blockNumber [yellowPlayerSteps].transform.position, "speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "Check_Snake_Ladder", "oncompletetarget", this.gameObject));

			yellowPlayerSteps++;
		} 
		else 
		{
			Vector3[] yellowPlayer_Path = new Vector3[selectDiceNumber];

			for (int i = 0; i < selectDiceNumber; i++) {
				yellowPlayer_Path [i] = blockNumber [yellowPlayerSteps+i].transform.position;
			}

			iTween.MoveTo (yellowPlayer,iTween.Hash("path",yellowPlayer_Path,"speed", 240, "easetype", "linear",
				"looptype", "none", "oncomplete", "Check_Snake_Ladder", "oncompletetarget", this.gameObject));

			yellowPlayerSteps += selectDiceNumber;
		}			
	}



	void Start () 
	{
		diceRandom = new System.Random ();
		redPlayerAtBlock = "0";
		greenPlayerAtBlock = "0";
		bluePlayerAtBlock = "0";
		yellowPlayerAtBlock = "0";
		generalPlayerAtBlock = "0";

		// If Players found ladder during gameplay...
		redGotLadder = false;
		greenGotLadder = false;
		blueGotLadder = false;
		yellowGotLadder = false;

		switch (MainMenuScript.howManyPlayers) 
		{
			case 2: // 2 player game					
				redPlayer.SetActive (true);
				greenPlayer.SetActive (true);
				bluePlayer.SetActive (false);
				yellowPlayer.SetActive (false);
				break;

			case 3: //  3 player game
				redPlayer.SetActive (true);
				greenPlayer.SetActive (true);
				bluePlayer.SetActive (true);
				yellowPlayer.SetActive (false);
				break;

			case 4: // 4 player game
				redPlayer.SetActive (true);
				greenPlayer.SetActive (true);
				bluePlayer.SetActive (true);
				yellowPlayer.SetActive (true);
				break;
		}

		// Dice Animations....
		dice1Animation.SetActive (false);
		dice2Animation.SetActive (false);
		dice3Animation.SetActive (false);
		dice4Animation.SetActive (false);
		dice5Animation.SetActive (false);
		dice6Animation.SetActive (false);

		snake_68 = new Vector3[snakePath_68.Length];
		snake_52 = new Vector3[snakePath_52.Length];
		snake_98 = new Vector3[snakePath_98.Length];
		snake_46 = new Vector3[snakePath_46.Length];
		snake_59 = new Vector3[snakePath_59.Length];
		snake_83 = new Vector3[snakePath_83.Length];
		snake_64 = new Vector3[snakePath_64.Length];
		snake_93 = new Vector3[snakePath_93.Length];
		snake_89 = new Vector3[snakePath_89.Length];

		for (int i = 0; i < snakePath_68.Length; i++) 
		{
			snake_68 [i] = snakePath_68 [i].transform.position;
		}

		for (int i = 0; i < snakePath_52.Length; i++) 
		{
			snake_52 [i] = snakePath_52 [i].transform.position;
		}

		for (int i = 0; i < snakePath_98.Length; i++) 
		{
			snake_98 [i] = snakePath_98 [i].transform.position;
		}

		for (int i = 0; i < snakePath_46.Length; i++) 
		{
			snake_46 [i] = snakePath_46 [i].transform.position;
		}

		for (int i = 0; i < snakePath_59.Length; i++) 
		{
			snake_59 [i] = snakePath_59 [i].transform.position;
		}

		for (int i = 0; i < snakePath_83.Length; i++) 
		{
			snake_83 [i] = snakePath_83 [i].transform.position;
		}

		for (int i = 0; i < snakePath_64.Length; i++) 
		{
			snake_64 [i] = snakePath_64 [i].transform.position;
		}

		for (int i = 0; i < snakePath_93.Length; i++) 
		{
			snake_93 [i] = snakePath_93 [i].transform.position;
		}

		for (int i = 0; i < snakePath_89.Length; i++) 
		{
			snake_89 [i] = snakePath_89 [i].transform.position;
		}

		currenPlayerTurn = "Red";
		RollDice.color = Color.red;
		redPlayerFrameUI.SetActive (false);
		greenPlayerFrameUI.SetActive (false);
		bluePlayerFrameUI.SetActive (false);
		yellowPlayerFrameUI.SetActive (false);

		TwoPlayersWinScreen.SetActive (false);
		ThreePlayersWinScreen.SetActive (false);
		FourPlayersWinScreen.SetActive (false);

		// Clear the players rank list.....
		if (playersRank.Count > 0) {
			playersRank.Clear ();
		}
	}	
}
