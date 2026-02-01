using UnityEngine;

public class TakeScreenshot : MonoBehaviour
{
    public static void CaptureScreenshot()
    {
        string screenshotFilename = $"screenshot_{System.DateTime.Now:yyyyMMdd_HHmmss}.png";
        ScreenCapture.CaptureScreenshot(screenshotFilename);
        Debug.Log($"Screenshot saved to: {screenshotFilename}");
    }
}