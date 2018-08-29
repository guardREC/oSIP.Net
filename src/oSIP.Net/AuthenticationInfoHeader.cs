﻿namespace oSIP.Net
{
    public class AuthenticationInfoHeader : AuthenticationInfoHeaderBase
    {
        public AuthenticationInfoHeader()
        {
        }

        internal unsafe AuthenticationInfoHeader(osip_authentication_info_t* native, bool isOwner)
            :
            base(native, isOwner)
        {
        }

        public static AuthenticationInfoHeader Parse(string str)
        {
            return Parse<AuthenticationInfoHeader>(str);
        }

        public static bool TryParse(string str, out AuthenticationInfoHeader header)
        {
            return TryParse<AuthenticationInfoHeader>(str, out header);
        }

        public unsafe AuthenticationInfoHeader DeepClone()
        {
            return DeepClone(ptr =>
            {
                var native = (osip_authentication_info_t*) ptr.ToPointer();
                return new AuthenticationInfoHeader(native, true);
            });
        }
    }
}