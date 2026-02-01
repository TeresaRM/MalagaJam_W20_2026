using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScreenshotGallery : MonoBehaviour
{
    public GameObject imagePrefab;

    void Start()
    {
        string path = Application.persistentDataPath;
        string[] files = Directory.GetFiles(path, "screenshot_*.png");

        foreach (string file in files)
        {
            Texture2D tex = new Texture2D(2, 2);
            byte[] data = File.ReadAllBytes(file);
            tex.LoadImage(data);

            Sprite sprite = Sprite.Create(
                tex,
                new Rect(0, 0, tex.width, tex.height),
                new Vector2(0.5f, 0.5f)
            );

            Image img = Instantiate(imagePrefab, transform).GetComponent<Image>();
            img.sprite = sprite;
            img.preserveAspect = true;
        }
    }
}