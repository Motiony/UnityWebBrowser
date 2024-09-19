﻿// UnityWebBrowser (UWB)
// Copyright (c) 2021-2024 Voltstro-Studios
// 
// This project is under the MIT license. See the LICENSE.md file for more details.

using System;
using UnityWebBrowser.Engine.Cef.Shared.Browser;
using UnityWebBrowser.Engine.Cef.Shared.Core;
using VoltstroStudios.UnityWebBrowser.Engine.Shared.Core;
using Xilium.CefGlue;

namespace UnityWebBrowser.Engine.Cef.SubProcess;

public static class Program
{
    public static int Main(string[] args)
    {
#if MACOS
        var sandboxContext = CefSandbox.cef_sandbox_initialize(args.Length, args);
        CefMacOsFrameworkLoader.AddFrameworkLoader();
#endif
        
        //Setup CEF
        CefRuntime.Load();

        LaunchArgumentsParser argumentsParser = new();
        int subProcessExitCode = 0;
        argumentsParser.Run(args, launchArguments =>
        {
// ReSharper disable once RedundantAssignment
            string[] argv = args;
#if LINUX || MACOS
            //On Linux we need to do this, otherwise it will just crash, no idea why tho
            argv = new string[args.Length + 1];
            Array.Copy(args, 0, argv, 1, args.Length);
            argv[0] = "-";
#endif

            //Set up CEF args and the CEF app
            CefMainArgs cefMainArgs = new CefMainArgs(argv);
            UwbCefApp cefApp = new UwbCefApp(launchArguments);

            //Run our sub-processes
            subProcessExitCode = CefRuntime.ExecuteProcess(cefMainArgs, cefApp, IntPtr.Zero);
        });

#if MACOS
        CefSandbox.cef_sandbox_destroy(sandboxContext);
#endif

        return subProcessExitCode;
    }
}