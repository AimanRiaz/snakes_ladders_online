using UnityEngine;
using System.Collections;

public class RedPlayerScript : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "block") 
		{
			SnakeLadderScript.redPlayerAtBlock = col.gameObject.name;
			//Debug.Log ("Red Player At Pos: "+SnakeLadderScript.redPlayerAtBlock);
			if (col.gameObject.name == "100") {
				SoundManagerScript.winAudioSource.Play ();
				SnakeLadderScript.playersRank.Add ("Red");
			}
		}
	}

	void Start () 
	{
	
	}
}
