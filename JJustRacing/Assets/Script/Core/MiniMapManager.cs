using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMapManager : BaseManager
{
    public Camera MiniMapCamera;
    public RawImage MiniMapDisplay;
	private void Start()
	{
		RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
		MiniMapCamera.targetTexture = renderTexture;
		MiniMapDisplay.texture = renderTexture;
	}
}
