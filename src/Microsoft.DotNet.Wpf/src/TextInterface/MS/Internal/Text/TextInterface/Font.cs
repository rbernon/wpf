// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace MS.Internal.Text.TextInterface {
  public enum FontStyle {}
  public enum FontStretch {}
  public enum FontWeight {}
  public enum FontSimulations {}

  public class Font {
    public FontMetrics Metrics { get; }
    public FontStyle Style { get; }
    public FontStretch Stretch { get; }
    public LocalizedStrings FaceNames { get; }
    public FontWeight Weight { get; }
    public FontSimulations SimulationFlags { get; }
    public IntPtr DWriteFontAddRef { get; }

    public bool IsSymbolFont { get; }
    public double Version { get; }
    extern public FontFace GetFontFace();
    extern public bool HasCharacter(uint unicodeValue);
    extern public static void ResetFontFaceCache();
    extern public bool
    GetInformationalStrings(InformationalStringID informationalStringID,
                            out LocalizedStrings informationalStrings);
  }
}
