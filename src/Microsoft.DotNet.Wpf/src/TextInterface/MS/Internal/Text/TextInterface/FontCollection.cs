// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace MS.Internal.Text.TextInterface {
  internal class FontCollection {
    internal uint FamilyCount { get; }
    internal FontFamily this[uint familyIndex] {
      get { return new FontFamily(); }
    }
    internal FontFamily this[string familyName] {
      get { return new FontFamily(); }
    }
    internal Font GetFontFromFontFace(FontFace fontFace) { return new Font(); }
  }
}
