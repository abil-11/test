using UnityEngine;
using System.Collections;
using System.IO;

public class TakeScreenShot : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(CoroutineScreenshot());
        }
    }

    private IEnumerator CoroutineScreenshot()
    {
        yield return new WaitForEndOfFrame();

        // 1. Create the directory if it doesn't exist
        string folderPath = Application.dataPath + "/Screenshots";
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        int width = Screen.width;
        int height = Screen.height;
        Texture2D screenshotTexture = new Texture2D(width, height, TextureFormat.ARGB32, false);

        Rect rect = new Rect(0, 0, width, height);
        screenshotTexture.ReadPixels(rect, 0, 0);
        screenshotTexture.Apply();

        byte[] byteArray = screenshotTexture.EncodeToPNG();

        // 2. Find the next available file number
        int filenumber = 0;
        string filepath = folderPath + "/CameraScreenshot" + filenumber.ToString() + ".png";
        int length = 300;

        for (int i = 0; i < length; i++)
        {
            if (!File.Exists(filepath))
            {
                File.WriteAllBytes(filepath, byteArray);
                Debug.Log("Taking Screenshot: " + filepath);

                // 3. Clean up the texture memory
                Destroy(screenshotTexture);
                yield break;
            }
            filenumber++;
            filepath = folderPath + "/CameraScreenshot" + filenumber.ToString() + ".png";
        }

        // Clean up if the loop finishes without saving (e.g., reached 300 limit)
        Destroy(screenshotTexture);
    }
}