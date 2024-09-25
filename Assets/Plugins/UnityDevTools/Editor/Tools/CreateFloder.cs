using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace UnityDevTools
{
    #region Unity常用文件夹结构

    /*
    |-- Scenes/                  // 存放场景文件
    |-- Scripts/                 // 存放游戏脚本文件
    |-- Prefabs/                 // 存放预制件
    |-- Materials/               // 存放材质
    |-- Textures/                // 存放贴图
    |-- Animations/              // 存放动画剪辑或动画控制器
    |-- Audio/                   // 存放音频文件
    |-- Resources/               // 存放需要通过Resources.Load加载的资源
    |-- Editor/                  // 存放编辑器脚本
    |-- Plugins/                 // 存放插件和第三方库
    |-- StreamingAssets/         // 存放需要在运行时访问的数据文件
    |-- Shaders/                 // 存放着色器文件
    |-- Editor Default Resources/ // 存放自定义编辑器默认资源
    |-- Gizmos/                  // 存放自定义Gizmos图标
     */

    #endregion

    public class CreateFloder
    {
        /// <summary>
        /// 根目录文件夹名
        /// </summary>
        private static string _rootFolderName = "";

        /// <summary>
        /// 要创建的文件夹
        /// </summary>
        private static string _folderArray = "Animation,Audio,Scenes,Texture,Materials,Shaders,Prefabs,Scripts";

        /// <summary>
        /// Asset目录路径
        /// </summary>
        private static string _assetPath = Application.dataPath;

        /// <summary>
        /// 在Project创建指定文件夹
        /// </summary>
        [MenuItem("Tools/CreateFolder/All")]
        public static void CreatAllProjectFolder()
        {
            string[] _strArr = _folderArray.Split(',');
            foreach (string str in _strArr)
            {
                string _folderPath = _assetPath + "/" + _rootFolderName + "/" + str;
                if (!Directory.Exists(_folderPath))
                    Directory.CreateDirectory(_folderPath);
            }

            //刷新目录
            AssetDatabase.Refresh();
        }


        [MenuItem("Tools/CreateFolder/Single/Resources")]
        public static void CreatFolder_Resources()
        {
            CreatFolder(_assetPath, "Resources");
        }

        [MenuItem("Tools/CreateFolder/Single/StreamingAssets")]
        public static void CreatFolder_StreamingAssets()
        {
            CreatFolder(_assetPath, "StreamingAssets");
        }

        [MenuItem("Tools/CreateFolder/Single/Plugins")]
        public static void CreatFolder_Plugins()
        {
            CreatFolder(_assetPath, "Plugins");
        }

        [MenuItem("Tools/CreateFolder/Single/Scripts")]
        public static void CreatFolder_Scripts()
        {
            CreatFolder(_assetPath, "Scripts");
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        private static void CreatFolder(string _assetPath, string _folderName)
        {
            string _folderPath = _assetPath + "/" + _folderName;
            if (!Directory.Exists(_folderPath))
                Directory.CreateDirectory(_folderPath);
            //刷新目录
            AssetDatabase.Refresh();
        }
    }
}