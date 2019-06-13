// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace MS.Internal.Text.TextInterface {
  public enum FactoryType { Shared }
  public partial class Factory {
    public extern static Factory
    Create(FactoryType factoryType,
           IFontSourceCollectionFactory fontSourceCollectionFactory,
           IFontSourceFactory fontSourceFactory);
    public extern FontCollection GetFontCollection(System.Uri uri);
    public extern FontCollection GetSystemFontCollection();
    public static bool IsLocalUri(System.Uri uri) {
      return (uri.IsFile && uri.IsLoopback && !uri.IsUnc);
    }
    public extern TextAnalyzer CreateTextAnalyzer();
    public extern FontFace CreateFontFace(System.Uri filePathUri,
                                          uint faceIndex,
                                          FontSimulations fontSimulationFlags);
  }
}
