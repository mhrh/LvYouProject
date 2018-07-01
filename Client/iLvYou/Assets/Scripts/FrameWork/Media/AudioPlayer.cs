using UnityEngine;
using System.Collections;

namespace Game.Media
{
	/// <summary>
	/// Audio player.
	/// </summary>
	[RequireComponent(typeof(AudioSource))]
	public class AudioPlayer : MonoBehaviour
	{
		private float m_fVolume;	//the sound of volume.
		private float m_fPitch;	//the sound of pitch

		/// <summary>
		/// Init the specified clip and volume.
		/// </summary>
		/// <param name="clip">Clip.</param>
		/// <param name="volume">Volume.</param>
		public void Init( AudioClip clip , float volume = 1f , float pitch = 1f )
		{
			this.GetComponent<AudioSource>().clip = clip;
			this.m_fVolume = volume;
			this.m_fPitch = pitch;
		}

		/// <summary>
		/// Play the specified mute and volume.
		/// </summary>
		/// <param name="mute">If set to <c>true</c> mute.</param>
		/// <param name="volume">Volume.</param>
		public void Play( bool mute , float volume , float pitch , bool loop = false )
		{
			this.gameObject.SetActive(true);
			this.enabled = true;
			this.GetComponent<AudioSource>().enabled = true;
			this.GetComponent<AudioSource>().mute = mute;
			this.GetComponent<AudioSource>().loop = loop;
			this.GetComponent<AudioSource>().volume = volume * this.m_fVolume;
			this.GetComponent<AudioSource>().pitch = pitch * this.m_fPitch;
			this.GetComponent<AudioSource>().Play();
		}

		/// <summary>
		/// Changes the volume.
		/// </summary>
		/// <param name="mute">If set to <c>true</c> mute.</param>
		/// <param name="volume">Volume.</param>
		public void ChangeVolume( bool mute , float volume , float pitch )
		{
			this.GetComponent<AudioSource>().mute = mute;
			this.GetComponent<AudioSource>().volume = volume * this.m_fVolume;
			this.GetComponent<AudioSource>().pitch = pitch * this.m_fPitch;
		}

		/// <summary>
		/// Stop this audio.
		/// </summary>
		public void Stop()
		{
			this.enabled = false;
			this.GetComponent<AudioSource>().Stop();
			this.GetComponent<AudioSource>().enabled = false;
			this.gameObject.SetActive(false);
		}

		/// <summary>
		/// Stop the audio and notice.
		/// </summary>
		public void StopAndNotice()
		{
			Stop();
			MediaMgr.sInstance.RemoveAudioPlayer(this);
		}

		/// <summary>
		/// Update is called once per frame
		/// </summary>
		void Update ()
		{
			if(GetComponent<AudioSource>().isPlaying) return;
			StopAndNotice();
		}
	}


}