# Languages

Every user-visible text is a `LocalizedText` in `WtProgram/Shared/Strings.fs` and is shown with
`tr`. All text is compiled into the one `WindowTabs.exe`: satellite resource assemblies cannot be
statically linked, so a `.resx` translation would not ship (`Shared/Localization.fs` says the same
where the type is declared).

## The texts

```fsharp
type LocalizedText = { en:string; zh:string; zhHant:string; ja:string; ar:string }
```

Every field is required, so a text added without its translations does not compile. `zh` is
Simplified Chinese and `zhHant` Traditional; the two are written differently even where they read
the same (`保存` and `儲存`, `窗口` and `視窗`), so they are separate translations rather than one
converted from the other. `tests/Architecture.fsx` also checks that no text is written in some
languages and left empty in others.

`Localization.all` lists a text in the languages the build ships complete, and the settings search
matches a typed word against all of them, so `设定` and `設定` both find the same setting.

## The setting

| Value | Language |
| --- | --- |
| `system` | Follows the Windows display language |
| `en` | English |
| `zh` | 简体中文 |
| `zh-Hant` | 繁體中文 |
| `ja` | 日本語 |
| `ar` | العربية |

`system` is resolved by `Localization.ofCulture`, which reads the region as well as the language:
`zh-TW`, `zh-HK`, `zh-MO` and any `…Hant…` tag ask for Traditional, every other `zh` for
Simplified, and anything the app does not write falls back to English. A language names itself in
the picker (`Localization.languages`), so the list stays readable whichever one is selected.

Arabic is the only right-to-left language; `tr` wraps it in a right-to-left embedding so a Latin
word inside a sentence does not reorder it. Chinese, in either writing system, is left to right and
is not wrapped.

## Adding a language

1. Add the code, its own name and a one-character label to `Localization.languages`, and the field
   to `LocalizedText`.
2. Add the field to `plain`, `tr` and `all` in `Shared/Localization.fs`; `all` is what the search
   and the completeness check read.
3. Add the field to every text in `Strings.fs`. `tools/add-language.fsx <code>` writes it as empty
   after `en` in all of them:

   ```powershell
   dotnet fsi tools/add-language.fsx fr
   ```

4. Fill the texts. An empty field shows the English text, so the app works as soon as the field
   exists and reads better with every translation added.
5. Add the language to the loop in `tests/Reliability.fsx` and its name to `localization.md` above.

Texts with values filled in are functions (`unableToSaveSettings path details`), so a format is
written once per language rather than assembled from translated pieces.
