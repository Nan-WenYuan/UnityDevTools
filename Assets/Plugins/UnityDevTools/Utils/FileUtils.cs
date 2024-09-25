using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Plugins.UnityDevTools.Utils
{
    public class FileUtils
    {
        /// <summary>
        /// 获取指定路径下的所有文件夹名称
        /// </summary>
        /// <param name="path">指定的文件夹路径</param>
        /// <returns>文件夹名称的列表</returns>
        public static List<string> GetAllDirectories(string path)
        {
            List<string> directoryNames = new List<string>();

            try
            {
                // 判断路径是否存在
                if (Directory.Exists(path))
                {
                    // 获取所有子文件夹路径
                    string[] directories = Directory.GetDirectories(path);

                    // 提取文件夹名称
                    foreach (string directory in directories)
                    {
                        // 仅获取文件夹名称，而不是全路径
                        directoryNames.Add(Path.GetFileName(directory));
                    }
                }
                else
                {
                    Console.WriteLine("路径不存在: " + path);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("获取文件夹名称时发生错误: " + e.Message);
            }

            return directoryNames;
        }

        /// <summary>
        /// 获取指定路径下的所有文件名称，忽略特定类型
        /// </summary>
        /// <param name="path">指定的文件夹路径</param>
        /// <param name="ignoreExtensions">需要忽略的文件扩展名列表（如 .txt, .png）</param>
        /// <returns>文件名称的列表</returns>
        public static List<string> GetAllFiles(string path, List<string> ignoreExtensions = null)
        {
            List<string> fileNames = new List<string>();
            
            // 默认忽略.meta文件
            if (ignoreExtensions == null)
            {
                ignoreExtensions = new List<string> { ".meta" };
            }
            else if (!ignoreExtensions.Contains(".meta"))
            {
                ignoreExtensions.Add(".meta");
            }
            
            try
            {
                // 判断路径是否存在
                if (Directory.Exists(path))
                {
                    // 获取路径下的所有文件
                    string[] files = Directory.GetFiles(path);

                    // 提取文件名称并忽略指定类型的文件
                    foreach (string file in files)
                    {
                        string extension = Path.GetExtension(file);

                        // 检查文件是否在忽略列表中
                        if (ignoreExtensions == null || !ignoreExtensions.Contains(extension))
                        {
                            // 仅获取文件名，而不是全路径
                            fileNames.Add(Path.GetFileName(file));
                        }
                    }
                }
                else
                {
                    Console.WriteLine("路径不存在: " + path);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("获取文件名称时发生错误: " + e.Message);
            }

            return fileNames;
        }

        /// <summary>
        /// 获取指定路径下的所有自定义类型的文件名称
        /// </summary>
        /// <param name="path">指定的文件夹路径</param>
        /// <param name="customExtensions">需要包含的文件扩展名列表（如 .txt, .png）</param>
        /// <returns>文件名称的列表</returns>
        public static List<string> GetAllCustomFiles(string path, List<string> customExtensions)
        {
            List<string> fileNames = new List<string>();

            try
            {
                // 判断路径是否存在
                if (Directory.Exists(path))
                {
                    // 获取路径下的所有文件
                    string[] files = Directory.GetFiles(path);

                    // 提取符合自定义扩展名的文件名称
                    foreach (string file in files)
                    {
                        string extension = Path.GetExtension(file);

                        // 检查文件是否在自定义类型列表中
                        if (customExtensions.Contains(extension))
                        {
                            // 仅获取文件名，而不是全路径
                            fileNames.Add(Path.GetFileName(file));
                        }
                    }
                }
                else
                {
                    Console.WriteLine("路径不存在: " + path);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("获取文件名称时发生错误: " + e.Message);
            }

            return fileNames;
        }

        /// <summary>
        /// 从文件路径加载图片并返回Sprite
        /// </summary>
        /// <param name="filePath">图片文件的路径</param>
        /// <returns>加载的图片转换成的Sprite对象</returns>
        public static Sprite LoadSpriteFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Debug.LogError("文件不存在: " + filePath);
                return null;
            }

            try
            {
                // 读取图片的字节数据
                byte[] fileData = File.ReadAllBytes(filePath);

                // 创建一个新的Texture2D
                Texture2D texture = new Texture2D(2, 2);

                // 将字节数据加载到Texture2D
                if (texture.LoadImage(fileData))
                {
                    // 创建Sprite
                    return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                        new Vector2(0.5f, 0.5f));
                }
                else
                {
                    Debug.LogError("图片加载失败: " + filePath);
                    return null;
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("加载图片时发生错误: " + e.Message);
                return null;
            }
        }


        /// <summary>
        /// 从文件路径加载图片并返回Texture2D
        /// </summary>
        /// <param name="filePath">图片文件的路径</param>
        /// <returns>加载的图片转换成的Texture2D对象</returns>
        public static Texture2D LoadTextureFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Debug.LogError("文件不存在: " + filePath);
                return null;
            }

            try
            {
                // 读取图片的字节数据
                byte[] fileData = File.ReadAllBytes(filePath);

                // 创建一个新的Texture2D
                Texture2D texture = new Texture2D(2, 2);

                // 将字节数据加载到Texture2D
                if (texture.LoadImage(fileData))
                {
                    return texture; // 返回加载的Texture2D
                }
                else
                {
                    Debug.LogError("图片加载失败: " + filePath);
                    return null;
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("加载图片时发生错误: " + e.Message);
                return null;
            }
        }
    }
}