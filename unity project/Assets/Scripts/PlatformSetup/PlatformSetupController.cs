using UnityEngine;
using System.Collections.Generic;
using Valve.VR;
using UnityEngine.SceneManagement;
using VRGait.Data;

namespace VRGait.Platforms
{
	public enum Corner
	{
		BottomLeft,
		BottomRight,
		TopRight,
		TopLeft,
		None
	}
	public delegate void OnChangeCorner(string coner);
	public delegate void OnFinishPickuping();

	public class PlatformSetupController : MonoBehaviour
	{
		public event OnChangeCorner onChangeCorner;

		public event OnFinishPickuping onFinishPickingup;

		public Transform leftController;

		public Transform rightController;

		public Transform elevator;

		public Vector3 bottomLeft { get; private set; }

		public Vector3 bottomRight { get; private set; }

		public Vector3 topLeft { get; private set; }

		public Vector3 topRight { get; private set; }

        private float width;
        private float height;
        public Vector3 TopMidPoints;
        public GameObject extraUI;
        public Corner corner { get; private set; }

		public Material platformMaterial;

		public GameObject cornerPlaceholder;

		public DataRecorder dataRecorder;

		private PlatformGenerator _platformGenerator;

		private bool _finishPickingUp = false;

		public List<GameObject> _corners = new List<GameObject>();

		private GameObject _cachedGo;

		private void Awake()
		{
			if (this.platformMaterial == null)
			{
				throw new System.Exception("Please assign the value to the platform's material field.");
			}
			if (this.cornerPlaceholder == null)
			{
				throw new System.Exception("Please assign the corner placeholder prefab field.");
			}
			if (this.dataRecorder == null)
			{
				throw new System.Exception("Please assign the data recorder for the platform generator");
			}
			_platformGenerator = new PlatformGenerator();
			_finishPickingUp = false;
			this.corner = Corner.BottomLeft;
		}

		private void Start()
		{
			if (this.onChangeCorner != null)
			{
				this.onChangeCorner(this.corner.ToString());
			}
		}

        public Vector3 LerpByDistance(Vector3 A, Vector3 B)
        {
            Vector3 P = new Vector3(A.x+(Vector3.Distance(A,B)/2),0,A.z);
            return P;
        }

        private void Update()
		{
			// Detect the controller's input
			// Press the trigger to pick up the corner.
			if (SteamVR_Input.GetStateDown("GrabPinch", SteamVR_Input_Sources.LeftHand))
			{
				this.PickupCorner(this.leftController.position);
			}
			if (SteamVR_Input.GetStateDown("GrabPinch", SteamVR_Input_Sources.RightHand))
			{
				this.PickupCorner(this.rightController.position);
			}

		}

		private void PickupCorner(Vector3 cornerPosition)
		{
			if (_finishPickingUp)
			{
				return;
			}
			switch (this.corner)
			{
				case Corner.BottomLeft:
					this.bottomLeft = cornerPosition;
					break;
				case Corner.BottomRight:
					this.bottomRight = cornerPosition;
					break;
				case Corner.TopRight:
					this.topRight = cornerPosition;
					break;
				case Corner.TopLeft:
					this.topLeft = cornerPosition;
					break;
				case Corner.None:
					throw new System.Exception("Something is wrong with the corner position.");
				default:
					break;
			}
			// While picking up for the last corner
			var placeHolder = Instantiate<GameObject>(this.cornerPlaceholder);
			placeHolder.transform.position = cornerPosition;
			_corners.Add(placeHolder);

			// While picking up the last corner
			if (this.corner == Corner.TopLeft)
			{
				_finishPickingUp = true;
				if (this.onFinishPickingup != null)
				{
					this.onFinishPickingup();
				}
				this.CreatePlatform();
			}
			else
			{
				this.corner = (Corner)((int)this.corner + 1);
				if (this.onChangeCorner != null)
				{
					this.onChangeCorner(this.corner.ToString());
				}
			}
		}

		public void ResetSetup()
		{
			this.RemoveCornerPlaceholders();
			_finishPickingUp = false;
			this.corner = Corner.BottomLeft;
			if (this.onChangeCorner != null)
			{
				this.onChangeCorner(this.corner.ToString());
			}
			Destroy(_cachedGo);
		}

		public void CreatePlatform()
		{
            TopMidPoints = LerpByDistance(topLeft, topRight);
            extraUI.transform.position = TopMidPoints;
            if (_platformGenerator != null)
			{
				_cachedGo = _platformGenerator.GeneratePlatform(this.bottomLeft, this.bottomRight, this.topRight, this.topLeft, this.platformMaterial, this.elevator);

				// Record the corner positions
				this.dataRecorder.cornerPositions[0] = bottomLeft;
				this.dataRecorder.cornerPositions[1] = bottomRight;
				this.dataRecorder.cornerPositions[2] = topRight;
				this.dataRecorder.cornerPositions[3] = topLeft;
			}

            width = Vector3.Distance(bottomLeft, bottomRight);
            height = Vector3.Distance(bottomLeft, topLeft);
            this.platformMaterial.mainTextureScale = new Vector2(width,height);
		}
        
		public void RemoveCornerPlaceholders()
		{
			for (int i = 0; i < _corners.Count; i++)
			{
				Destroy(_corners[i]);
			}
			_corners.Clear();
		}
	}
}