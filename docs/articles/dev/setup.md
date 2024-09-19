# Setup

Ok, lets setup UWB's development environment.

## Prerequisites

These prerequisites are **mandatory** to compile UWB.

```
Unity 2021.3.x
.NET 8 SDK (With NativeAOT)
Python 3
Git
```

UWB compiles engines using .NET's [NativeAOT deployment mode](https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/). NativeAOT it self has some prerequisites, please [see the docs for what you will need](https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/?tabs=net8plus%2Cwindows#prerequisites).

### Additional Optional Prerequisites

These prerequisites are not required, but some areas may require them.

```
NodeJS
Yarn
```

## Repo Setup

We first need to obtain UWB's code. UWB is all contained in one-mono repo, found at `https://github.com/Voltstro-Studios/UnityWebBrowser.git`.

To get the [`UnityWebBrowser`](https://github.com/Voltstro-Studios/UnityWebBrowser) repo, you first need to clone the repo recursively using Git, like so:

```shell
git clone --recursive https://github.com/Voltstro-Studios/UnityWebBrowser.git
```

> [!NOTE]
> If you did NOT clone the repo recursively, you can just init the submodules by running these commands at the root of the repo:
> 
> ```shell
> git submodule init
> git submodule update
> ```

Once you have the repo cloned with submodules, you can run the inital setup script.

```
python src/DevScripts/setup_all.py
```

> [!NOTE]
> On some platforms, you may need to run python using `python3` instead of just `python`.

Depending on your system, and your download speeds, this script could take upto a minute or even longer. You only need to run the setup script once.

You can now open up the `src/UnityWebBrowser.UnityProject` project with Unity.

## Editor Tools

Once in Unity, you can open the provided `UWB` scene provided in the project. By default, this scene is setup to have basic browser controls/window.

When running the project in this scene, a provided 'UWB Debug UI' will be available.

> [!NOTE]
> By default this is "hidden", you can open the UI via the small panel at the top of the player's window.
> ![Panel](~/assets/images/articles/dev/setup/panel.webp)

The 'UWB Debug UI' provided has some useful stats and controls that you may want to use.

![Debug UI](~/assets/images/articles/dev/setup/debug-ui.webp)

If you need to, extra controls can be added by modifying the `Assets/Scripts/UWBPrjDebugUI.cs` script.

(In the future we hope to develop more editor tools to make life easier.)

## Core/Unity Packages Dev Work

Open Unity's C# project with your preferred IDE. You should be able to edit UWB's packages from the same solution that Unity generates. Remember that UWB's packages are located in `src/Packages/`.

## Engine/Shared Project Dev Work

You can open `src/UnityWebBrowser.sln` with your preferred IDE. The rest of the external projects are contained within this solution, including the shared project and engine projects.

## Dev Scripts

There are many DevScripts which you may need to use. For details on what dev scripts does what, see [Dev Scripts](dev-scripts.md).
