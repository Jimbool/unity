using UnityEngine;
using UnityEditor;
/// <summary>  
/// 将选中的预制分别打包  
/// </summary>  

public class AssetBundle {
    [MenuItem("AssetBundle/Create AssetBundles")]
    static void CreateAssetBundleThemelves() {
        //获取要打包的对象（在Project视图中）  
        Object[] selects = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.DeepAssets);
        //遍历选中的对象  
        foreach (Object obj in selects) {
            //这里建立一个本地测试  
            //注意本地测试中可以是任意的文件，但是到了移动平台只能读取路径StreamingAssets里面的  
            //StreamingAssets是只读路径，不能写入  
            string targetPath = Application.dataPath + "/StreamingAssets/" + obj.name + ".assetbundle";//文件的后缀名是assetbundle和unity都可以  
            if (BuildPipeline.BuildAssetBundle(obj, null, targetPath, BuildAssetBundleOptions.CollectDependencies)) {

                Debug.Log(obj.name + "is packed successfully!");
            }
            else {
                Debug.Log(obj.name + "is packed failly!");
            }
        }
        //刷新编辑器（不写的话要手动刷新,否则打包的资源不能及时在Project视图内显示）  
        AssetDatabase.Refresh();
    }

    /// <summary>  
    /// 将选中的预制打包到一起  
    /// </summary>  
    [MenuItem("AssetBundle/Create AssetBundles Together")]
    static void CreateAssetBundleTogether() {
        //要打包的对象  
        Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
        //要打包到的路径  
        string path = Application.dataPath + "/StreamingAssets/Together.assetbundle";
        if (BuildPipeline.BuildAssetBundle(Selection.activeObject, selection, path, BuildAssetBundleOptions.CollectDependencies, BuildTarget.Android)) {
            Debug.Log("Packed successfully!");

        }
        else {
            Debug.Log("Packed failly!");
        }
        //刷新编辑器（不写的话要手动刷新）  
        AssetDatabase.Refresh();
    }
}

// C# Example
// Builds an asset bundle from the selected folder in the project view.
// Bare in mind that this script doesnt track dependencies nor is recursive
//在项目视图从选择的文件夹生成资源包
//记住，这个脚本不跟踪依赖关系，也不是递归
//using UnityEngine;
//using UnityEditor;
//using System.IO;

//public class BuildAssetBundlesFromDirectory {
//    [@MenuItem("AssetBundles/Build AssetBundles")]
//    static void ExportAssetBundles() {
//        // Get the selected directory
//        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
//        Debug.Log("Selected Folder: " + path);
//        if (path.Length != 0) {
//            path = path.Replace("Assets/", "");
//            string[] fileEntries = Directory.GetFiles(Application.dataPath + "/" + path);
//            foreach (string fileName in fileEntries) {
//                string filePath = fileName.Replace("", "/");
//                int index = filePath.LastIndexOf("/");
//                filePath = filePath.Substring(index);
//                Debug.Log(filePath);
//                string localPath = "Assets/" + path;
//                if (index > 0)
//                    localPath += filePath;
//                Object t = AssetDatabase.LoadMainAssetAtPath(localPath);
//                if (t != null) {
//                    Debug.Log(t.name);
//                    string bundlePath = "Assets/" + path + "/" + t.name + ".unity3d";
//                    Debug.Log("Building bundle at: " + bundlePath);
//                    // Build the resource file from the active selection.
//                    //从激活的选择编译资源文件
//                    BuildPipeline.BuildAssetBundle
//                    (t, null, bundlePath, BuildAssetBundleOptions.CompleteAssets, BuildTarget.Android);
//                }

//            }
//        }
//    }

    //void Start() {
    //    var www = new WWW("http://myserver/myBundle.unity3d");
    //    //定义www为WWW类型并且赋予一个网络资源进行下载。

    //    yield www;

    //    //等待下载完毕，完全获取www资源。
    //    // Get the designated main asset and instantiate it.
    //    //获取指定的数据资源并且实例化。
    //    Instantiate(www.assetBundle.mainAsset);
    //    实例化生成数据在场景中。
    //}
//}

