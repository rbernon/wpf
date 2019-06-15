// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace MS.Internal.Text.TextInterface {
  internal enum FontStyle {}
  internal enum FontStretch {}
  internal enum FontWeight {}
  internal enum FontSimulations {}

  internal class Font {
    internal FontMetrics Metrics { get; }
    internal FontStyle Style { get; }
    internal FontStretch Stretch { get; }
    internal LocalizedStrings FaceNames { get; }
    internal FontWeight Weight { get; }
    internal FontSimulations SimulationFlags { get; }
    internal IntPtr DWriteFontAddRef { get; }

    internal bool IsSymbolFont { get; }
    internal double Version { get; }
    internal FontFace GetFontFace() { return new FontFace(); }
    internal bool HasCharacter(uint unicodeValue) { return false; }
    internal static void ResetFontFaceCache() {}
    internal bool
    GetInformationalStrings(InformationalStringID informationalStringID,
                            out LocalizedStrings informationalStrings) {
      informationalStrings = new LocalizedStrings();
      return false;
    }
  }
}
