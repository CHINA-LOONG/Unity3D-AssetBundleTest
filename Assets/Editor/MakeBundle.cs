using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.IO;

public class MakeBundle 
{

	[MenuItem("MyTools/Build AssetBundle")]
	static private void BuildAssetBundle()
	 {
		string abPath = Path.Combine (Application.streamingAssetsPath, "bundle");

		if (!Directory.Exists(abPath)) {
			Directory.CreateDirectory(abPath);
		}

		BuildPipeline.BuildAssetBundles (abPath, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);

		AssetDatabase.Refresh ();
	 }

}
