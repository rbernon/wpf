// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Globalization;

namespace MS.Internal.Text.TextInterface {
  internal class ItemProps {
    internal CultureInfo DigitCulture { get; }
    internal bool IsLatin { get; }
    internal bool IsIndic { get; }
    internal bool HasCombiningMark { get; }
    internal bool HasExtendedCharacter { get; }
    internal bool NeedsCaretInfo { get; }
    internal bool CanShapeTogether(ItemProps other) { return false; }
  }
}
