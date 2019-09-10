using UnityEngine;
using UnityEngine.SceneManagement;

namespace VRGait.Headset
{
	public enum AlertType
	{
		Top,
		Left,
		Right,
		None
	};

	public class UIController : MonoBehaviour
	{
		private bool _bIsAlerting;

		private Animator _animator;

		private void Awake()
		{
			_animator = this.GetComponent<Animator>();
		}

		private void Start()
		{
			_bIsAlerting = false;
		}

		public void StartAlerting(AlertType type)
		{
			if (!_bIsAlerting)
			{
				_bIsAlerting = true;
				switch (type)
				{
					case AlertType.Left:
						_animator.SetTrigger("tLeftAlerting");
						break;
					case AlertType.Right:
						_animator.SetTrigger("tRightAlerting");
						break;
					case AlertType.Top:
						_animator.SetTrigger("tTopAlerting");
						break;
					default:
						throw new System.Exception("Please check the alert type");
				}
			}
		}

		public void StopAlerting()
		{
			if (_bIsAlerting)
			{
				_bIsAlerting = false;
				_animator.SetTrigger("tResetAlerting");
			}
		}

		private void Update()
		{
			//if (Input.GetKeyDown(KeyCode.Escape))
			//{
			//	SceneManager.LoadScene("DemoStartScene", LoadSceneMode.Single);
			//}
		}
	}

}