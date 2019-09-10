using System.Collections;
using UnityEngine;
using Valve.VR;

namespace VRGait.FootTracker
{
	public class FootTrackerManager : MonoBehaviour
	{
		public FootTracker[] footTrackers = new FootTracker[2];

		public FootTrackersUIController uiController;

		private bool _displayTracker = false;

		private void Awake()
		{
			if (this.uiController == null)
			{
				throw new System.Exception("Please assign the ui controller for foot trackers");
			}
			_displayTracker = false;
		}
	}
}