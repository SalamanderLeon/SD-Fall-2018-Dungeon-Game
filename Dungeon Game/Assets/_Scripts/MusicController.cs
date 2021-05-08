using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour {

	public AudioMixerSnapshot noMusic;
	public AudioMixerSnapshot outOfCombat;
	public AudioMixerSnapshot shopping;
	public AudioClip[] stings;
	public AudioSource stingSource;

	public float bpm = 128;

	private float m_TransitionIn;
	private float m_TransitionOut;
	private float m_QuarterNote;

	// Use this for initialization
	void Start () {
		m_QuarterNote = 60 / bpm;
		m_TransitionIn = m_QuarterNote;
		m_TransitionOut = m_QuarterNote * 2;
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.CompareTag("ShopZone"))
		{
			shopping.TransitionTo(m_TransitionIn);
			Debug.Log("shop");
		}
	}

	void OnTriggerExit(Collider other)
	{

		if (other.CompareTag("ShopZone"))
		{
			outOfCombat.TransitionTo(m_TransitionOut);
			Debug.Log("no shop");
		}
	}

	void PlaySting()
	{
		int randClip = Random.Range(0, stings.Length);
		stingSource.clip = stings[randClip];
		stingSource.Play();
	}

	// Update is called once per frame
	void Update () {
	}
}
