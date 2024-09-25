using UnityEditor;
using UnityEngine;

namespace UnityDevTools
{
    [InitializeOnLoad]
    public class ActiveToggle
    {
        static ActiveToggle()
        {
            // 订阅EditorApplication.hierarchyWindowItemOnGUI事件
            EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyWindowItemOnGUI;
        }

        private static void OnHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
        {
            // 通过实例ID获取GameObject对象
            GameObject obj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (obj == null) return;  // 如果对象为空，直接返回

            // 定义激活状态切换按钮的矩形区域
            Rect toggleRect = new Rect(selectionRect)
            {
                xMin = selectionRect.xMax - 20,  // 设置按钮的左边界
                width = 20  // 设置按钮的宽度
            };

            // 绘制Toggle按钮并获取其当前状态
            bool isActive = GUI.Toggle(toggleRect, obj.activeSelf, "");

            // 如果激活状态发生变化，更新对象的激活状态
            if (obj.activeSelf != isActive)
            {
                obj.SetActive(isActive);

                // 如果不在播放模式下，标记场景和对象为已修改
                if (!EditorApplication.isPlaying)
                {
                    UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(obj.scene);
                    EditorUtility.SetDirty(obj);
                }
            }
        }
    }
}