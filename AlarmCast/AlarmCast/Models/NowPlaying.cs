//using System;
//using MonoTouch.AVFoundation;
//using MonoTouch.Foundation;
//using StreamingAudio;
//using System.Net;
//using System.IO;
//using MonoTouch.AudioToolbox;
//using System.Threading;
//using MonoTouch.MediaPlayer;

//namespace AlarmCast {
//	public static class NowPlaying {
//		public static Episode episode;
//		public static MPMoviePlayerController Player = null;

//		public static void StartPlayback (Episode newEpisode)
//		{
//			if (Player != null) {
//				Pause ();
//				Player.Dispose ();
//				Player = null;

//			}

//			episode = newEpisode;

//			Player = new MPMoviePlayerController ();
//			Player.ControlStyle = MPMovieControlStyle.None;
//			Player.SourceType = MPMovieSourceType.Streaming;
//			Player.ContentUrl = new NSUrl (episode.Url);
//			Player.PrepareToPlay ();
//			Player.View.Hidden = true;
//		}

//		public static void Play ()
//		{
//			if (Player != null) {
//				Player.Play ();
//			}
//		}

//		public static void Pause ()
//		{
//			if (Player != null) {
//				Player.Pause ();
//			}
//		}

//		public static void Rewind ()
//		{
//			Rewind (null, EventArgs.Empty);
//		}

//		public static void Rewind (object sender, EventArgs e)
//		{
//			if (Player != null) {
//				if (Player.CurrentPlaybackTime < 30)
//					Player.CurrentPlaybackTime = 0;
//				else
//					Player.CurrentPlaybackTime -= 30;
//			}
//		}

//		public static void FastForward ()
//		{
//			FastForward (null, EventArgs.Empty);
//		}

//		public static void FastForward (object sender, EventArgs e)
//		{
//			if (Player != null) {
//				if (Player.CurrentPlaybackTime > Player.Duration - 30)
//					Player.CurrentPlaybackTime = Player.Duration;
//				else
//					Player.CurrentPlaybackTime += 30;
//			}
//		}
//	}
//}

