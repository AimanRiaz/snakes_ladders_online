﻿using UnityEngine;
using System.Collections;

public class SoundManagerScript : MonoBehaviour 
{
	public AudioClip buttonAudioClip;
	public AudioClip diceAudioClip;
	public AudioClip snakeAudioClip;
	public AudioClip playerAudioClip;
	public AudioClip ladderAudioClip;
	public AudioClip winAudioClip;

	public static AudioSource buttonAudioSource;
	public static AudioSource diceAudioSource;
	public static AudioSource snakeAudioSource;
	public static AudioSource playerAudioSource;
	public static AudioSource ladderAudioSource;
	public static AudioSource winAudioSource;

	AudioSource AddAudio(AudioClip clip, bool playOnAwake, bool loop, float volume)
	{
		AudioSource audioSource = gameObject.AddComponent<AudioSource> ();
		audioSource.clip = clip;
		audioSource.playOnAwake = playOnAwake;
		audioSource.loop = loop;
		audioSource.volume = volume;
		return audioSource;
	}

	void Start () 
	{
		buttonAudioSource = AddAudio (buttonAudioClip,false,false,1.0f);
		diceAudioSource = AddAudio (diceAudioClip,false,false,1.0f);
		snakeAudioSource = AddAudio (snakeAudioClip,false,false,1.0f);
		playerAudioSource = AddAudio (playerAudioClip,false,false,1.0f);
	 	ladderAudioSource = AddAudio (ladderAudioClip,false,false,1.0f);
		winAudioSource = AddAudio (winAudioClip,false,false,1.0f);
	}
}
