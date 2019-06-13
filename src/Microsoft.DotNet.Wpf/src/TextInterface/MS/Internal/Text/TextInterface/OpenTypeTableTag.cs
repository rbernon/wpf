// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace MS.Internal.Text.TextInterface {
  public enum OpenTypeTableTag {
    CharToIndexMap,     /* 'cmap' */
    ControlValue,       /* 'cvt ' */
    BitmapData,         /* 'EBDT' */
    BitmapLocation,     /* 'EBLC' */
    BitmapScale,        /* 'EBSC' */
    Editor0,            /* 'edt0' */
    Editor1,            /* 'edt1' */
    Encryption,         /* 'cryp' */
    FontHeader,         /* 'head' */
    FontProgram,        /* 'fpgm' */
    GridfitAndScanProc, /* 'gasp' */
    GlyphDirectory,     /* 'gdir' */
    GlyphData,          /* 'glyf' */
    HoriDeviceMetrics,  /* 'hdmx' */
    HoriHeader,         /* 'hhea' */
    HorizontalMetrics,  /* 'hmtx' */
    IndexToLoc,         /* 'loca' */
    Kerning,            /* 'kern' */
    LinearThreshold,    /* 'LTSH' */
    MaxProfile,         /* 'maxp' */
    NamingTable,        /* 'name' */
    OS_2,               /* 'OS/2' */
    Postscript,         /* 'post' */
    PreProgram,         /* 'prep' */
    VertDeviceMetrics,  /* 'VDMX' */
    VertHeader,         /* 'vhea' */
    VerticalMetrics,    /* 'vmtx' */
    PCLT,               /* 'PCLT' */
    TTO_GSUB,           /* 'GSUB' */
    TTO_GPOS,           /* 'GPOS' */
    TTO_GDEF,           /* 'GDEF' */
    TTO_BASE,           /* 'BASE' */
    TTO_JSTF,           /* 'JSTF' */
  }
}
