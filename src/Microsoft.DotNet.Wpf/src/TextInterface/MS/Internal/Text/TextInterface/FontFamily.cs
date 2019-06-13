// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;

namespace MS.Internal.Text.TextInterface {
  public partial class FontFamily : List<Font> {
    public string OrdinalName { get; }
    public LocalizedStrings FamilyNames { get; }
    public FontMetrics Metrics { get; }

    extern public FontMetrics DisplayMetrics(float emSize, float pixelsPerDip);
    extern public Font GetFirstMatchingFont(FontWeight weight,
                                            FontStretch stretch,
                                            FontStyle style);
  }
}
