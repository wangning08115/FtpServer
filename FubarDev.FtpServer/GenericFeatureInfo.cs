﻿// <copyright file="GenericFeatureInfo.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

using JetBrains.Annotations;

namespace FubarDev.FtpServer
{
    public class GenericFeatureInfo : IFeatureInfo
    {
        private readonly Func<FtpConnection, string> _toString;

        private readonly string _name;

        public GenericFeatureInfo([NotNull] string name, [NotNull, ItemNotNull] params string[] additionalNames)
            : this(name, null, additionalNames)
        {
        }

        public GenericFeatureInfo([NotNull] string name, [CanBeNull] Func<FtpConnection, string> toString, [NotNull, ItemNotNull] params string[] additionalNames)
        {
            _name = name;
            var names = new HashSet<string> { name };
            foreach (var additionalName in additionalNames)
                names.Add(additionalName);
            Names = names;
            _toString = toString;
        }

        /// <inheritdoc/>
        public ISet<string> Names { get; }

        /// <inheritdoc/>
        public string BuildInfo(FtpConnection connection)
        {
            if (_toString == null)
                return _name;
            return _toString(connection);
        }
    }
}