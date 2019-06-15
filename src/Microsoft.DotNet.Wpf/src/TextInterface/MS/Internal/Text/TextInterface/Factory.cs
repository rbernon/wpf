// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace MS.Internal.Text.TextInterface {
  internal enum FactoryType { Shared }
  internal class Factory {
    internal static Factory
    Create(FactoryType factoryType,
           IFontSourceCollectionFactory fontSourceCollectionFactory,
           IFontSourceFactory fontSourceFactory) {
      return new Factory();
    }

    internal FontCollection GetFontCollection(System.Uri uri) {
      return new FontCollection();
    }

    internal FontCollection GetSystemFontCollection() {
      return new FontCollection();
    }

    internal static bool IsLocalUri(System.Uri uri) {
      return (uri.IsFile && uri.IsLoopback && !uri.IsUnc);
    }

    internal TextAnalyzer CreateTextAnalyzer() { return new TextAnalyzer(); }

    internal FontFace CreateFontFace(System.Uri filePathUri, uint faceIndex,
                                     FontSimulations fontSimulationFlags) {
      return new FontFace();
    }
  }
}
