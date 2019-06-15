// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace MS.Internal {
  internal class Span {
    internal Span(Object element, int length) {
      this.element = element;
      this.length = length;
    }
    internal Object element;
    internal int length;
  }
}
