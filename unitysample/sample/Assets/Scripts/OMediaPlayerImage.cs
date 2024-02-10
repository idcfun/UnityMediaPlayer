using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OMediaPlayerImage : MonoBehaviour {

    private RawImage image;
	// Use this for initialization
	void Start () {
        image = GetComponent<RawImage>();
	}
	
	// Update is called once per frame
	void Update () {
        image.texture = GetComponent<OMediaPlayer>().Texture;
	}
}
