# UnityDevTools

一个轻量的 Unity 开发工具箱，收录常用的编辑器增强和运行时工具。

## 开发环境

- Unity `6000.0.20f1`
- Universal Render Pipeline `17.0.3`
- Input System `1.11.0`

## 功能

### Hierarchy 激活开关

在 Hierarchy 面板右侧显示开关，可直接切换 GameObject 的激活状态。

### Hierarchy 分类样式

根据 GameObject 名称前缀设置文字颜色、背景颜色、对齐方式和字体样式。配置文件位于：

```text
Assets/Plugins/UnityDevTools/Editor/Hierarchy/Colourful Hierarchy Category GameObject/Color Palette.asset
```

### 常用目录创建

通过 Unity 菜单 `Tools > CreateFolder` 创建项目常用目录，支持一次创建全部目录，也支持单独创建 `Resources`、`StreamingAssets`、`Plugins` 和 `Scripts`。

### 文件与图片工具

`FileUtils` 提供以下功能：

- 获取指定目录下的文件夹名称
- 获取并筛选指定目录下的文件名称
- 从本地文件加载 `Texture2D`
- 从本地文件加载 `Sprite`

### MonoBehaviour 单例

`SingletonUtil<T>` 提供常用的 MonoBehaviour 单例访问方式，并支持查找场景中未激活的现有对象。

## 使用方式

1. 使用 Unity Hub 打开项目根目录。
2. 等待 Unity 完成资源和 Package 导入。
3. 打开示例场景：

```text
Assets/Plugins/UnityDevTools/SampleScenes/Sample.unity
```

如果只需要工具代码，也可以将下面的目录复制到其他 Unity 项目的 `Assets/Plugins` 下：

```text
Assets/Plugins/UnityDevTools
```

## 目录结构

```text
Assets/Plugins/UnityDevTools/
├─ Editor/          # Unity 编辑器扩展
├─ SampleScenes/    # 示例场景与脚本
└─ Utils/           # 运行时通用工具
```

## 注意事项

- `Editor` 目录下的代码仅用于 Unity 编辑器，不会参与运行时构建。
- 从文件加载的 Texture2D 和 Sprite 使用完成后，应根据实际生命周期及时释放相关资源。
- 当前仓库以完整 Unity 示例工程形式提供，尚未封装为 UPM Package。
