// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Globalization;
using System.Windows.Media;

namespace MS.Internal.Text.TextInterface {
  // The 4 delegates below are used to introduce a level of indirection so we
  // can define the external methods that reference PresentationNative*.dll in
  // PresenationCore.dll. The reason we define the methods in
  // PresentationCore.dll is that the string values for the current release
  // version suffix and the dll name of PresentationNative are defined in
  // managed code. Hence we wanted to avoid redefining these values in MC++ so
  // as not to increase the maintenance cost of the code. Moreover, using
  // delegates does not impact perf to justify not using it in this case.
  /// <SecurityNote>
  /// Critical    - receives native pointers as parameters.
  /// </SecurityNote>
  internal unsafe delegate int CreateTextAnalysisSource(
      char *text, uint length, char *culture, void *factory, bool isRightToLeft,
      char *numberCulture, bool ignoreUserOverride,
      uint numberSubstitutionMethod, void **ppTextAnalysisSource);

  /// <SecurityNote>
  /// Critical    - Returns a native pointer.
  /// </SecurityNote>
  internal unsafe delegate void *CreateTextAnalysisSink();

  /// <SecurityNote>
  /// Critical    - receives as parameters and returns native pointers .
  /// </SecurityNote>
  internal unsafe delegate void *GetScriptAnalysisList(void *param);

  /// <SecurityNote>
  /// Critical    - receives as parameters and returns native pointers .
  /// </SecurityNote>
  internal unsafe delegate void *GetNumberSubstitutionList(void *param);

  internal class TextAnalyzer {
    internal const char CharHyphen = '\x002d';

    unsafe internal static IList<Span>
    Itemize(char *text, uint length, CultureInfo culture, Factory factory,
            bool isRightToLeftParagraph, CultureInfo numberCulture,
            bool ignoreUserOverride, uint numberSubstitutionMethod,
            IClassification classificationUtility,
            CreateTextAnalysisSink pfnCreateTextAnalysisSink,
            GetScriptAnalysisList pfnGetScriptAnalysisList,
            GetNumberSubstitutionList pfnGetNumberSubstitutionList,
            CreateTextAnalysisSource pfnCreateTextAnalysisSource) {
      return new List<Span>{};
    }

    unsafe internal void
    GetGlyphs(char *textString, uint textLength, Font font,
              ushort blankGlyphIndex, bool isSideways, bool isRightToLeft,
              CultureInfo cultureInfo, DWriteFontFeature[][] features,
              uint[] featureRangeLengths, uint maxGlyphCount,
              TextFormattingMode textFormattingMode, ItemProps itemProps,
              ushort *clusterMap, ushort *textProps, ushort *glyphIndices,
              uint *glyphProps, int *pfCanGlyphAlone,
              out uint actualGlyphCount) {
      actualGlyphCount = 0;
    }

    unsafe internal void GetGlyphsAndTheirPlacements(
        char *textString, uint textLength, Font font, ushort blankGlyphIndex,
        bool isSideways, bool isRightToLeft, CultureInfo cultureInfo,
        DWriteFontFeature[][] features, uint[] featureRangeLengths,
        double fontEmSize, double scalingFactor, float pixelsPerDip,
        TextFormattingMode textFormattingMode, ItemProps itemProps,
        out ushort[] clusterMap, out ushort[] glyphIndices,
        out int[] glyphAdvances, out GlyphOffset[] glyphOffsets) {
      clusterMap = new ushort[0];
      glyphIndices = new ushort[0];
      glyphAdvances = new int[0];
      glyphOffsets = new GlyphOffset[0];
    }

    unsafe internal void GetGlyphPlacements(
        char *textString, ushort *clusterMap, ushort *textProps,
        uint textLength, ushort *glyphIndices, uint *glyphProps,
        uint glyphCount, Font font, double fontEmSize, double scalingFactor,
        bool isSideways, bool isRightToLeft, CultureInfo cultureInfo,
        DWriteFontFeature[][] features, uint[] featureRangeLengths,
        TextFormattingMode textFormattingMode, ItemProps itemProps,
        float pixelsPerDip, int *glyphAdvances,
        out GlyphOffset[] glyphOffsets) {
      glyphOffsets = new GlyphOffset[0];
    }
  }
}
