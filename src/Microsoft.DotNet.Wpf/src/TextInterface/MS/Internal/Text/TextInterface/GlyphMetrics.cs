// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace MS.Internal.Text.TextInterface {
  /// <summary>
  /// Specifies the metrics of an individual glyph.
  /// The units depend on how the metrics are obtained.
  ///
  /// COMPATIBILITY WARNING: The layout of this struct must match exactly the
  /// layout of DWRITE_GLYPH_METRICS from DWrite.h We will perform an unsafe
  /// cast from this type to DWRITE_GLYPH_METRICS when obtaining glyph metrics.
  /// We do this for speed because we have to be able to obtain GlyphMetrics
  /// quickly, and the heap allocations and copy time were causing severe
  /// performance degradations.
  ///
  /// </summary>
  public struct GlyphMetrics {
#if USE_CAIRO
    private Cairo.TextExtents cairo;

    public GlyphMetrics(Cairo.TextExtents c) { cairo = c; }

    /// <summary>
    /// Specifies the X offset from the glyph origin to the left edge of the
    /// black box. The glyph origin is the current horizontal writing position.
    /// A negative value means the black box extends to the left of the origin
    /// (often true for lowercase italic 'f').
    /// </summary>
    public int LeftSideBearing {
      get { return Convert.ToInt32(cairo.XBearing); }
    }

    /// <summary>
    /// Specifies the X offset from the origin of the current glyph to the
    /// origin of the next glyph when writing horizontally.
    /// </summary>
    public uint AdvanceWidth {
      get { return Convert.ToUInt32(cairo.XAdvance); }
    }

    /// <summary>
    /// Specifies the X offset from the right edge of the black box to the
    /// origin of the next glyph when writing horizontally. The value is
    /// negative when the right edge of the black box overhangs the layout box.
    /// </summary>
    public int RightSideBearing {
      get {
        return Convert.ToInt32(cairo.XAdvance - cairo.XBearing - cairo.Width);
      }
    }

    /// <summary>
    /// Specifies the vertical offset from the vertical origin to the top of the
    /// black box. Thus, a positive value adds whitespace whereas a negative
    /// value means the glyph overhangs the top of the layout box.
    /// </summary>
    public int TopSideBearing {
      get { return Convert.ToInt32(cairo.YBearing); }
    }

    /// <summary>
    /// Specifies the Y offset from the vertical origin of the current glyph to
    /// the vertical origin of the next glyph when writing vertically. (Note
    /// that the term "origin" by itself denotes the horizontal origin. The
    /// vertical origin is different. Its Y coordinate is specified by
    /// verticalOriginY value, and its X coordinate is half the advanceWidth to
    /// the right of the horizontal origin).
    /// </summary>
    public uint AdvanceHeight {
      get { return Convert.ToUInt32(cairo.YAdvance); }
    }

    /// <summary>
    /// Specifies the vertical distance from the black box's bottom edge to the
    /// advance height. Positive when the bottom edge of the black box is within
    /// the layout box. Negative when the bottom edge of black box overhangs the
    /// layout box.
    /// </summary>
    public int BottomSideBearing {
      get {
        return Convert.ToInt32(cairo.YAdvance - cairo.YBearing - cairo.Height);
      }
    }

    /// <summary>
    /// Specifies the Y coordinate of a glyph's vertical origin, in the font's
    /// design coordinate system. The y coordinate of a glyph's vertical origin
    /// is the sum of the glyph's top side bearing and the top (i.e. yMax) of
    /// the glyph's bounding box.
    /// </summary>
    // public int VerticalOriginY {
    //     get { return 0; }
    // }
#else
    public int LeftSideBearing { get; }
    public int RightSideBearing { get; }
    public int TopSideBearing { get; }
    public int BottomSideBearing { get; }
    public uint AdvanceWidth { get; }
    public uint AdvanceHeight { get; }
    public int VerticalOriginY { get; }
#endif
  }
}
