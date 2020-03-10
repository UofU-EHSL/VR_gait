using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VRGait.Research
{
	public class ResearchUIController : MonoBehaviour
	{
		public string subjectNum
		{
			get
			{
				string num = this.input_subjectNum.text;
                bool isNumeric = true;
				if (!isNumeric)
				{
					this.input_subjectNum.text = "";
					throw new System.Exception("The subject number input should be a number.");
				}
				else
				{
					return num;
				}
			}
		}

		public string trialNum
		{
			get
			{
			    return this.input_trailNum.text;
			}
		}

		public string trialType
		{
			get
			{
				return this.dropDown_type.text;
			}
		}

		public string elevation
		{
			get
			{
				return this.dropDown_elevation.text;
			}
		}

		public Text txt_exportPath;

		public InputField input_subjectNum;

		public InputField input_trailNum;

		public InputField dropDown_elevation;

		public InputField dropDown_type;

		public TextMeshProUGUI txt_inRecordingPrompt;

		public Text txt_recordingButton;

		private void Awake()
		{
		}

		private void Start()
		{
			this.txt_exportPath.text = "Export Path: " + Application.persistentDataPath + "/Exports/";
		}

		public void ResetUI()
		{
			//this.input_subjectNum.text = "";
			//this.input_trailNum.text = "";
		}

		public bool CheckInputValid()
		{
            //uint num;
            //bool isNumeric_subjectNum = uint.TryParse(this.input_subjectNum.text, out num);
            //bool isNumeric_trialNum = uint.TryParse(this.input_trailNum.text, out num);
            bool isNumeric_subjectNum = true;
            bool isNumeric_trialNum = true;
            return isNumeric_subjectNum && isNumeric_trialNum;
		}

		public void ToggleRecordingText()
		{
			this.txt_inRecordingPrompt.gameObject.SetActive(!this.txt_inRecordingPrompt.IsActive());
		}
	}
}
