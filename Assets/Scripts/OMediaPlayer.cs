using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OMediaPlayer : MonoBehaviour {

    private AndroidJavaObject vedioPlayer;
    private Texture2D texture;
    private int width, height;
    private int textureHandle;

    public Texture2D Texture
    {
        get
        {
            return texture;
        }
    }

    // Use this for initialization
    void Start()
    {
        AndroidJavaObject o = new AndroidJavaObject("com.idnc.omediaplayer4unity.OMediaPlayerCore");
        vedioPlayer = o.Call<AndroidJavaObject>("CreatePlayer");
        Open("http://img.ksbbs.com/asset/Mon_1703/05cacb4e02f9d9e.mp4");
    }

    void Open(string url)
    {
        vedioPlayer.Call("Open", url);
    }

    // Update is called once per fram
    void Update()
    {

        if (vedioPlayer != null)
        {
            textureHandle = vedioPlayer.Call<int>("Render");
            if (texture == null && textureHandle != 0)
            {
                texture = Texture2D.CreateExternalTexture(vedioPlayer.Call<int>("Width"), vedioPlayer.Call<int>("Height"), TextureFormat.RGBA32, false, false, new System.IntPtr(textureHandle));
                texture.wrapMode = TextureWrapMode.Clamp;
                texture.filterMode = FilterMode.Bilinear;
            }
        }

        GL.InvalidateState();
    }

    private void LateUpdate()
    {
    }
}
