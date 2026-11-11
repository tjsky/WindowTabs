// Renders the classic trapezoid tabs to a PNG for a visual check against the
// screenshot they were restored from: an active tab and an inactive one behind
// it, laid out at the overlap the style gives itself. No assertions to make -
// the suites cover the settings round trip; this one is looked at, not run.
#r "System.Drawing"
#r "Debug/Win32.dll"
#r "Debug/WindowTabs.exe"
open System
open System.Drawing
open System.IO
open Bemo

let appearance =
    { Theme.light with
        tabStyle=ClassicTabs
        tabTextColor=Color.FromRGB(0x000000)
        tabNormalBgColor=Color.FromRGB(0x9FC4F0)
        tabHighlightBgColor=Color.FromRGB(0xBDD5F4)
        tabActiveBgColor=Color.FromRGB(0xFAFCFE)
        tabBorderColor=Color.FromRGB(0x3A70B1) }

let font = new Font("Segoe UI",9.0f)
let info text icon =
    { TabDisplayInfo.tint=None; colorStyle="Fill"; numberBadge=None; bgColor=None
      text=text; textFont=font; textBrush=(new SolidBrush(Color.Black):>Brush)
      icon=icon; splitTrail=None; isPinned=false; closeButton="ActiveAndHover" }

let height = TabMetrics.scaled appearance.tabHeight 25
let sprite isTop text icon width =
    { TabSprite.id=0; isTop=isTop; appearance=appearance; displayInfo=info text icon
      size=Sz(width,height); onlyIcon=false; dock=TabDockTop; direction=TabUp
      hover=None; captured=None; showLeftSeparator=false; roundLeft=false; roundRight=false } :> ISprite

let active = sprite true "This PC" SystemIcons.Application 210
let inactive = sprite false "File Explorer" SystemIcons.WinLogo 230
let overlap = TabMetrics.scaled appearance.tabHeight 20
let canvas = new Bitmap(210+230-overlap, height)
use g = Graphics.FromImage(canvas)
g.Clear(Color.FromRGB(0xF0F0F0))
g.DrawImage((inactive :> ISprite).image.bitmap, float32(210-overlap), 0.0f)
g.DrawImage((active :> ISprite).image.bitmap, 0.0f, 0.0f)

let path = Path.Combine(__SOURCE_DIRECTORY__,"..","_classic-render.png")
canvas.Save(path, Imaging.ImageFormat.Png)
printfn "CLASSIC_RENDER_OK %s" path
