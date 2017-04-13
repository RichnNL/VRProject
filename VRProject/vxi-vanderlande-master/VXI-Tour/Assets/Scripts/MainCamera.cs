using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// This class handles function for the main camera like
/// - changing scenes
/// - fading in/out of scenes
/// </summary>
public class MainCamera : MonoBehaviour {
    private Texture2D texture;
    private Rect screenRectangle;
    private Color fadeColor;
    public float alpha = 1;
    public float alphaDirection = -1;

    // Use this for initialization
    void Start () {
        screenRectangle = new Rect(0, 0, Screen.width, Screen.height);
        texture = new Texture2D(1, 1);
        fadeColor = new Color(0, 0, 0, alpha);

        fadeIn();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if((alphaDirection < 0 && alpha > 0) ||
            (alphaDirection > 0 && alpha < 1))
        {
            alpha += alphaDirection;
            fadeColor.a = alpha;
        }
    }

    void OnGUI()
    {
        if(alpha > 0)
        {
            texture.SetPixel(0, 0, fadeColor);
            texture.Apply();
            GUI.DrawTexture(screenRectangle, texture);
        }
    }

    public void openScene(string scene)
    {
        fadeOut();
        StartCoroutine(loadScene(scene));
    }

    private IEnumerator loadScene(string scene)
    {
        yield return new WaitUntil(() => alpha >= 1);
        SceneManager.LoadScene(scene);
    }

    private void fadeIn()
    {
        alphaDirection = -0.01f;
    }

    private void fadeOut()
    {
        alphaDirection = 0.01f;
    }
}
