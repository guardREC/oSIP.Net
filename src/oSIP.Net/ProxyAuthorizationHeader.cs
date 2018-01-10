﻿namespace oSIP.Net
{
    public class ProxyAuthorizationHeader : AuthorizationHeaderBase
    {
        public ProxyAuthorizationHeader()
        {
        }

        internal unsafe ProxyAuthorizationHeader(osip_authorization_t* native, bool isOwner)
            :
            base(native, isOwner)
        {
        }

        public static ProxyAuthorizationHeader Parse(string str)
        {
            return Parse<ProxyAuthorizationHeader>(str);
        }

        public unsafe ProxyAuthorizationHeader DeepClone()
        {
            return DeepClone(ptr =>
            {
                var native = (osip_authorization_t*) ptr.ToPointer();
                return new ProxyAuthorizationHeader(native, true);
            });
        }
    }
}