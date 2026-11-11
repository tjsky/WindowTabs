<img src="docs/images/logo.svg" width="60" height="60" alt="WindowTabs icon" align="left"/>

# WindowTabs

<p align="center">
  <b>语言 / Language</b><br />
  <a href="README.md"><img alt="English" src="https://img.shields.io/badge/English-Switch-lightgrey?style=flat-square"></a>
  <a href="README.zh-CN.md"><img alt="简体中文" src="https://img.shields.io/badge/%E7%AE%80%E4%BD%93%E4%B8%AD%E6%96%87-Current-brightgreen?style=flat-square"></a>
  <a href="README.zh-TW.md"><img alt="繁體中文" src="https://img.shields.io/badge/%E7%B9%81%E9%AB%94%E4%B8%AD%E6%96%87-Switch-lightgrey?style=flat-square"></a>
  <a href="README.ja.md"><img alt="日本語" src="https://img.shields.io/badge/%E6%97%A5%E6%9C%AC%E8%AA%9E-Switch-lightgrey?style=flat-square"></a>
</p>

给桌面上的窗口加上浏览器式的标签页。把任何程序的窗口归到一组，用单击或快捷键在它们之间切换。

[![Downloads](https://img.shields.io/github/downloads/tjsky/windowtabs/total)](https://github.com/tjsky/WindowTabs/releases)
[![Build](https://github.com/tjsky/WindowTabs/actions/workflows/build.yml/badge.svg)](https://github.com/tjsky/WindowTabs/actions/workflows/build.yml)

> [!NOTE]
> 这是 [tjsky 的 fork](https://github.com/tjsky/WindowTabs)，源自
> [leafOfTree/WindowTabs](https://github.com/leafOfTree/WindowTabs)，后者延续了
> [Maurice Flanagan 的原版](https://github.com/mauricef/WindowTabs)。下面记录的每一项都是上游及其作者的工作；
> 本 fork 增加了多语言支持，并带上了 [pull request #129](https://github.com/leafOfTree/WindowTabs/pull/129)。
> 问题反馈与 PR 请提到这里，而不是上游。

> [!IMPORTANT]
> **v2026.11.11**：支持 English、简体中文、繁體中文、日本語、العربية，可在设置窗口左下角切换；
> 并按 pull request #129 降低了空闲时的内存与 CPU 占用 —— 标签截图改为存 PNG、只在需要预览时解码，
> 控制台窗口改从 conhost 挂钩，支持页新增资源占用曲线。[改动详情 →](CHANGELOG.md)

<a href="docs/images/light.png"><img src="docs/images/light-rounded.svg" width="600" alt="浅色标签页归组了三个文件资源管理器窗口" /></a>

<a href="docs/images/dark.png"><img src="docs/images/dark-rounded.svg" width="600" alt="深色标签页归组了三个文件资源管理器窗口" /></a>

## 开始使用

从 [Releases](https://github.com/tjsky/WindowTabs/releases) 下载 `WindowTabs.exe` 并运行。
它常驻在通知区域。

- **归组窗口：** 把一个标签拖到另一个窗口的标签栏上。拖开即可取消归组。
- **自动归组某个程序：** 右键点它的标签 → **启用自动归组**。
- **把标签放到你喜欢的边缘：** 在标签上按住鼠标右键，沿窗口边缘拖动整排标签，可放在顶部或沿着侧边。
  该程序新开的窗口会出现在那里；标签菜单里的 **对齐标签** 可以把它们放回去。
- **执行任意命令或修改任意设置：** 按 **Ctrl + Alt + P** 输入名称
  （见[命令面板与命令行](#命令面板与命令行)）。
- **设置：** 右键点标签或通知区域图标。

归组的窗口会一起移动、一起缩放。窗口最大化时标签会隐藏；把指针移到屏幕上边缘即可显示，
或在 **自动隐藏标签** 里设为 **从不**。

## 快捷键

| 操作 | 默认 |
| --- | --- |
| 下一个 / 上一个标签 | Ctrl + Alt + → / ← |
| 第 1–9 个标签 | Ctrl + 1–9（或 Alt） |
| 搜索标签 | Ctrl + Alt + T；在窗口上按 Alt + Enter 可给它一个专属按键 |
| 当前程序的新窗口 | Ctrl + Alt + N |
| 用鼠标切换标签 | 在标签栏上滚动，或在窗口上按住 Shift 滚动 |
| 移动当前标签 | 在标签栏上按住 Ctrl 滚动 |
| 关闭标签 | Ctrl + Alt + W，或中键单击 |

任何快捷键都可以在 **设置 → 快捷键** 里修改。如果 Ctrl/Alt + 数字与某个程序冲突，
可以在该标签的右键菜单里对这个程序关掉它。

**可选、默认关闭：** 悬停即切换、指针停留时显示该标签对应窗口的预览图、用首字母选标签的引导键
（Alt + F，再按标签上的字母）、标签自动配色，以及 Alt+Tab 的替代方案。

把文件拖到一个标签上并稍作停留，即可把那个窗口调到前面。在**文件资源管理器**的标签上松手，
文件会像资源管理器自己那样放进它的目录：Ctrl 复制、Shift 移动、右键拖动则询问，
在资源管理器里按 **Ctrl + Z** 可以撤销。

## 功能

- **外观：** 浅色、深色或跟随 Windows；合并式、文件夹式或悬浮式标签；
  按标签、按应用或按分组着色。
- **固定标签：** 右键点标签 → **固定**，让它留在分组的头部，不受 **关闭其他标签**、
  **关闭右侧标签** 和 **关闭全部标签** 影响，重启程序后依然保留。
- **应用规则：** 决定哪些正在运行的应用有标签、哪些自动归组。在 **跨应用分组** 下添加分组，
  可让不同程序的窗口加入同一个组；那里某个应用自己的菜单只会纳入标题、窗口类名或命令行匹配的窗口，
  适用于跑在 pythonw.exe 或 java.exe 之下的程序。靠拖动标签建立的分组会被记住，
  并在下方单独的面板里列出。两类分组都能固定颜色：右键点标签 → **标签颜色** →
  **为此分组记住颜色**，组内每个标签都会采用它。
- **组内分屏：** 把一个分组里的两个或更多窗口并排或上下显示，像浏览器或编辑器那样。
  右键点标签 → **组内分屏** 并为每一侧挑一个窗口，也可以把标签拖到窗口边缘。
  拖动中间的分隔条可调整大小，右键点它可对调、均分、切换方向或结束分屏。
  右侧/下方窗口的快捷键以及在各窗格间移动焦点的快捷键在 **设置 → 快捷键** 里，默认未设置。
- **分组编辑器：** 命令面板里的 **编辑分组…** 会把每个分组显示成一行标签，未归组的窗口列在下方。
  可在行之间拖动标签、拖到窗口上以分割它、或拖到 **新建分组**；在点 **保存** 之前不会有任何实际变动。
- **工作区：** 保存分组与窗口位置，再还原到已打开的窗口上；未运行的程序可以被启动并还原其窗口。
  保存工作区、以及还原上次保存或还原过的工作区，这两个快捷键在 **设置 → 快捷键** 里，默认未设置。
- **鼠标手势：** 在 **设置 → 手势** 里开启，然后按住右键拖动，例如先向上再向右切换到下一个标签。
  一个手势可以执行 WindowTabs 命令，也可以向窗口发送快捷键，每个程序还可以有自己的一套：
  浏览器和文件资源管理器预置了后退、前进之类。不拖动的右键单击仍然打开该程序的标签菜单。
- **任务栏：** 可以选择把每个分组合并成一个任务栏按钮，该按钮上显示组内所有程序。
- **语言：** English、简体中文、繁體中文、日本語、العربية。

<a href="docs/images/settings.png"><img src="docs/images/settings.png" width="600" alt="WindowTabs 设置窗口" /></a>

## 命令面板与命令行

**Ctrl + Alt + P** 打开命令面板：输入命令名称后按回车。每个标签菜单项、分屏命令、工作区命令和设置都在里面，
旁边显示它们的快捷键。开/关型设置显示为开关，就地拨动；多选项从列表中选择；尺寸直接输入、边输入边保存；
颜色用取色器选择；其余项会打开设置窗口并定位到它。**还原工作区…** 会列出已保存的工作区。
对某个动作按 Alt + Enter 可为它设置快捷键，效果与 **设置 → 快捷键** 相同；
对某个设置按快捷键会打开命令面板并定位到它的选项或输入框。窗口搜索（**Ctrl + Alt + T**）是另一个独立的面板，
可在当前分组的标签之间或所有窗口之间搜索。

两个面板的搜索规则一致：

- 词可以任意顺序输入；每个词都可以是名称、程序名或命令别名的一部分，所以 `color tab` 能找到
  **标签颜色…**，`merge` 能找到 **归组此程序**。
- 也可以去掉空格，或输入各词的首字母：`movedown` 或 `md` 能找到 **下移**。
  这类匹配排在含完整词的条目之后。
- 输入以修饰键或功能键开头的快捷键，例如 `ctrl+alt+t` 或 `f5`，可以查到哪个命令或窗口占用了它。
- 上次的搜索和最近用过的动作排在前面。
- **↑ / ↓** 和 **Page Up / Page Down** 移动，**Enter** 执行，**Esc** 返回或关闭，
  **Tab** 在窗口搜索的各个范围之间切换，**Ctrl + U** 清空输入，**Ctrl + Backspace** 删除一个词。

同样的命令也可以在命令行里发给正在运行的 WindowTabs：

```bash
WindowTabs.exe --command next-tab
WindowTabs.exe --command tab-color Blue
WindowTabs.exe --workspace "Project A"
WindowTabs.exe --group "C:\Program Files\App\app.exe" notepad.exe
WindowTabs.exe --commands
```

`--group` 会启动这些程序并把它们打开的窗口归到一组，`--workspace` 还原一个已保存的工作区；
两者在 WindowTabs 未运行时都会把它启动起来。`--commands` 列出所有命令及其 id。

## 设置与更新

设置会自动保存到 `%AppData%\WindowTabs\WindowTabsSettings.json`。
如需便携使用，把这个文件放在 `WindowTabs.exe` 旁边即可。
导出、导入和重置在 **设置 → 支持** 里。

更新时，从通知区域退出 WindowTabs，替换 exe 即可，设置会保留。

## 疑难排查

- **窗口上没有标签？** 检查 **设置 → 应用规则**。对话框不会获得标签。
- **升级后行为怪异？** **设置 → 支持 → 恢复默认设置**
  （旧的设置会先备份）。
- **要以管理员身份运行吗？** 不需要，也不建议。Windows 会拦截管理员窗口与普通窗口之间的部分输入，
  而且普通窗口的分组即使打开了 **合并任务栏图标**，也仍然各占一个任务栏按钮；
  分组的标签菜单里会说明原因。
- **把文件拖到标签上没反应？** Windows 不允许从普通程序拖入以管理员身份运行的程序。

还是卡住了？[提一个 issue](https://github.com/tjsky/WindowTabs/issues)，附上
**设置 → 支持** 里的疑难排查报告。报告里不含窗口标题和路径。

## 开发

### 构建与运行

WindowTabs 是一个跑在 .NET Framework 4.8 上的 F# WinForms 程序，另有一个小的 C# 项目做 Win32 互操作。
在 Windows 10 或 11 上构建：

**1. 安装工具**

- [.NET 10.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)：选 Windows 版安装程序（通常是 **x64**）。
- [.NET Framework 4.8 Developer Pack](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48)：只装运行时不足以构建。

**2. 下载、构建并运行**

在你打算存放源码的目录里新开一个 **PowerShell** 窗口：

```bash
git clone https://github.com/tjsky/WindowTabs
cd WindowTabs
dotnet build WindowTabs.sln                 # Debug：WtProgram\bin\Debug\WindowTabs.exe
dotnet build WindowTabs.sln -c Release      # Release：WtProgram\bin\Release\WindowTabs.exe（单文件）
```

上游仓库在 [leafOfTree/WindowTabs](https://github.com/leafOfTree/WindowTabs)；
用 `git remote add upstream` 可以从这里跟进它的提交。

首次构建会下载 NuGet 依赖，需要联网。运行生成的 exe 会让 WindowTabs 进入通知区域；
重新构建前先退出它，因为运行中的 exe 会锁住输出文件。如果提示找不到 `dotnet`，安装后重开 PowerShell。

**或者用 Visual Studio**

安装 [Visual Studio 2026](https://visualstudio.microsoft.com/downloads/)，勾选
**.NET 桌面开发** 工作负载，保留它默认推荐的组件。打开 `WindowTabs.sln`，
把 `WtProgram` 设为启动项目，按 **F5**。

欢迎 AI 辅助的贡献。请确保你理解并测试过自己的改动。参见 [AGENTS.md](AGENTS.md)、
[架构说明](docs/architecture.md) 和 [测试说明](docs/testing.md)。

### 改代码前需要知道的事

- **线程：** 每个标签分组跑在自己的 UI 线程上，主线程负责设置与窗口发现。跨线程调用走
  `Shared/Services.fs` 里的适配层。动这部分之前请先读[架构说明](docs/architecture.md)。
- **界面文字：** 所有可见字符串都在 `Shared/Strings.fs`，含英文、简体中文、繁体中文、日文和阿拉伯文。
  先机翻出草稿是可以的，母语者再润色。[本地化说明](docs/localization.md)里有其余部分。
- **设置：** 名称、默认值和取值范围只在 `Shared/SettingsCatalog.fs` 声明一次；
  设置窗口、搜索和重置都从那里读取。
- **DPI 与主题：** 用逻辑像素并通过 `Dpi.scale` 缩放；在浅色、深色和高对比度模式下都检查你的界面。

## 代码签名政策

上游的发布版本经过代码签名：由 [SignPath.io](https://about.signpath.io) 免费提供签名，
证书来自 [SignPath Foundation](https://signpath.org)，由上游维护者
[@leafOfTree](https://github.com/leafOfTree) 批准，提交者与审核者列在上游的
[贡献者名单](https://github.com/leafOfTree/WindowTabs/graphs/contributors)里。

本 fork 没有自己的 SignPath 项目，因此这里发布的 `WindowTabs.exe` 由 GitHub Actions
构建且**未签名**，Windows 可能会在运行前询问。如果你需要签名版本，请从
[上游的 releases](https://github.com/leafOfTree/WindowTabs/releases) 获取。

发布用的二进制由 GitHub Actions 从源码构建，开发过程中有 AI 编码助手参与，
但所有改动都由人类维护者审阅并合并。

### 隐私政策

除非用户或安装、使用本程序的人明确要求，本程序不会把任何信息传输到其他联网系统。

## 致谢与许可

由 Maurice Flanagan 于 2009 年创建（[mauricef/WindowTabs](https://github.com/mauricef/WindowTabs)），
经 [redgis](https://github.com/redgis/WindowTabs) 和 [payaneco](https://github.com/payaneco/WindowTabs) 继续，
再由 [leafOfTree](https://github.com/leafOfTree/WindowTabs) 发展到今天的样子，本 fork 即取自那里。

[MIT 许可](LICENSE)。版权声明与许可正文与上游完全一致，这是许可本身的要求；
语言文件和 [CHANGELOG.md](CHANGELOG.md) 里列出的改动是本 fork 新增的。
感谢上面这些维护者多年打下的基础。
