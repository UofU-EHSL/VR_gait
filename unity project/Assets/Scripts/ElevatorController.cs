using UnityEngine;

namespace VRGait.Elevator
{
	public class ElevatorController : MonoBehaviour
	{
		private Vector3 _destination;

		private Vector3 _cachedStartPosition;

		private float _moveSpeed;

		private bool _startMoving;

		private float _cachedHeight;

		private void Awake()
		{
			_startMoving = false;
			_cachedStartPosition = this.transform.position;
		}

		public void MoveUp(float height, float time)
		{
			if (_startMoving)
			{
				return;
			}
			if (time == 0.0f)
			{
				throw new System.Exception("The time cannot be zero");
			}
			_moveSpeed = height / time;
			_cachedHeight = height;
			_destination = _cachedStartPosition + height * Vector3.up;
			_startMoving = true;
		}

		public void MoveDown(float time)
		{
			if (_startMoving)
			{
				return;
			}
			if (time == 0.0f)
			{
				throw new System.Exception("The time cannot be zero");
			}
			_moveSpeed = _cachedHeight / time;
			_destination = _cachedStartPosition;
			_startMoving = true;
		}

		private void Update()
		{
			if (_startMoving)
			{
				if (this.transform.position != _destination)
				{
					this.transform.position = Vector3.MoveTowards(this.transform.position, _destination, Time.deltaTime * _moveSpeed);
				}
				else
				{
					_startMoving = false;
				}
			}

		}
	}
}

