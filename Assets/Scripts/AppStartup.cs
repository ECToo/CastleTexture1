using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(TwitterAPI))]
public class AppStartup : MonoBehaviour {
	public bool useTwitter = false;

	// Use this for initialization
	void Start () {
		var twitterAPIHandle = GetComponent<TwitterAPI> ();

		if (useTwitter == true)
		{
			twitterAPIHandle.SearchTwitter ("#GDC", SearchTweetsResultsCallBack);
		}
	}

	void SearchTweetsResultsCallBack(List<TweetSearchTwitterData> tweetList) {
		Debug.Log("====================================================");
		foreach(TweetSearchTwitterData twitterData in tweetList) {
			Debug.Log("Tweet: " + twitterData.ToString());
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
