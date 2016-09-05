using UnityEngine;
using System.Collections;

public class AnimateMonster : MonoBehaviour {
	private Animator _animator;
	private AudioSource _audioSource;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator> ();
		_audioSource = GetComponent<AudioSource> ();

//		StartCoroutine (DoAnimationTest ());
	}

	IEnumerator DoAnimationTest()
	{
		_animator.SetBool ("idle", false);
		_animator.SetFloat ("speed", 2.0f);

		yield return new WaitForSeconds (3.0f);

		_animator.SetFloat ("speed", 0.0f);

		yield return new WaitForSeconds (3.0f);

		_animator.SetBool ("idle", true);

	}

	// Update is called once per frame
	void Update () {
		
	}

	public void MonsterGrowl(AudioClip monsterGrowlClip)
	{
		Debug.Log ("Monster growling!");
		if (_audioSource.isPlaying == false)
		{
			_audioSource.PlayOneShot (monsterGrowlClip);
		}
	}
}
