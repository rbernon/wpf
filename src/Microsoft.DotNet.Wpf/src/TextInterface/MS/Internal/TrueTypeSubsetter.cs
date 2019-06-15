// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace MS.Internal {
  internal class TrueTypeSubsetter {
    unsafe internal static byte[] ComputeSubset(void *fontData, int fileSize,
                                                System.Uri sourceUri,
                                                int directoryOffset,
                                                ushort[] glyphArray) {
      return new byte[0];
    }
  }
}
