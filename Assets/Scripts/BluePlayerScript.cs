using UnityEngine;
using System.Collections;

public class BluePlayerScript : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "block") 
		{
			SnakeLadderScript.bluePlayerAtBlock = col.gameObject.name;
			//Debug.Log ("blue Player At Block:" + SnakeLadderScript.bluePlayerAtBlock);
			if (col.gameObject.name == "100") {
				SoundManagerScript.winAudioSource.Play ();
				SnakeLadderScript.playersRank.Add ("Blue");
			}
		}
	}

	void Start () 
	{

	}
}
