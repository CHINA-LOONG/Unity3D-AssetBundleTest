using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class TestAssetBundle : MonoBehaviour {


	public Image image;
	private Sprite sprite;
	private AssetBundle bundle;
	private AssetBundle bundle2;

	void OnGUI()
	{
		if (GUI.Button (new Rect (0, 0, Screen.width / 2, Screen.height / 8), "强制卸载")) {
			if (bundle!=null) {
				bundle.Unload(true);
				bundle=null;
			}
			if (bundle2!=null) {
				bundle2.Unload(true);
				bundle2=null;
			}
			Resources.UnloadUnusedAssets();
			System.GC.Collect();
		} else if (GUI.Button (new Rect (Screen.width / 2, 0, Screen.width / 2, Screen.height / 8), "非强制卸载")) {
			if (bundle!=null) {
				bundle.Unload(false);
				bundle=null;
			}
			if (bundle2!=null) {
				bundle2.Unload(false);
				bundle2=null;
			}
			System.GC.Collect();
		} else if (GUI.Button (new Rect (0, Screen.height / 8, Screen.width / 2, Screen.height / 8), "加载")) {
			bundle= LoadAssetBundle("sprite");
			bundle2=LoadAssetBundle("sprite2");
			sprite=bundle.LoadAsset<Sprite>("meinv");
		} else if (GUI.Button (new Rect (Screen.width / 2, Screen.height / 8, Screen.width / 2, Screen.height / 8), "清空")) {
			sprite=null;
			image.sprite=null;
			Resources.UnloadUnusedAssets();
			System.GC.Collect();
		} else if (GUI.Button (new Rect (0, Screen.height * 7 / 8, Screen.width / 2, Screen.height / 8), "赋值")) {

			image.sprite=sprite;
			
		} else if (GUI.Button (new Rect (Screen.width / 2, Screen.height * 7 / 8, Screen.width / 2, Screen.height / 8), "切换")) {
			
			sprite=bundle2.LoadAsset<Sprite>("meinv2");
			image.sprite=sprite;
		} else if (GUI.Button (new Rect (0, Screen.height * 6 / 8, Screen.width / 2, Screen.height / 8), "清除不用")) {
			
			Resources.UnloadUnusedAssets();
		}
	}


	AssetBundle LoadAssetBundle(string bundleName)
	{
		AssetBundle bundle;
		byte[] stream = File.ReadAllBytes (Path.Combine (Application.streamingAssetsPath, "bundle/ui/" + bundleName));
		bundle = AssetBundle.CreateFromMemoryImmediate (stream);
		return bundle;
	}

}
