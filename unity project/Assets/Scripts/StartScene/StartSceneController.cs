using UnityEngine;

namespace VRGait.StartScene
{
	public class StartSceneController : MonoBehaviour
	{
		// Update is called once per frame
		void Update()
		{
			//if (Input.GetKeyDown(KeyCode.Alpha1))
			//{
			//	ExperimentalSceneBuilder.instance.curTrail = new TrailDescriptor(1, Platforms.Type.Walk, Platforms.Elevation.Low);
			//	ExperimentalSceneBuilder.instance.LoadScene(SceneType.Low);
			//}
			//if (Input.GetKeyDown(KeyCode.Alpha2))
			//{
			//	ExperimentalSceneBuilder.instance.curTrail = new TrailDescriptor(1, Platforms.Type.Walk, Platforms.Elevation.High);
			//	ExperimentalSceneBuilder.instance.LoadScene(SceneType.High);
			//}
			if (Input.GetKeyDown(KeyCode.Q))
			{
				Application.Quit();
			}
		}
	}
}
