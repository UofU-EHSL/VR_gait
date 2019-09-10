using UnityEngine;
using UnityEngine.UI;

namespace VRGait.FootTracker
{
	public class FootTrackersUIController : MonoBehaviour
	{
		public Button btn_reIdentify;

		public Button btn_hideOrDisplay;

		public Slider slider_leftFootHeight;

		public Slider slider_rightFootHeight;

		public float range_heightChanged = 0.2f;

		private void Awake()
		{
			if (this.btn_reIdentify == null)
			{
				throw new System.Exception("Please assign the btn_reIndentify field.");
			}
			if (this.btn_hideOrDisplay == null)
			{
				throw new System.Exception("Please assign the btn_hide or display field.");
			}
			if (this.slider_leftFootHeight == null)
			{
				throw new System.Exception("Please assign the left foot height slider field.");
			}
			if (this.slider_rightFootHeight == null)
			{
				throw new System.Exception("Please assign the right foot height slider field.");
			}
		}

		public void SetupSlider(float leftFootHeight, float rightFootHeight)
		{
			float val_1 = leftFootHeight + range_heightChanged;
			float val_2 = leftFootHeight - range_heightChanged;
			this.slider_leftFootHeight.maxValue = Mathf.Max(val_1, val_2);
			this.slider_leftFootHeight.minValue = Mathf.Min(val_1, val_2);
			this.slider_leftFootHeight.value = leftFootHeight;


			val_1 = rightFootHeight + range_heightChanged;
			val_2 = rightFootHeight - range_heightChanged;
			this.slider_rightFootHeight.maxValue = Mathf.Max(val_1, val_2);
			this.slider_rightFootHeight.minValue = Mathf.Min(val_1, val_2);
			this.slider_rightFootHeight.value = rightFootHeight;

			Debug.Log("Reset the foot height slider successfully");
		}

	}
}