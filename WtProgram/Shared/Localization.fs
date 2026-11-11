namespace Bemo
open System.Globalization

/// One piece of user-visible text in every supported language. Every field is required, so a
/// missing translation is a compile error. All instances live in Strings.
/// `zh` is Simplified Chinese and `zhHant` Traditional, the two writing systems the app is used in.
type LocalizedText = { en:string; zh:string; zhHant:string; ja:string; ar:string }

/// All user-visible text is compiled into the single WindowTabs.exe. (Satellite resource
/// assemblies cannot be statically linked, so a .resx translation would not ship.)
module Localization =
    /// Supported languages: the code saved in the settings file, the name each language calls
    /// itself by, and the compact label the sidebar shows. A language names itself so the list
    /// stays readable whichever one is selected. See docs/localization.md to add one.
    let languages = [| "en","English","EN"; "zh","简体中文","简"; "zh-Hant","繁體中文","繁"; "ja","日本語","日"; "ar","العربية","ع" |]
    /// Values of the language setting: "system" follows the Windows display language.
    let preferences = "system" :: [for code,_,_ in languages -> code]
    let mutable private preference = "system"
    let setPreference (value:string) = preference <- value

    /// The language a Windows display language asks for. Simplified and Traditional Chinese are
    /// told apart by the region as well as the script tag: zh-TW, zh-HK and zh-MO write Traditional.
    let ofCulture (culture:CultureInfo) =
        let name = if culture.Name = "" then culture.TwoLetterISOLanguageName else culture.Name
        let zh = name.StartsWith("zh",System.StringComparison.OrdinalIgnoreCase)
        if zh then
            let traditional =
                name.EndsWith("Hant",System.StringComparison.OrdinalIgnoreCase)
                || ["TW";"HK";"MO"] |> List.exists (fun region -> name.EndsWith(region,System.StringComparison.OrdinalIgnoreCase))
            if traditional then "zh-Hant" else "zh"
        else
            match culture.TwoLetterISOLanguageName.ToLowerInvariant() with
            | ("ja" | "ar" | "en") as code -> code
            | _ -> "en"

    /// The language text is shown in; any unsupported language falls back to English.
    let current() =
        let code = if preference="system" then ofCulture CultureInfo.CurrentUICulture else preference
        if languages |> Array.exists (fun (c,_,_) -> c=code) then code else "en"

    /// The text in the current language as written, for values that are parsed or saved. A text
    /// left untranslated in the current language is shown in English rather than as a gap.
    let plain (text:LocalizedText) =
        let written =
            match current() with
            | "zh" -> text.zh
            | "zh-Hant" -> text.zhHant
            | "ja" -> text.ja
            | "ar" -> text.ar
            | _ -> text.en
        if written="" then text.en else written

    /// GDI and the standard controls read text left to right unless told otherwise, which puts the
    /// words of an Arabic sentence around a Latin word, and its final full stop, in the wrong order.
    /// A right-to-left embedding keeps each text in reading order without mirroring the layout.
    let tr (text:LocalizedText) =
        let value = plain text
        if current()="ar" && value<>"" then "\u202B"+value+"\u202C" else value

    /// Every translation of a text, for search: the languages this build ships complete.
    let all (text:LocalizedText) = [text.en; text.zh; text.zhHant; text.ja; text.ar]

[<AutoOpen>]
module LocalizationOperators =
    /// The text in the current language.
    let tr text = Localization.tr text
