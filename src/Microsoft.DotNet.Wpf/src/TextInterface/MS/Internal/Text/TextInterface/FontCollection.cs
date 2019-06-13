// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace MS.Internal.Text.TextInterface {
  public partial class FontCollection {
    public uint FamilyCount { get; }
    extern public FontFamily this[uint familyIndex] { get; }
    extern public FontFamily this[string familyName] { get; }
    extern public Font GetFontFromFontFace(FontFace fontFace);
  }
}
