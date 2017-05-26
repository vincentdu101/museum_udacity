using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StreamVideo : MonoBehaviour {

	public RawImage image;
	public VideoClip videoToPlay;

	public VideoPlayer videoPlayer;
	public VideoSource videoSource;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		Application.runInBackground = true;
		StartCoroutine (playVideo ());
	}

	IEnumerator playVideo() {
		videoPlayer = gameObject.AddComponent<VideoPlayer> ();
		audioSource = gameObject.AddComponent<AudioSource> ();

		videoPlayer.playOnAwake = false;
		audioSource.playOnAwake = false;
		audioSource.Pause ();

		videoPlayer.source = VideoSource.Url;
		videoPlayer.url = "http://www.quirksmode.org/html5/videos/big_buck_bunny.mp4";

		videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

		videoPlayer.EnableAudioTrack (0, true);
		videoPlayer.SetTargetAudioSource (0, audioSource);

//		videoPlayer.clip = videoToPlay;
		videoPlayer.Prepare ();

		WaitForSeconds waitTime = new WaitForSeconds (1);
		while (!videoPlayer.isPrepared) {
			yield return waitTime;
			break;
		}

		image.texture = videoPlayer.texture;
		videoPlayer.Play ();
		audioSource.Play ();
		while (videoPlayer.isPlaying) {
			Debug.LogWarning("Video Time: " + Mathf.FloorToInt((float)videoPlayer.time));
			yield return null;
		}

	}
}
