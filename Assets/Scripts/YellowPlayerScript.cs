using UnityEngine;
using System.Collections;

public class YellowPlayerScript : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "block") 
		{
			SnakeLadderScript.yellowPlayerAtBlock = col.gameObject.name;
			//Debug.Log ("yellow Player At Block:" + SnakeLadderScript.yellowPlayerAtBlock);
			if (col.gameObject.name == "100") {
				SoundManagerScript.winAudioSource.Play ();
				SnakeLadderScript.playersRank.Add ("Yellow");
			}
		}
	}

	void Start () 
	{

	}
}
