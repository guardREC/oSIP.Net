﻿using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace oSIP.Net
{
    internal unsafe partial class NativeMethods
    {
        [DllImport("osipparser2")]
        public static extern ErrorCode osip_body_init(osip_body_t** body);

        [DllImport("osipparser2")]
        public static extern void osip_body_free(osip_body_t* body);

        [DllImport("osipparser2")]
        public static extern ErrorCode osip_body_parse(osip_body_t* body, IntPtr buf, ulong length);

        [DllImport("osipparser2")]
        public static extern ErrorCode osip_body_clone(osip_body_t* body, osip_body_t** dest);

        [DllImport("osipparser2")]
        public static extern ErrorCode osip_body_parse_mime(osip_body_t* body, IntPtr buf, ulong length);

        [DllImport("osipparser2")]
        public static extern ErrorCode osip_body_to_str(osip_body_t* body, IntPtr* dest, ulong* length);
    }

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct osip_body_t
    {
        public IntPtr body;
        public ulong length;
        public readonly osip_list_t* headers;
        public osip_content_type_t* content_type;
    }
}