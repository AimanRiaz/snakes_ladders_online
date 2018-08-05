using UnityEngine;
using System.Collections;

public class GreenPlayerScript : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "block") 
		{
			SnakeLadderScript.greenPlayerAtBlock = col.gameObject.name;
			//Debug.Log ("Green Player At Block:" + SnakeLadderScript.greenPlayerAtBlock);
			if (col.gameObject.name == "100") {
				SoundManagerScript.winAudioSource.Play ();
				SnakeLadderScript.playersRank.Add ("Green");
			}
		}
	}

	void Start () 
	{

	}
}
