/*******************************************************************************
 File Name: AssetBundle.cs
 Descript:
        AssetBundle Tools
 Version: 1.0
 Created Time: 2016/2/18 17:13:19
 Compiler: NETFrameworkv4.0.30319
 Editor: Gvim7.4
 Author: Jimbo
 mail: jimboo.lu@gmail.com
 
 Company: 
*******************************************************************************/

using UnityEngine;
using UnityEditor;
using System.Text;

public class AssetBundle {
    [MenuItem("AssetBundle/Create AssetBundlesThemelves")]
    static void CreateAssetBundleThemelves() {
        Object[] selects = Selection.GetFiltered(typeof(Object), 
                SelectionMode.DeepAssets);
        StringBuilder path = new StringBuilder(Application.dataPath);
#if UNITY_IPHONE
        foreach(Object obj in selects) {
            path = path.Append("/StreamingAssets").Append(obj.name).Append(".abi");
            if (BuildPipeline.BuildAssetBundle(obj, null, path,
                        BuildAssetBundleOptions.CollectDependencies, 
                        BuildTarget.Iphone)) {
                StringBuilder log = new StringBuilder(obj.name);
                log.Append("is packed successfully!");
                Debug.Log(log.ToString());
            }
            else {
                StringBuilder log = new StringBuilder(obj.name);
                log.Append("is packed failly!");
                Debug.Log(log.ToString());
            }
        }
#elif UNITY_ANDROID
        foreach(Object obj in selects) {
            path = path.Append("/StreamingAssets").Append(obj.name).Append(".aba");
            if(BuildPipeline.BuildAssetBundle(obj, null, path, 
                        BuildAssetBundleOptions.CollectDependencies
                        BuildTarget.Android)) {
                StringBuilder log = new StringBuilder(obj.name);
                log.Append("is packed successfully!");
                Debug.Log(log.ToString());
            }
            else {
                StringBuilder log = new StringBuilder(obj.name);
                log.Append("is packed failly!");
                Debug.Log(log.ToString());
            }
        }
#endif
        AssetDatabase.Refresh();
    }

    [MenuItem("AssetBundle/Create AssetBundlesTogether")]
    static void CreateAssetBundleTogether() {
        Object[] selects = Selection.GetFiltered(typeof(Object));
        StringBuilder path = new StringBuilder(Application.dataPath);
#if UNITY_IPHONE
        path = path.Append("/StreamingAssets").Append(obj.name).Append(".abi");
        if(BuildPipeline.BuildAssetBundle(Selection.activeObject, selection, path, 
                    BuildAssetBundleOptions.CollectDependencies, BuildTarget.Iphone)) {
            StringBuilder log = new StringBuilder(obj.name);
            log.Append("is packed successfully!");
            Debug.Log(log.ToString());

        }
        else {
            StringBuilder log = new StringBuilder(obj.name);
            log.Append("is packed failly!");
            Debug.Log(log.ToString());
        }
#if UNITY_ANDROID
        path = path.Append("/StreamingAssets").Append(obj.name).Append(".aba");
        if(BuildPipeline.BuildAssetBundle(Selection.activeObject, Selection, path,
                    BuildAssetBundleOptions.CollectDependencies, BuildTarget.Android)) {
            StringBuilder log = new StringBuilder(obj.name);
            log.Append("is packed successfully!");
            Debug.Log(log.ToString());
        }
        else {
            StringBuilder log = new StringBuilder(obj.name);
            log.Append("is packed failly!");
            Debug.Log(log.ToString());
        }
#endif
        AssetDatabase.Refresh();
    }
}
