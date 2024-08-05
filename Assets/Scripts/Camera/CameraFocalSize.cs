using UnityEngine;

namespace TriPeakSolitaire
{
    public class CameraFocalSize : MonoBehaviour
    {
        private ScreenOrientation lastOrientation;
        private Camera mainCamera;
        void Start()
        {
            mainCamera = Camera.main;
            lastOrientation = Screen.orientation;
            OnOrientationChange(lastOrientation);
        }

        void Update()
        {
            if (Screen.orientation != lastOrientation)
            {
                OnOrientationChange(Screen.orientation);
                lastOrientation = Screen.orientation;
            }
        }

        private void OnOrientationChange(ScreenOrientation newOrientation)
        {
            switch (newOrientation)
            {
                case ScreenOrientation.Portrait:
                    HandlePortraitOrientation();
                    break;
                case ScreenOrientation.LandscapeLeft:
                case ScreenOrientation.LandscapeRight:
                    HandleLandscapeOrientation();
                    break;
                case ScreenOrientation.PortraitUpsideDown:
                    HandlePortraitUpsideDownOrientation();
                    break;
                default:
                    break;
            }
        }

        private void HandlePortraitOrientation()
        {
            mainCamera.orthographicSize = 1700;
        }

        private void HandleLandscapeOrientation()
        {
            mainCamera.orthographicSize = 700;
        }

        private void HandlePortraitUpsideDownOrientation()
        {
            mainCamera.orthographicSize = 1500;
        }
    }
}

