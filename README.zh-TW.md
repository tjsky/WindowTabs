<img src="docs/images/logo.svg" width="60" height="60" alt="WindowTabs icon" align="left"/>

# WindowTabs

<p align="center">
  <b>語言 / Language</b><br />
  <a href="README.md"><img alt="English" src="https://img.shields.io/badge/English-Switch-lightgrey?style=flat-square"></a>
  <a href="README.zh-CN.md"><img alt="简体中文" src="https://img.shields.io/badge/%E7%AE%80%E4%BD%93%E4%B8%AD%E6%96%87-Switch-lightgrey?style=flat-square"></a>
  <a href="README.zh-TW.md"><img alt="繁體中文" src="https://img.shields.io/badge/%E7%B9%81%E9%AB%94%E4%B8%AD%E6%96%87-Current-brightgreen?style=flat-square"></a>
  <a href="README.ja.md"><img alt="日本語" src="https://img.shields.io/badge/%E6%97%A5%E6%9C%AC%E8%AA%9E-Switch-lightgrey?style=flat-square"></a>
</p>

為桌面上的視窗加上瀏覽器式的分頁。把任何應用程式的視窗歸到同一個群組，用點擊或快速鍵在它們之間切換。

[![Downloads](https://img.shields.io/github/downloads/tjsky/windowtabs/total)](https://github.com/tjsky/WindowTabs/releases)
[![Build](https://github.com/tjsky/WindowTabs/actions/workflows/build.yml/badge.svg)](https://github.com/tjsky/WindowTabs/actions/workflows/build.yml)

> [!NOTE]
> 這是 [tjsky 的 fork](https://github.com/tjsky/WindowTabs)，源自
> [leafOfTree/WindowTabs](https://github.com/leafOfTree/WindowTabs)，後者延續了
> [Maurice Flanagan 的原版](https://github.com/mauricef/WindowTabs)。以下記錄的每一項都是上游及其作者的工作；
> 本 fork 增加了多語言支援，並帶上了 [pull request #129](https://github.com/leafOfTree/WindowTabs/pull/129)。
> 問題回報與 PR 請提到這裡，而不是上游。

> [!IMPORTANT]
> **v2026.11.11**：支援 English、简体中文、繁體中文、日本語、العربية，可在設定視窗左下角切換；
> 並依 pull request #129 降低了閒置時的記憶體與 CPU 用量 —— 分頁圖片改存 PNG、只在需要預覽時解碼，
> 主控台視窗改從 conhost 掛鉤，支援頁新增資源用量圖表。[變更內容 →](CHANGELOG.md)

<a href="docs/images/light.png"><img src="docs/images/light-rounded.svg" width="600" alt="淺色分頁將三個檔案總管視窗歸為一群組" /></a>

<a href="docs/images/dark.png"><img src="docs/images/dark-rounded.svg" width="600" alt="深色分頁將三個檔案總管視窗歸為一群組" /></a>

## 開始使用

從 [Releases](https://github.com/tjsky/WindowTabs/releases) 下載 `WindowTabs.exe` 並執行。
它會常駐在通知區域。

- **群組視窗：** 把一個分頁拖到另一個視窗的分頁列上。拖開即可取消群組。
- **自動群組某個應用程式：** 在它的分頁上按右鍵 → **啟用自動群組**。
- **把分頁放到你喜歡的邊緣：** 在分頁上按住滑鼠右鍵，沿著視窗邊緣拖曳整排分頁，可放在頂端或沿著側邊。
  該應用程式新開的視窗會出現在那裡；分頁選單裡的 **對齊分頁** 可以把它們放回去。
- **執行任何命令或變更任何設定：** 按 **Ctrl + Alt + P** 輸入名稱
  （見[命令面板與命令列](#命令面板與命令列)）。
- **設定：** 在分頁或通知區域圖示上按右鍵。

歸為一群組的視窗會一起移動、一起縮放。視窗最大化時分頁會隱藏；把指標移到螢幕上緣即可顯示，
或在 **自動隱藏分頁** 裡設為 **永不**。

## 快速鍵

| 動作 | 預設 |
| --- | --- |
| 下一個 / 上一個分頁 | Ctrl + Alt + → / ← |
| 第 1–9 個分頁 | Ctrl + 1–9（或 Alt） |
| 搜尋分頁 | Ctrl + Alt + T；在視窗上按 Alt + Enter 可給它一個專屬按鍵 |
| 目前應用程式的新視窗 | Ctrl + Alt + N |
| 用滑鼠切換分頁 | 在分頁列上捲動，或在視窗上按住 Shift 捲動 |
| 移動目前的分頁 | 在分頁列上按住 Ctrl 捲動 |
| 關閉分頁 | Ctrl + Alt + W，或中鍵點擊 |

任何快速鍵都可以在 **設定 → 快速鍵** 裡修改。如果 Ctrl/Alt + 數字與某個應用程式衝突，
可以在該分頁的右鍵選單裡對這個應用程式關掉它。

**選用、預設關閉：** 游標暫留即切換、指標停留時顯示該分頁對應視窗的預覽圖、用首字母選分頁的引導鍵
（Alt + F，再按分頁上的字母）、分頁自動配色，以及 Alt+Tab 的替代方案。

把檔案拖到一個分頁上並稍作停留，即可把那個視窗移到前面。在**檔案總管**的分頁上放開，
檔案會像檔案總管自己那樣放進它的資料夾：Ctrl 複製、Shift 移動、右鍵拖曳則詢問，
在檔案總管裡按 **Ctrl + Z** 可以復原。

## 功能

- **外觀：** 淺色、深色或跟隨 Windows；合併式、資料夾式或浮動式分頁；
  依分頁、依應用程式或依群組著色。
- **釘選分頁：** 在分頁上按右鍵 → **釘選**，讓它留在群組的開頭，不受 **關閉其他分頁**、
  **關閉右側分頁** 和 **關閉全部分頁** 影響，重新啟動程式後依然保留。
- **應用程式規則：** 決定哪些執行中的應用程式有分頁、哪些自動群組。在 **跨應用程式群組** 下新增群組，
  可讓不同應用程式的視窗加入同一個群組；那裡某個應用程式自己的選單只會納入標題、視窗類別或命令列相符的視窗，
  適用於執行在 pythonw.exe 或 java.exe 之下的程式。靠拖曳分頁建立的群組會被記住，
  並在下方獨立的面板中列出。兩類群組都能固定顏色：在分頁上按右鍵 → **分頁顏色** →
  **為此群組記住顏色**，群組內每個分頁都會採用它。
- **群組內分割畫面：** 把一個群組裡的兩個以上視窗並排或上下顯示，像瀏覽器或編輯器那樣。
  在分頁上按右鍵 → **群組內分割畫面** 並為每一側挑一個視窗，也可以把分頁拖到視窗邊緣。
  拖曳中間的分隔列可調整大小，在它上面按右鍵可對調、平均分配、切換方向或結束分割。
  右側/下方視窗的快速鍵以及在各窗格間移動焦點的快速鍵在 **設定 → 快速鍵** 裡，預設未設定。
- **群組編輯器：** 命令面板裡的 **編輯群組…** 會把每個群組顯示成一行分頁，未歸群的視窗列在下方。
  可在列之間拖曳分頁、拖到視窗上以分割它、或拖到 **新增群組**；在按 **儲存** 之前不會有任何實際變更。
- **工作區：** 儲存群組與視窗位置，再還原到已開啟的視窗上；未執行的應用程式可以被啟動並還原其視窗。
  儲存工作區、以及還原上次儲存或還原過的工作區，這兩個快速鍵在 **設定 → 快速鍵** 裡，預設未設定。
- **滑鼠手勢：** 在 **設定 → 手勢** 裡開啟，然後按住右鍵拖曳，例如先向上再向右切換到下一個分頁。
  一個手勢可以執行 WindowTabs 命令，也可以向視窗送出快速鍵，每個應用程式還可以有自己的一套：
  瀏覽器與檔案總管預設了上一頁、下一頁之類。不拖曳的右鍵點擊仍然開啟該應用程式的分頁選單。
- **工作列：** 可以選擇把每個群組合併成一個工作列按鈕，該按鈕上顯示群組內所有應用程式。
- **語言：** English、简体中文、繁體中文、日本語、العربية。

<a href="docs/images/settings.png"><img src="docs/images/settings.png" width="600" alt="WindowTabs 設定視窗" /></a>

## 命令面板與命令列

**Ctrl + Alt + P** 開啟命令面板：輸入命令名稱後按 Enter。每個分頁選單項目、分割畫面命令、工作區命令和設定都在裡面，
旁邊顯示它們的快速鍵。開/關型設定顯示為開關，就地切換；多選項從清單中選擇；尺寸直接輸入、邊輸入邊儲存；
顏色用取色器選擇；其餘項目會開啟設定視窗並定位到它。**還原工作區…** 會列出已儲存的工作區。
對某個動作按 Alt + Enter 可為它設定快速鍵，效果與 **設定 → 快速鍵** 相同；
對某個設定按快速鍵會開啟命令面板並定位到它的選項或輸入框。視窗搜尋（**Ctrl + Alt + T**）是另一個獨立的面板，
可在目前群組的分頁之間或所有視窗之間搜尋。

兩個面板的搜尋規則一致：

- 詞可以任意順序輸入；每個詞都可以是名稱、應用程式名或命令別名的一部分，所以 `color tab` 能找到
  **分頁顏色…**，`merge` 能找到 **將此應用程式組成群組**。
- 也可以去掉空格，或輸入各詞的首字母：`movedown` 或 `md` 能找到 **下移**。
  這類比對排在含完整詞的項目之後。
- 輸入以修飾鍵或功能鍵開頭的快速鍵，例如 `ctrl+alt+t` 或 `f5`，可以查到哪個命令或視窗佔用了它。
- 上次的搜尋和最近用過的動作排在前面。
- **↑ / ↓** 和 **Page Up / Page Down** 移動，**Enter** 執行，**Esc** 返回或關閉，
  **Tab** 在視窗搜尋的各個範圍之間切換，**Ctrl + U** 清除輸入，**Ctrl + Backspace** 刪除一個詞。

同樣的命令也可以在命令列裡送給執行中的 WindowTabs：

```bash
WindowTabs.exe --command next-tab
WindowTabs.exe --command tab-color Blue
WindowTabs.exe --workspace "Project A"
WindowTabs.exe --group "C:\Program Files\App\app.exe" notepad.exe
WindowTabs.exe --commands
```

`--group` 會啟動這些應用程式並把它們開啟的視窗歸到同一個群組，`--workspace` 還原一個已儲存的工作區；
兩者在 WindowTabs 未執行時都會把它啟動起來。`--commands` 列出所有命令及其 id。

## 設定與更新

設定會自動儲存到 `%AppData%\WindowTabs\WindowTabsSettings.json`。
如需可攜使用，把這個檔案放在 `WindowTabs.exe` 旁邊即可。
匯出、匯入與重設在 **設定 → 支援** 裡。

更新時，從通知區域結束 WindowTabs，替換 exe 即可，設定會保留。

## 疑難排解

- **視窗上沒有分頁？** 檢查 **設定 → 應用程式規則**。對話框不會獲得開分頁。
- **升級後行為怪異？** **設定 → 支援 → 還原預設設定**
  （舊的設定會先備份）。
- **要以系統管理員身分執行嗎？** 不需要，也不建議。Windows 會阻擋系統管理員視窗與一般視窗之間的部分輸入，
  而且一般視窗的群組即使開啟了 **合併工作列圖示**，也仍然各佔一個工作列按鈕；
  群組的分頁選單裡會說明原因。
- **把檔案拖到分頁上沒反應？** Windows 不允許從一般應用程式拖入以系統管理員身分執行的應用程式。

還是卡住了？[提出 issue](https://github.com/tjsky/WindowTabs/issues)，附上
**設定 → 支援** 裡的疑難排解報告。報告裡不含視窗標題和路徑。

## 開發

### 建置與執行

WindowTabs 是一個執行在 .NET Framework 4.8 上的 F# WinForms 程式，另有一個小的 C# 專案做 Win32 互通。
在 Windows 10 或 11 上建置：

**1. 安裝工具**

- [.NET 10.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)：選 Windows 版安裝程式（通常是 **x64**）。
- [.NET Framework 4.8 Developer Pack](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48)：只裝執行階段不足以建置。

**2. 下載、建置並執行**

在你打算存放原始碼的資料夾裡新開一個 **PowerShell** 視窗：

```bash
git clone https://github.com/tjsky/WindowTabs
cd WindowTabs
dotnet build WindowTabs.sln                 # Debug：WtProgram\bin\Debug\WindowTabs.exe
dotnet build WindowTabs.sln -c Release      # Release：WtProgram\bin\Release\WindowTabs.exe（單一檔案）
```

上游儲存庫在 [leafOfTree/WindowTabs](https://github.com/leafOfTree/WindowTabs)；
用 `git remote add upstream` 可以從這裡跟進它的提交。

首次建置會下載 NuGet 相依套件，需要連上網路。執行產生的 exe 會讓 WindowTabs 進入通知區域；
重新建置前先結束它，因為執行中的 exe 會鎖住輸出檔案。如果提示找不到 `dotnet`，安裝後重開 PowerShell。

**或者用 Visual Studio**

安裝 [Visual Studio 2026](https://visualstudio.microsoft.com/downloads/)，勾選
**.NET 桌面開發** 工作負載，保留它預設建議的元件。開啟 `WindowTabs.sln`，
把 `WtProgram` 設為起始專案，按 **F5**。

歡迎 AI 輔助的貢獻。請確保你理解並測試過自己的變更。參見 [AGENTS.md](AGENTS.md)、
[架構說明](docs/architecture.md) 和 [測試說明](docs/testing.md)。

### 改程式碼前需要知道的事

- **執行緒：** 每個分頁群組跑在自己的 UI 執行緒上，主執行緒負責設定與視窗探索。跨執行緒呼叫走
  `Shared/Services.fs` 裡的轉接層。動這部分之前請先讀[架構說明](docs/architecture.md)。
- **介面文字：** 所有可見字串都在 `Shared/Strings.fs`，含英文、簡體中文、繁體中文、日文和阿拉伯文。
  先機翻出草稿是可以的，母語者再潤飾。[在地化說明](docs/localization.md)裡有其餘部分。
- **設定：** 名稱、預設值和範圍只在 `Shared/SettingsCatalog.fs` 宣告一次；
  設定視窗、搜尋和重設都從那裡讀取。
- **DPI 與主題：** 用邏輯像素並透過 `Dpi.scale` 縮放；在淺色、深色和高對比模式下都檢查你的介面。

## 程式碼簽署政策

上游的發行版本經過程式碼簽署：由 [SignPath.io](https://about.signpath.io) 免費提供簽署，
憑證來自 [SignPath Foundation](https://signpath.org)，由上游維護者
[@leafOfTree](https://github.com/leafOfTree) 核准，提交者與審閱者列在上游的
[貢獻者名單](https://github.com/leafOfTree/WindowTabs/graphs/contributors)裡。

本 fork 沒有自己的 SignPath 專案，因此這裡發布的 `WindowTabs.exe` 由 GitHub Actions
建置且**未簽署**，Windows 可能會在執行前詢問。如果你需要簽署版本，請從
[上游的 releases](https://github.com/leafOfTree/WindowTabs/releases) 取得。

發行用的二進位檔由 GitHub Actions 從原始碼建置，開發過程中有 AI 編碼助理參與，
但所有變更都由人類維護者審閱並合併。

### 隱私權政策

除非使用者或安裝、使用本程式的人明確要求，本程式不會把任何資訊傳輸到其他連網系統。

## 致謝與授權

由 Maurice Flanagan 於 2009 年建立（[mauricef/WindowTabs](https://github.com/mauricef/WindowTabs)），
經 [redgis](https://github.com/redgis/WindowTabs) 和 [payaneco](https://github.com/payaneco/WindowTabs) 接續，
再由 [leafOfTree](https://github.com/leafOfTree/WindowTabs) 發展成今天的樣子，本 fork 即取自那裡。

[MIT 授權](LICENSE)。版權聲明與授權正文與上游完全一致，這是授權本身的要求；
語言檔案和 [CHANGELOG.md](CHANGELOG.md) 裡列出的變更是本 fork 新增的。
感謝上面這些維護者多年打下的基礎。
