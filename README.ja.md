<img src="docs/images/logo.svg" width="60" height="60" alt="WindowTabs icon" align="left"/>

# WindowTabs

<p align="center">
  <b>言語 / Language</b><br />
  <a href="README.md"><img alt="English" src="https://img.shields.io/badge/English-Switch-lightgrey?style=flat-square"></a>
  <a href="README.zh-CN.md"><img alt="简体中文" src="https://img.shields.io/badge/%E7%AE%80%E4%BD%93%E4%B8%AD%E6%96%87-Switch-lightgrey?style=flat-square"></a>
  <a href="README.zh-TW.md"><img alt="繁體中文" src="https://img.shields.io/badge/%E7%B9%81%E9%AB%94%E4%B8%AD%E6%96%87-Switch-lightgrey?style=flat-square"></a>
  <a href="README.ja.md"><img alt="日本語" src="https://img.shields.io/badge/%E6%97%A5%E6%9C%AC%E8%AA%9E-Current-brightgreen?style=flat-square"></a>
</p>

デスクトップのウィンドウにブラウザ風のタブを付けます。どのアプリのウィンドウでもまとめてグループ化し、
クリックかショートカットで切り替えられます。

[![Downloads](https://img.shields.io/github/downloads/tjsky/windowtabs/total)](https://github.com/tjsky/WindowTabs/releases)
[![Build](https://github.com/tjsky/WindowTabs/actions/workflows/build.yml/badge.svg)](https://github.com/tjsky/WindowTabs/actions/workflows/build.yml)

> [!NOTE]
> このリポジトリは [leafOfTree/WindowTabs](https://github.com/leafOfTree/WindowTabs) のフォークで、
> その元は [Maurice Flanagan のオリジナル](https://github.com/mauricef/WindowTabs) です。5 言語への対応と、
> [pull request #129](https://github.com/leafOfTree/WindowTabs/pull/129) のリソース改善を取り込んでいます。
> Issue と pull request は上流ではなくこちらへお願いします。

> [!IMPORTANT]
> **v2026.11.11**：English、简体中文、繁體中文、日本語、العربية の 5 言語に対応し、設定ウィンドウの
> 左下で切り替えられます。アイドル時のメモリと CPU の使用量も削減し、サポート画面に直近 1 時間と
> 1 日分のリソース使用量グラフを追加しました。[変更点 →](CHANGELOG.md)

<a href="docs/images/light.png"><img src="docs/images/light-rounded.svg" width="600" alt="ライトテーマでエクスプローラーのウィンドウ 3 つを 1 つのグループにまとめたタブ" /></a>

<a href="docs/images/dark.png"><img src="docs/images/dark-rounded.svg" width="600" alt="ダークテーマでエクスプローラーのウィンドウ 3 つを 1 つのグループにまとめたタブ" /></a>

## はじめかた

[Releases](https://github.com/tjsky/WindowTabs/releases) から `WindowTabs.exe` をダウンロードして実行します。
常駐します（通知領域）。

- **ウィンドウをグループ化：** タブを別のウィンドウのタブバーへドラッグします。離せばグループから外れます。
- **アプリを自動でグループ化：** そのタブを右クリック → **自動グループ化を有効にする**。
- **タブを好きな位置へ：** タブ上で右ボタンを押したまま、ウィンドウの縁に沿ってタブ列をドラッグします。
  上端でも側面でも構いません。そのアプリの新しいウィンドウはそこに開き、タブメニューの
  **タブを整列** で元に戻せます。
- **コマンドの実行や設定の変更：** **Ctrl + Alt + P** を押して名前を入力します
  （[コマンドパレットとコマンドライン](#コマンドパレットとコマンドライン) を参照）。
- **設定：** タブまたは通知領域のアイコンを右クリックします。

グループ化したウィンドウは一緒に移動し、一緒にサイズが変わります。最大化したウィンドウではタブが隠れます。
画面上端にポインタを合わせると表示され、**タブを自動的に隠す** を **しない** にもできます。

## ショートカット

| 操作 | 既定 |
| --- | --- |
| 次のタブ / 前のタブ | Ctrl + Alt + → / ← |
| タブ 1〜9 | Ctrl + 1〜9（または Alt） |
| タブを検索 | Ctrl + Alt + T。ウィンドウ上で Alt + Enter を押すと専用のキーを割り当てられます |
| 現在のアプリの新しいウィンドウ | Ctrl + Alt + N |
| マウスでタブを切り替え | タブバー上でスクロール、またはウィンドウ上で Shift + スクロール |
| 現在のタブを移動 | タブバー上で Ctrl + スクロール |
| タブを閉じる | Ctrl + Alt + W、または中クリック |

ショートカットは **設定 → ショートカット** で変更できます。Ctrl/Alt + 数字があるアプリと衝突する場合は、
そのタブの右クリックメニューからそのアプリについてだけ無効にできます。

**任意・既定でオフ：** ホバーで切り替え、ポインタを止めるとタブのウィンドウ画像を表示、
頭文字でタブを選ぶリーダーキー（Alt + F のあとタブの文字）、タブの自動色分け、Alt+Tab の置き換え。

ファイルをタブへドラッグして少し止めると、そのウィンドウが前面に出ます。**エクスプローラー** のタブで
離せば、エクスプローラー自身と同じようにそのフォルダーへドロップされます。Ctrl でコピー、Shift で移動、
右ドラッグなら確認、エクスプローラー内の **Ctrl + Z** で元に戻せます。

## 機能

- **外観：** ライト、ダーク、Windows に従う。タブは結合・フォルダー・フローティング。
  色はタブ単位、アプリ単位、グループ単位で指定できます。
- **タブのピン留め：** タブを右クリック → **ピン留め** でグループの先頭に固定し、
  **他を閉じる**、**右側のタブを閉じる**、**すべて閉じる** の対象から外れます。再起動後も残ります。
- **アプリのルール：** 実行中のどのアプリにタブを付けるか、どれを自動でグループ化するかを決めます。
  **アプリをまたぐグループ** でグループを追加すると、別々のアプリのウィンドウを 1 つのグループに
  入れられます。そこでのアプリごとのメニューは、タイトル・ウィンドウクラス・コマンドラインが一致する
  ウィンドウだけを取り込みます（pythonw.exe や java.exe で動くアプリなど）。
  タブのドラッグで作ったグループは記憶され、下の独立したパネルに並びます。どちらの種類のグループにも
  色を固定できます。タブを右クリック → **タブの色** → **このグループの色を記憶** で、
  グループ内のすべてのタブがその色になります。
- **分割表示：** グループ内の 2 つ以上のウィンドウを、ブラウザやエディターのように並べて、または
  上下に表示します。タブを右クリック → **分割表示** で各側のウィンドウを選ぶか、タブをウィンドウの縁へ
  ドラッグします。間のバーをドラッグして大きさを変え、右クリックで入れ替え、均等化、向きの切り替え、
  分割の終了ができます。右側・下側のウィンドウや、ペイン間でフォーカスを移すショートカットは
  **設定 → ショートカット** にあり、既定では未設定です。
- **グループエディター：** コマンドパレットの **グループを編集…** で、各グループがタブの行として並び、
  まとまっていないウィンドウが下に出ます。行の間でタブをドラッグし、ウィンドウの上へドラッグすれば分割、
  **新しいグループ** へドラッグすれば移動します。**保存** を押すまで実際には何も動きません。
- **ワークスペース：** グループとウィンドウの位置を保存し、開いているウィンドウへ復元します。
  実行していないアプリは起動してそのウィンドウを復元できます。ワークスペースの保存と、
  最後に保存または復元したものを復元するショートカットは **設定 → ショートカット** にあり、
  既定では未設定です。
- **マウスジェスチャー：** **設定 → ジェスチャー** で有効にし、右ボタンを押したままドラッグします
  （例：上から右で次のタブ）。ジェスチャーは WindowTabs のコマンドを実行するか、ウィンドウへ
  ショートカットを送ります。アプリごとに独自のものも持て、ブラウザとエクスプローラーには
  戻る・進むなどが最初から入っています。ドラッグしない右クリックは従来どおりタブメニューを開きます。
- **タスクバー：** 各グループを 1 つのタスクバーボタンにまとめられます。ボタンにはグループ内の
  すべてのアプリが表示されます。
- **言語：** English、简体中文、繁體中文、日本語、العربية。

<a href="docs/images/settings.png"><img src="docs/images/settings.png" width="600" alt="WindowTabs の設定ウィンドウ" /></a>

## コマンドパレットとコマンドライン

**Ctrl + Alt + P** でコマンドパレットが開きます。コマンド名を入力して Enter を押します。
タブメニューのすべての項目、分割表示のコマンド、ワークスペースのコマンド、そしてすべての設定が並び、
横にショートカットが表示されます。オン/オフの設定はスイッチとして表示され、その場で切り替わります。
選択肢は一覧から選び、サイズは入力と同時に保存され、色はカラーピッカーで選び、
それ以外は設定ウィンドウの該当箇所が開きます。**ワークスペースを復元…** は保存済みの一覧を出します。
アクション上で Alt + Enter を押すとショートカットを設定でき（**設定 → ショートカット** と同じ）、
設定上で押すとその選択肢や入力欄にパレットが開きます。ウィンドウ検索（**Ctrl + Alt + T**）は別のパネルで、
グループ内のタブとすべてのウィンドウを切り替えて検索できます。

検索のしかたはどちらのパネルでも同じです。

- 語は順不同で入力できます。各語は名前、アプリ名、コマンドの別名の一部でよいので、`color tab` で
  **タブの色…**、`merge` で **このアプリをグループ化** が見つかります。
- 空白を省いたり、各語の頭文字だけでも探せます。`movedown` や `md` で **下へ移動** が出ます。
  これらは語そのものを持つ行の後に並びます。
- 修飾キーやファンクションキーで始まるショートカット（`ctrl+alt+t`、`f5` など）を入力すると、
  どのコマンドやウィンドウがそれを使っているか分かります。
- 前回の検索と最近使ったアクションが先頭に来ます。
- **↑ / ↓** と **Page Up / Page Down** で移動、**Enter** で実行、**Esc** で戻るか閉じる、
  **Tab** でウィンドウ検索の範囲を切り替え、**Ctrl + U** で入力を消し、
  **Ctrl + Backspace** で 1 語削除します。

同じコマンドは、実行中の WindowTabs へコマンドラインからも送れます。

```bash
WindowTabs.exe --command next-tab
WindowTabs.exe --command tab-color Blue
WindowTabs.exe --workspace "Project A"
WindowTabs.exe --group "C:\Program Files\App\app.exe" notepad.exe
WindowTabs.exe --commands
```

`--group` は指定したプログラムを起動し、そのウィンドウを 1 つのグループにまとめます。
`--workspace` は保存したワークスペースを復元します。どちらも WindowTabs が起動していなければ
起動します。`--commands` はすべてのコマンドと id を一覧表示します。

## 設定と更新

設定は `%AppData%\WindowTabs\WindowTabsSettings.json` に自動保存されます。
ポータブルに使うには、このファイルを `WindowTabs.exe` の隣に置いてください。
エクスポート、インポート、リセットは **設定 → サポート** にあります。

更新は、通知領域から WindowTabs を終了し、exe を差し替えるだけです。設定は残ります。

## 困ったときは

- **ウィンドウにタブが付かない？** **設定 → アプリのルール** を確認してください。ダイアログにはタブが付きません。
- **アップグレード後に挙動がおかしい？** **設定 → サポート → 既定値に戻す**
  （元の設定は先にバックアップされます）。
- **管理者として実行すべき？** 不要で、おすすめしません。Windows は管理者のウィンドウと通常のウィンドウの間で
  一部の入力を遮断しますし、通常のウィンドウのグループは **タスクバーのアイコンをまとめる** をオンにしても
  1 つずつタスクバーボタンを持ちます。理由はグループのタブメニューに出ます。
- **ファイルをタブへドロップしても何も起きない？** Windows は通常のアプリから管理者として実行中の
  アプリへのドラッグを遮断します。

それでも解決しない場合は [issue を立てて](https://github.com/tjsky/WindowTabs/issues)、
**設定 → サポート** のトラブルシューティング レポートを貼ってください。ウィンドウのタイトルとパスは含まれません。

## 開発

### ビルドと実行

WindowTabs は .NET Framework 4.8 上の F# WinForms アプリで、Win32 相互運用のための小さな C# プロジェクトを
伴います。Windows 10 または 11 でのビルド手順：

**1. ツールを入れる**

- [.NET 10.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)：Windows 用インストーラー（通常は **x64**）を選びます。
- [.NET Framework 4.8 Developer Pack](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48)：ランタイムだけではビルドできません。

**2. 取得してビルドし、実行する**

ソースを置きたいフォルダーで新しい **PowerShell** ウィンドウを開きます。

```bash
git clone https://github.com/tjsky/WindowTabs
cd WindowTabs
dotnet build WindowTabs.sln                 # Debug：WtProgram\bin\Debug\WindowTabs.exe
dotnet build WindowTabs.sln -c Release      # Release：WtProgram\bin\Release\WindowTabs.exe（単一 exe）
```

上流のリポジトリは [leafOfTree/WindowTabs](https://github.com/leafOfTree/WindowTabs) です。
`git remote add upstream` でここからそのコミットを追えます。

最初のビルドは NuGet の依存関係をダウンロードするため、インターネット接続が必要です。生成された exe を実行すると
WindowTabs が通知領域に入ります。ビルドし直す前に終了してください（実行中の exe が出力をロックします）。
`dotnet` が見つからない場合は、インストール後に PowerShell を開き直してください。

**または Visual Studio で**

[Visual Studio 2026](https://visualstudio.microsoft.com/downloads/) をインストールし、
**.NET デスクトップ開発** ワークロードを選んで、既定の推奨コンポーネントをそのまま入れます。
`WindowTabs.sln` を開き、`WtProgram` をスタートアップ プロジェクトに設定して **F5** を押します。

AI 支援による貢献を歓迎します。変更を理解し、テストしたうえで送ってください。
[AGENTS.md](AGENTS.md)、[アーキテクチャ](docs/architecture.md)、[テスト](docs/testing.md) も参照してください。

### コードを変える前に知っておくこと

- **スレッド：** タブのグループごとに専用の UI スレッドで動き、メイン スレッドが設定とウィンドウ検出を持ちます。
  スレッド間の呼び出しは `Shared/Services.fs` のアダプターを通ります。ここに触る前に
  [アーキテクチャ](docs/architecture.md) を読んでください。
- **UI の文字列：** 表示される文字列はすべて `Shared/Strings.fs` にあり、英語、簡体字中国語、繁体字中国語、
  日本語、アラビア語を持ちます。最初の下書きは機械翻訳で構いませんが、母語話者が磨けます。
  残りは [ローカライズ](docs/localization.md) にあります。
- **設定：** 名前、既定値、範囲は `Shared/SettingsCatalog.fs` に一度だけ宣言され、
  設定ウィンドウ、検索、リセットはすべてそこから読みます。
- **DPI とテーマ：** 論理ピクセルを使い `Dpi.scale` で拡大縮小します。ライト、ダーク、ハイコントラストの
  各モードで UI を確認してください。

## コード署名ポリシー

上流のリリースはコード署名されています。[SignPath.io](https://about.signpath.io) による無償の署名で、
証明書は [SignPath Foundation](https://signpath.org)、承認は上流のメンテナー
[@leafOfTree](https://github.com/leafOfTree)、コミッターとレビュアーは上流の
[コントリビューター](https://github.com/leafOfTree/WindowTabs/graphs/contributors) に記載されています。

このフォークは独自の SignPath プロジェクトを持たないため、ここで公開している `WindowTabs.exe` は
GitHub Actions がビルドした**未署名**のもので、Windows が実行前に確認を求めることがあります。
署名済みのものが必要なら [上流の releases](https://github.com/leafOfTree/WindowTabs/releases) から
入手してください。

配布用のバイナリは GitHub Actions がソースからビルドしています。開発には AI コーディング エージェントが
参加しますが、すべての変更は人間のメンテナーがレビューしてマージします。

### プライバシー ポリシー

利用者、または本プログラムをインストール・操作する人が明示的に求めない限り、
本プログラムはネットワーク上の他のシステムへ情報を送信しません。

## クレジットとライセンス

2009 年に Maurice Flanagan が作成（[mauricef/WindowTabs](https://github.com/mauricef/WindowTabs)）、
[redgis](https://github.com/redgis/WindowTabs) と
[payaneco](https://github.com/payaneco/WindowTabs) が続け、
[leafOfTree](https://github.com/leafOfTree/WindowTabs) が現在の姿に育てました。このフォークはそこから取ったものです。

[MIT ライセンス](LICENSE)。元の著作権表示もそのまま残しています。
ここまでの土台を築いてきた上記のメンテナーに感謝します。
