﻿// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using Microsoft.DotNet.Cli.CommandLine;
using Microsoft.DotNet.Cli.Utils;
using System;
using System.IO;
using System.Linq;
using Microsoft.Build.Construction;
using Microsoft.DotNet.ProjectJsonMigration;
using NuGet.Frameworks;
using Microsoft.DotNet.Tools.Add.ProjectToProjectReference;

namespace Microsoft.DotNet.Tools.Add
{
    public class AddCommand : DispatchCommand
    {
        protected override string HelpText => $@"{LocalizableStrings.NetAddCommand}

{CommonLocalizableStrings.Usage}: dotnet add [options] <object> <command> <args>

Options:
  -h|--help  {CommonLocalizableStrings.HelpDefinition}

Arguments:
  <object>   {CommonLocalizableStrings.ArgumentsObjectDefinition}
  <command>  {CommonLocalizableStrings.ArgumentsCommandDefinition}

Args:
  {CommonLocalizableStrings.ArgsDefinition}

Commands:
  p2p        {LocalizableStrings.CommandP2PDefinition}";

        protected override Dictionary<string, Func<string, string[], int>> BuiltInCommands => 
            new Dictionary<string, Func<string, string[], int>>
        {
            ["p2p"] = AddProjectToProjectReferenceCommand.Run,
        };

        public static int Run(string[] args)
        {
            var cmd = new AddCommand();
            return cmd.Start(args);
        }
    }
}
