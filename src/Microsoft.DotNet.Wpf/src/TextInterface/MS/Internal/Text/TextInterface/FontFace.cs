// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace MS.Internal.Text.TextInterface {
#if USE_CAIRO
  using FontFaceType = Cairo.FontType;
#else
  internal enum FontFaceType {
    TrueTypeCollection,
    CFF,
  }
#endif

  /// <summary>
  /// An absolute reference to a font face.
  /// It contains font face type, appropriate file references and face
  /// identification data. Various font data such as metrics, names and glyph
  /// outlines is obtained from FontFace.
  /// </summary>
  internal class FontFace : IDisposable {
#if USE_CAIRO
    private Cairo.ScaledFont cairo;

    internal FontFace(Cairo.ScaledFont c) { cairo = c; }

    /// <summary>
    /// Gets the file format type of a font face.
    /// </summary>
    internal FontFaceType Type {
      get { return cairo.FontType; }
    }

    /// <summary>
    /// Gets design units and common metrics for the font face.
    /// These metrics are applicable to all the glyphs within a fontface and are
    /// used by applications for layout calculations.
    /// </summary>
    internal FontMetrics Metrics {
      get { return new FontMetrics(cairo.FontExtents); }
    }

    /// <summary>
    /// Gets the number of glyphs in the font face.
    /// </summary>
    // internal ushort GlyphCount
    // {
    //     get;
    // }

    /// <summary>
    /// Gets the first font file representing the font face.
    /// </summary>
    // FontFile GetFileZero;

    /// <summary>
    /// Increments the reference count on this FontFace.
    /// </summary>
    // void AddRef()
    // {
    //     System.Threading.Interlocked.Increment(_refCount);
    // }

    /// <summary>
    /// Decrements the reference count on this FontFace.
    /// </summary>
    // void Release()
    // {
    //     if (-1 == System.Threading.Interlocked.Decrement(_refCount))
    //     {
    //         // At this point we know the FontFace is eligable for the
    //         finalizer queue.
    //         // However, because native dwrite font faces consume enormous
    //         amounts of
    //         // address space, we need to be aggressive about disposing
    //         immediately.
    //         // If we rely solely on the GC finalizer, we will exhaust
    //         available address
    //         // space in reasonable scenarios like enumerating all installed
    //         fonts. delete this;
    //     }
    // }

    /// <summary>
    /// Obtains ideal glyph metrics in font design units. Design glyphs metrics
    /// are used for glyph positioning.
    /// </summary>
    /// <param name="glyphIndices">An array of glyph indices to compute the
    /// metrics for.</param> <param name="pGlyphMetrics">Unsafe pointer to flat
    /// array of GlyphMetrics structs for output. Passed as unsafe to allow
    /// optimization by the caller of stack or heap allocation. The metrics
    /// returned are in font design units</param>
    // [SecurityCritical]
    // void GetDesignGlyphMetrics(
    //     __in_ecount(glyphCount) const ushort *pGlyphIndices,
    //     uint glyphCount,
    //     __out_ecount(glyphCount) GlyphMetrics *pGlyphMetrics
    //     );

    // [SecurityCritical]
    // void GetDisplayGlyphMetrics(
    //     __in_ecount(glyphCount) const ushort *pGlyphIndices,
    //     uint glyphCount,
    //     __out_ecount(glyphCount) GlyphMetrics *pGlyphMetrics,
    //     FLOAT emSize,
    //     bool useDisplayNatural,
    //     bool isSideways,
    //     float pixelsPerDip
    //     );

    /// <summary>
    /// Returns the nominal mapping of UCS4 Unicode code points to glyph indices
    /// as defined by the font 'CMAP' table. Note that this mapping is primarily
    /// provided for line layout engines built on top of the physical font API.
    /// Because of OpenType glyph substitution and line layout character
    /// substitution, the nominal conversion does not always correspond to how a
    /// Unicode string will map to glyph indices when rendering using a
    /// particular font face. Also, note that Unicode Variant Selectors provide
    /// for alternate mappings for character to glyph. This call will always
    /// return the default variant.
    /// </summary>
    /// <param name="codePoints">An array of USC4 code points to obtain nominal
    /// glyph indices from.</param> <returns>Array of nominal glyph indices
    /// filled by this function.</returns>
    // "GetGlyphIndices" is defined in WinGDI.h to be "GetGlyphIndicesW" that
    // why we chose "GetArrayOfGlyphIndices" [SecurityCritical] void
    // GetArrayOfGlyphIndices(
    //     __in_ecount(glyphCount) const uint* pCodePoints,
    //     uint glyphCount,
    //     __out_ecount(glyphCount) ushort* pGlyphIndices
    //     );

    /// <summary>
    /// Finds the specified OpenType font table if it exists and returns a
    /// pointer to it.
    /// </summary>
    /// <param name="openTypeTableTag">The tag of table to find.</param>
    /// <param name="tableData">The table.</param>
    /// <returns>True if table exists.</returns>
    // [SecurityCritical]
    // bool TryGetFontTable(
    //                                                             OpenTypeTableTag
    //                                                             openTypeTableTag,
    //                     [System.Runtime.InteropServices.Out] array<byte>^%
    //                     tableData
    //                     );

    /// <summary>
    /// Reads the FontEmbeddingRights
    /// </summary>
    /// <param name="tableData">The font embedding rights value.</param>
    /// <returns>True if os2 table exists and the FontEmbeddingRights was read
    /// successfully.</returns>
    // bool ReadFontEmbeddingRights([System.Runtime.InteropServices.Out]
    // ushort% fsType);

    /// <summary>
    /// dtor.
    /// </summary>
    // [SecuritySafeCritical]
    // ~FontFace;
#else
    internal FontFaceType Type { get; }
    internal ushort GlyphCount { get; }
    internal IntPtr DWriteFontFaceAddRef { get; }
    internal uint Index { get; }

    internal FontFile GetFileZero() { return new FontFile(); }
    internal void Release() {}
    internal bool ReadFontEmbeddingRights(out ushort fsType) {
      fsType = 0;
      return false;
    }
    internal bool TryGetFontTable(OpenTypeTableTag openTypeTableTag,
                                  out byte[] tableData) {
      tableData = new byte[0];
      return false;
    }
    unsafe internal void GetArrayOfGlyphIndices(uint *pCodePoints,
                                                uint glyphCount,
                                                ushort *pGlyphIndices) {}
    unsafe internal void GetDesignGlyphMetrics(ushort *pGlyphIndices,
                                               uint glyphCount,
                                               GlyphMetrics *pGlyphMetrics) {}
    unsafe internal void
    GetDisplayGlyphMetrics(ushort *pGlyphIndices, uint glyphCount,
                           GlyphMetrics *pGlyphMetrics, float emSize,
                           bool useDisplayNatural, bool isSideways,
                           float pixelsPerDip) {}
#endif
    public void Dispose() {}
  }
}
