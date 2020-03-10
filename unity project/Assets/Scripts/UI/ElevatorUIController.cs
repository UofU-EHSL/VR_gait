using UnityEngine;
using UnityEngine.UI;

namespace VRGait.Elevator
{
	public class ElevatorUIController : MonoBehaviour
	{
		public InputField input_elevatorHeight;

		public InputField input_elevatorTime;

		public Button btn_moveUp;

		public Button btn_moveDown;

		public ElevatorController elevatorController;

		private void OnEnable()
		{
			this.btn_moveUp.onClick.AddListener(this.HandlePressMovingUp);
			this.btn_moveDown.onClick.AddListener(this.HandlePressMovingDown);
		}

		private void OnDisable()
		{
			this.btn_moveDown.onClick.RemoveAllListeners();
			this.btn_moveUp.onClick.RemoveAllListeners();
		}

		private void HandlePressMovingUp()
		{
			float height;
			float time;
			bool isNumeric = float.TryParse(this.input_elevatorHeight.text, out height);
			if (!isNumeric)
			{
				Debug.LogError("Please input a valid elevator height");
				return;
			}
			isNumeric = float.TryParse(this.input_elevatorTime.text, out time);
			if (!isNumeric)
			{
				Debug.LogError("Please input a valid elevator time");
				return;
			}
			if (time == 0)
			{
				Debug.LogError("The elevator time cannot be zero");
				return;
			}

			this.elevatorController.MoveUp(height, time);
		}

		private void HandlePressMovingDown()
		{
			float time;
			bool isNumeric = float.TryParse(this.input_elevatorTime.text, out time);
			if (!isNumeric)
			{
				Debug.LogError("Please input a valid elevator time");
				return;
			}
			if (time == 0)
			{
				Debug.LogError("The elevator time cannot be zero");
				return;
			}
			this.elevatorController.MoveDown(time);
		}
	}
}
