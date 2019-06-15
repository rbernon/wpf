// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;

namespace MS.Internal.Text.TextInterface {
  internal class FontFamily : List<Font> {
    internal string OrdinalName { get; }
    internal LocalizedStrings FamilyNames { get; }
    internal FontMetrics Metrics { get; }

    internal FontMetrics DisplayMetrics(float emSize, float pixelsPerDip) {
      return new FontMetrics();
    }
    internal Font GetFirstMatchingFont(FontWeight weight, FontStretch stretch,
                                       FontStyle style) {
      return new Font();
    }
  }
}
