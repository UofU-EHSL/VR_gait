using TMPro;
using UnityEngine;

namespace VRGait.Platforms
{
	public class PlatformSetupUIController : MonoBehaviour
	{
		public GameObject confirmContent;

		public TextMeshProUGUI text_cornerPrompt;

		public PlatformSetupController setupController;

		public GameObject setupContent;

		private void Awake()
		{
		}

		private void OnEnable()
		{
			this.setupController.onChangeCorner += this.HandleOnChangeCorner;
			this.setupController.onFinishPickingup += this.HandleOnFinishPickingup;
		}

		private void OnDisable()
		{
			this.setupController.onChangeCorner -= this.HandleOnChangeCorner;
			this.setupController.onFinishPickingup -= this.HandleOnFinishPickingup;
		}

		public void ResetUI()
		{
			this.confirmContent.SetActive(false);
			this.setupContent.SetActive(true);
		}

		private void HandleOnChangeCorner(string corner)
		{
			this.text_cornerPrompt.text = "Set up: Please set up the " + corner + " corner for the Plank";
		}

		private void HandleOnFinishPickingup()
		{
			this.setupContent.SetActive(false);
			this.confirmContent.SetActive(true);
		}

		public void HandleBtnEnsureClick()
		{
			// Hide the set up UI
			this.confirmContent.SetActive(false);
			this.setupContent.gameObject.SetActive(false);
			this.setupController.RemoveCornerPlaceholders();
		}

		public void HandleBtnResetClick()
		{
			this.ResetUI();
			this.setupController.ResetSetup();
		}
	}
}