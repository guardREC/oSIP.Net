﻿using System;
using System.Text;
using NUnit.Framework;

namespace oSIP.Net.Tests
{
    [TestFixture]
    public class SipRequestTests
    {
        [Test]
        public void Shall_stringify_request()
        {
            var request = new SipRequest
            {
                Version = "SIP/2.0",
                Method = "INVITE",
                RequestUri = SipUri.Parse("sip:john.smith@abc.com"),
                From = NameAddressHeader.Parse("John Smith <sip:john.smith@abc.com>"),
                To = NameAddressHeader.Parse("Joe Shmoe <sip:joe.shmoe@abc.com>"),
                CallId = CallIdHeader.Parse("1@foo.bar.com"),
                CSeq = CSeqHeader.Parse("1 INVITE"),
                ContentType = ContentTypeHeader.Parse("text/plain"),
                MimeVersion = ContentLengthHeader.Parse("1.0"),
            };
            request.Vias.Add(ViaHeader.Parse("SIP/2.0/UDP foo.bar.com"));
            request.RecordRoutes.Add(NameAddressHeader.Parse("Tommy Atkins <sip:tommy.atkins@abc.com>"));
            request.Routes.Add(NameAddressHeader.Parse("John Doe <sip:john.doe@abc.com>"));
            request.Contacts.Add(NameAddressHeader.Parse("Prisoner X <sip:prisoner.x@abc.com>"));
            request.Authorizations.Add(AuthorizationHeader.Parse("Digest username=\"Alice\""));
            request.WwwAuthenticates.Add(WwwAuthenticateHeader.Parse("Digest realm=\"abc.com\""));
            request.ProxyAuthenticates.Add(WwwAuthenticateHeader.Parse("Digest realm=\"xyz.com\""));
            request.ProxyAuthorizations.Add(AuthorizationHeader.Parse("Digest username=\"Bob\""));
            request.CallInfos.Add(CallInfoHeader.Parse("<http://www.abc.com/photo.png>;purpose=icon"));
            request.Allows.Add(ContentLengthHeader.Parse("INVITE, ACK, BYE"));
            request.ContentEncodings.Add(ContentLengthHeader.Parse("deflate"));
            request.AlertInfos.Add(CallInfoHeader.Parse("<http://www.abc.com/sound.wav>"));
            request.ErrorInfos.Add(CallInfoHeader.Parse("<sip:not-in-service@abc.com>"));
            request.Accepts.Add(ContentTypeHeader.Parse("application/sdp"));
            request.AcceptEncodings.Add(AcceptEncodingHeader.Parse("gzip"));
            request.AcceptLanguages.Add(AcceptEncodingHeader.Parse("en"));
            request.AuthenticationInfos.Add(AuthenticationInfoHeader.Parse("nextnonce=\"abc\""));
            request.ProxyAuthenticationInfos.Add(AuthenticationInfoHeader.Parse("nextnonce=\"def\""));
            request.OtherHeaders.Add(new GenericHeader("P-Asserted-Identity", "sip:alan.smithee@abc.com"));
            request.Bodies.Add(SipBody.Parse("Hello world!"));

            Assert.That(request.ToString(), Is.EqualTo(
                "INVITE sip:john.smith@abc.com SIP/2.0\r\n" +
                "Via: SIP/2.0/UDP foo.bar.com\r\n" +
                "Record-Route: Tommy Atkins <sip:tommy.atkins@abc.com>\r\n" +
                "Route: John Doe <sip:john.doe@abc.com>\r\n" +
                "From: John Smith <sip:john.smith@abc.com>\r\n" +
                "To: Joe Shmoe <sip:joe.shmoe@abc.com>\r\n" +
                "Call-ID: 1@foo.bar.com\r\n" +
                "CSeq: 1 INVITE\r\n" +
                "Contact: Prisoner X <sip:prisoner.x@abc.com>\r\n" +
                "Authorization: Digest username=\"Alice\"\r\n" +
                "WWW-Authenticate: Digest realm=\"abc.com\"\r\n" +
                "Proxy-Authenticate: Digest realm=\"xyz.com\"\r\n" +
                "Proxy-Authorization: Digest username=\"Bob\"\r\n" +
                "Call-Info: <http://www.abc.com/photo.png>;purpose=icon\r\n" +
                "Content-Type: text/plain\r\n" +
                "Mime-Version: 1.0\r\n" +
                "Allow: INVITE, ACK, BYE\r\n" +
                "Content-Encoding: deflate\r\n" +
                "Alert-Info: <http://www.abc.com/sound.wav>\r\n" +
                "Error-Info: <sip:not-in-service@abc.com>\r\n" +
                "Accept: application/sdp\r\n" +
                "Accept-Encoding: gzip\r\n" +
                "Accept-Language: en\r\n" +
                "Authentication-Info: nextnonce=\"abc\"\r\n" +
                "Proxy-Authentication-Info: nextnonce=\"def\"\r\n" +
                "P-Asserted-Identity: sip:alan.smithee@abc.com\r\n" +
                "Content-Length:    12\r\n" +
                "\r\n" +
                "Hello world!"));
        }

        [Test]
        public void Shall_byteify_request()
        {
            var request = new SipRequest
            {
                Version = "SIP/2.0",
                Method = "INVITE",
                RequestUri = SipUri.Parse("sip:john.smith@abc.com"),
                From = NameAddressHeader.Parse("John Smith <sip:john.smith@abc.com>"),
                To = NameAddressHeader.Parse("Joe Shmoe <sip:joe.shmoe@abc.com>"),
                CallId = CallIdHeader.Parse("1@foo.bar.com"),
                CSeq = CSeqHeader.Parse("1 INVITE"),
                ContentType = ContentTypeHeader.Parse("text/plain"),
                MimeVersion = ContentLengthHeader.Parse("1.0")
            };
            request.Vias.Add(ViaHeader.Parse("SIP/2.0/UDP foo.bar.com"));
            request.RecordRoutes.Add(NameAddressHeader.Parse("Tommy Atkins <sip:tommy.atkins@abc.com>"));
            request.Routes.Add(NameAddressHeader.Parse("John Doe <sip:john.doe@abc.com>"));
            request.Contacts.Add(NameAddressHeader.Parse("Prisoner X <sip:prisoner.x@abc.com>"));
            request.Authorizations.Add(AuthorizationHeader.Parse("Digest username=\"Alice\""));
            request.WwwAuthenticates.Add(WwwAuthenticateHeader.Parse("Digest realm=\"abc.com\""));
            request.ProxyAuthenticates.Add(WwwAuthenticateHeader.Parse("Digest realm=\"xyz.com\""));
            request.ProxyAuthorizations.Add(AuthorizationHeader.Parse("Digest username=\"Bob\""));
            request.CallInfos.Add(CallInfoHeader.Parse("<http://www.abc.com/photo.png>;purpose=icon"));
            request.Allows.Add(ContentLengthHeader.Parse("INVITE, ACK, BYE"));
            request.ContentEncodings.Add(ContentLengthHeader.Parse("deflate"));
            request.AlertInfos.Add(CallInfoHeader.Parse("<http://www.abc.com/sound.wav>"));
            request.ErrorInfos.Add(CallInfoHeader.Parse("<sip:not-in-service@abc.com>"));
            request.Accepts.Add(ContentTypeHeader.Parse("application/sdp"));
            request.AcceptEncodings.Add(AcceptEncodingHeader.Parse("gzip"));
            request.AcceptLanguages.Add(AcceptEncodingHeader.Parse("en"));
            request.AuthenticationInfos.Add(AuthenticationInfoHeader.Parse("nextnonce=\"abc\""));
            request.ProxyAuthenticationInfos.Add(AuthenticationInfoHeader.Parse("nextnonce=\"def\""));
            request.OtherHeaders.Add(new GenericHeader("P-Asserted-Identity", "sip:alan.smithee@abc.com"));
            request.Bodies.Add(SipBody.Parse("Hello world!"));

            var buffer = new byte[ushort.MaxValue];
            var success = request.TryCopyTo(buffer, 0, out int length);
                
            Assert.That(success, Is.True);

            var request2 = SipMessage.Parse(new ArraySegment<byte>(buffer, 0, length));

            Assert.That(request2.ToString(), Is.EqualTo(
                "INVITE sip:john.smith@abc.com SIP/2.0\r\n" +
                "Via: SIP/2.0/UDP foo.bar.com\r\n" +
                "Record-Route: Tommy Atkins <sip:tommy.atkins@abc.com>\r\n" +
                "Route: John Doe <sip:john.doe@abc.com>\r\n" +
                "From: John Smith <sip:john.smith@abc.com>\r\n" +
                "To: Joe Shmoe <sip:joe.shmoe@abc.com>\r\n" +
                "Call-ID: 1@foo.bar.com\r\n" +
                "CSeq: 1 INVITE\r\n" +
                "Contact: Prisoner X <sip:prisoner.x@abc.com>\r\n" +
                "Authorization: Digest username=\"Alice\"\r\n" +
                "WWW-Authenticate: Digest realm=\"abc.com\"\r\n" +
                "Proxy-Authenticate: Digest realm=\"xyz.com\"\r\n" +
                "Proxy-Authorization: Digest username=\"Bob\"\r\n" +
                "Call-Info: <http://www.abc.com/photo.png>;purpose=icon\r\n" +
                "Content-Type: text/plain\r\n" +
                "Mime-Version: 1.0\r\n" +
                "Allow: INVITE\r\n" +
                "Allow: ACK\r\n" +
                "Allow: BYE\r\n" +
                "Content-Encoding: deflate\r\n" +
                "Alert-Info: <http://www.abc.com/sound.wav>\r\n" +
                "Error-Info: <sip:not-in-service@abc.com>\r\n" +
                "Accept: application/sdp\r\n" +
                "Accept-Encoding: gzip\r\n" +
                "Accept-Language: en\r\n" +
                "Authentication-Info: nextnonce=\"abc\"\r\n" +
                "Proxy-Authentication-Info: nextnonce=\"def\"\r\n" +
                "P-asserted-identity: sip:alan.smithee@abc.com\r\n" +
                "Content-Length:    12\r\n" +
                "\r\n" +
                "Hello world!"));
        }

        [Test]
        public void Shall_parse_request_string()
        {
            const string str =
                "INVITE sip:john.smith@abc.com SIP/2.0\r\n" +
                "Via: SIP/2.0/UDP foo.bar.com\r\n" +
                "Record-Route: Tommy Atkins <sip:tommy.atkins@abc.com>\r\n" +
                "Route: John Doe <sip:john.doe@abc.com>\r\n" +
                "From: John Smith <sip:john.smith@abc.com>\r\n" +
                "To: Joe Shmoe <sip:joe.shmoe@abc.com>\r\n" +
                "Call-ID: 1@foo.bar.com\r\n" +
                "CSeq: 1 INVITE\r\n" +
                "Contact: Prisoner X <sip:prisoner.x@abc.com>\r\n" +
                "Authorization: Digest username=\"Alice\"\r\n" +
                "WWW-Authenticate: Digest realm=\"abc.com\"\r\n" +
                "Proxy-Authenticate: Digest realm=\"xyz.com\"\r\n" +
                "Proxy-Authorization: Digest username=\"Bob\"\r\n" +
                "Call-Info: <http://www.abc.com/photo.png>;purpose=icon\r\n" +
                "Content-Type: text/plain\r\n" +
                "Mime-Version: 1.0\r\n" +
                "Allow: INVITE, BYE\r\n" +
                "Content-Encoding: deflate\r\n" +
                "Alert-Info: <http://www.abc.com/sound.wav>\r\n" +
                "Error-Info: <sip:not-in-service@abc.com>\r\n" +
                "Accept: application/sdp\r\n" +
                "Accept-Encoding: gzip\r\n" +
                "Accept-Language: en\r\n" +
                "Authentication-Info: nextnonce=\"abc\"\r\n" +
                "Proxy-Authentication-Info: nextnonce=\"def\"\r\n" +
                "P-Asserted-Identity: sip:alan.smithee@abc.com\r\n" +
                "Content-Length:    12\r\n" +
                "\r\n" +
                "Hello world!";
            var request = (SipRequest)SipMessage.Parse(str);
            Assert.That(request.Version, Is.EqualTo("SIP/2.0"));
            Assert.That(request.Method, Is.EqualTo("INVITE"));
            Assert.That(request.RequestUri.ToString(), Is.EqualTo("sip:john.smith@abc.com"));
            Assert.That(request.Vias[0].ToString(), Is.EqualTo("SIP/2.0/UDP foo.bar.com"));
            Assert.That(request.RecordRoutes[0].ToString(), Is.EqualTo("Tommy Atkins <sip:tommy.atkins@abc.com>"));
            Assert.That(request.Routes[0].ToString(), Is.EqualTo("John Doe <sip:john.doe@abc.com>"));
            Assert.That(request.From.ToString(), Is.EqualTo("John Smith <sip:john.smith@abc.com>"));
            Assert.That(request.To.ToString(), Is.EqualTo("Joe Shmoe <sip:joe.shmoe@abc.com>"));
            Assert.That(request.CallId.ToString(), Is.EqualTo("1@foo.bar.com"));
            Assert.That(request.CSeq.ToString(), Is.EqualTo("1 INVITE"));
            Assert.That(request.Contacts[0].ToString(), Is.EqualTo("Prisoner X <sip:prisoner.x@abc.com>"));
            Assert.That(request.Authorizations[0].ToString(), Is.EqualTo("Digest username=\"Alice\""));
            Assert.That(request.WwwAuthenticates[0].ToString(), Is.EqualTo("Digest realm=\"abc.com\""));
            Assert.That(request.ProxyAuthenticates[0].ToString(), Is.EqualTo("Digest realm=\"xyz.com\""));
            Assert.That(request.ProxyAuthorizations[0].ToString(), Is.EqualTo("Digest username=\"Bob\""));
            Assert.That(request.CallInfos[0].ToString(), Is.EqualTo("<http://www.abc.com/photo.png>;purpose=icon"));
            Assert.That(request.ContentType.ToString(), Is.EqualTo("text/plain"));
            Assert.That(request.MimeVersion.ToString(), Is.EqualTo("1.0"));
            Assert.That(request.Allows.Count, Is.EqualTo(2));
            Assert.That(request.Allows[0].ToString(), Is.EqualTo("INVITE"));
            Assert.That(request.Allows[1].ToString(), Is.EqualTo("BYE"));
            Assert.That(request.ContentEncodings[0].ToString(), Is.EqualTo("deflate"));
            Assert.That(request.AlertInfos[0].ToString(), Is.EqualTo("<http://www.abc.com/sound.wav>"));
            Assert.That(request.ErrorInfos[0].ToString(), Is.EqualTo("<sip:not-in-service@abc.com>"));
            Assert.That(request.Accepts[0].ToString(), Is.EqualTo("application/sdp"));
            Assert.That(request.AcceptEncodings[0].ToString(), Is.EqualTo("gzip"));
            Assert.That(request.AcceptLanguages[0].ToString(), Is.EqualTo("en"));
            Assert.That(request.AuthenticationInfos[0].ToString(), Is.EqualTo("nextnonce=\"abc\""));
            Assert.That(request.ProxyAuthenticationInfos[0].ToString(), Is.EqualTo("nextnonce=\"def\""));
            Assert.That(request.OtherHeaders[0].Name, Is.EqualTo("p-asserted-identity"));
            Assert.That(request.OtherHeaders[0].Value, Is.EqualTo("sip:alan.smithee@abc.com"));
            Assert.That(request.ContentLength.ToString(), Is.EqualTo("12"));
            Assert.That(request.Bodies[0].ToString(), Is.EqualTo("Hello world!"));
        }

        [Test]
        public void Shall_parse_request_bytes()
        {
            const string str =
                "INVITE sip:john.smith@abc.com SIP/2.0\r\n" +
                "Via: SIP/2.0/UDP foo.bar.com\r\n" +
                "Record-Route: Tommy Atkins <sip:tommy.atkins@abc.com>\r\n" +
                "Route: John Doe <sip:john.doe@abc.com>\r\n" +
                "From: John Smith <sip:john.smith@abc.com>\r\n" +
                "To: Joe Shmoe <sip:joe.shmoe@abc.com>\r\n" +
                "Call-ID: 1@foo.bar.com\r\n" +
                "CSeq: 1 INVITE\r\n" +
                "Contact: Prisoner X <sip:prisoner.x@abc.com>\r\n" +
                "Authorization: Digest username=\"Alice\"\r\n" +
                "WWW-Authenticate: Digest realm=\"abc.com\"\r\n" +
                "Proxy-Authenticate: Digest realm=\"xyz.com\"\r\n" +
                "Proxy-Authorization: Digest username=\"Bob\"\r\n" +
                "Call-Info: <http://www.abc.com/photo.png>;purpose=icon\r\n" +
                "Content-Type: text/plain\r\n" +
                "Mime-Version: 1.0\r\n" +
                "Allow: INVITE, BYE\r\n" +
                "Content-Encoding: deflate\r\n" +
                "Alert-Info: <http://www.abc.com/sound.wav>\r\n" +
                "Error-Info: <sip:not-in-service@abc.com>\r\n" +
                "Accept: application/sdp\r\n" +
                "Accept-Encoding: gzip\r\n" +
                "Accept-Language: en\r\n" +
                "Authentication-Info: nextnonce=\"abc\"\r\n" +
                "Proxy-Authentication-Info: nextnonce=\"def\"\r\n" +
                "P-Asserted-Identity: sip:alan.smithee@abc.com\r\n" +
                "Content-Length:    12\r\n" +
                "\r\n" +
                "Hello world!";
            var request = (SipRequest)SipMessage.Parse(Encoding.UTF8.GetBytes(str));

            Assert.That(request.Version, Is.EqualTo("SIP/2.0"));
            Assert.That(request.Method, Is.EqualTo("INVITE"));
            Assert.That(request.RequestUri.ToString(), Is.EqualTo("sip:john.smith@abc.com"));
            Assert.That(request.Vias[0].ToString(), Is.EqualTo("SIP/2.0/UDP foo.bar.com"));
            Assert.That(request.RecordRoutes[0].ToString(), Is.EqualTo("Tommy Atkins <sip:tommy.atkins@abc.com>"));
            Assert.That(request.Routes[0].ToString(), Is.EqualTo("John Doe <sip:john.doe@abc.com>"));
            Assert.That(request.From.ToString(), Is.EqualTo("John Smith <sip:john.smith@abc.com>"));
            Assert.That(request.To.ToString(), Is.EqualTo("Joe Shmoe <sip:joe.shmoe@abc.com>"));
            Assert.That(request.CallId.ToString(), Is.EqualTo("1@foo.bar.com"));
            Assert.That(request.CSeq.ToString(), Is.EqualTo("1 INVITE"));
            Assert.That(request.Contacts[0].ToString(), Is.EqualTo("Prisoner X <sip:prisoner.x@abc.com>"));
            Assert.That(request.Authorizations[0].ToString(), Is.EqualTo("Digest username=\"Alice\""));
            Assert.That(request.WwwAuthenticates[0].ToString(), Is.EqualTo("Digest realm=\"abc.com\""));
            Assert.That(request.ProxyAuthenticates[0].ToString(), Is.EqualTo("Digest realm=\"xyz.com\""));
            Assert.That(request.ProxyAuthorizations[0].ToString(), Is.EqualTo("Digest username=\"Bob\""));
            Assert.That(request.CallInfos[0].ToString(), Is.EqualTo("<http://www.abc.com/photo.png>;purpose=icon"));
            Assert.That(request.ContentType.ToString(), Is.EqualTo("text/plain"));
            Assert.That(request.MimeVersion.ToString(), Is.EqualTo("1.0"));
            Assert.That(request.Allows.Count, Is.EqualTo(2));
            Assert.That(request.Allows[0].ToString(), Is.EqualTo("INVITE"));
            Assert.That(request.Allows[1].ToString(), Is.EqualTo("BYE"));
            Assert.That(request.ContentEncodings[0].ToString(), Is.EqualTo("deflate"));
            Assert.That(request.AlertInfos[0].ToString(), Is.EqualTo("<http://www.abc.com/sound.wav>"));
            Assert.That(request.ErrorInfos[0].ToString(), Is.EqualTo("<sip:not-in-service@abc.com>"));
            Assert.That(request.Accepts[0].ToString(), Is.EqualTo("application/sdp"));
            Assert.That(request.AcceptEncodings[0].ToString(), Is.EqualTo("gzip"));
            Assert.That(request.AcceptLanguages[0].ToString(), Is.EqualTo("en"));
            Assert.That(request.AuthenticationInfos[0].ToString(), Is.EqualTo("nextnonce=\"abc\""));
            Assert.That(request.ProxyAuthenticationInfos[0].ToString(), Is.EqualTo("nextnonce=\"def\""));
            Assert.That(request.OtherHeaders[0].Name, Is.EqualTo("p-asserted-identity"));
            Assert.That(request.OtherHeaders[0].Value, Is.EqualTo("sip:alan.smithee@abc.com"));
            Assert.That(request.ContentLength.ToString(), Is.EqualTo("12"));
            Assert.That(request.Bodies[0].ToString(), Is.EqualTo("Hello world!"));
        }

        [Test]
        public void Shall_calculate_content_length()
        {
            var request = new SipRequest
            {
                Method = "INVITE",
                RequestUri = SipUri.Parse("sip:senior@trump.us")
            };

            request.Bodies.Add(new SipBody
            {
                Data = "Senior Trump"
            });

            Assert.That(request.ContentLength.Value, Is.EqualTo("12"));

            request.Bodies.Clear();

            Assert.That(request.ContentLength.Value, Is.EqualTo("0"));
        }

        [Test]
        public void Shall_clone_request()
        {
            const string str =
                "INVITE sip:john.smith@abc.com SIP/2.0\r\n" +
                "From: John Smith <sip:john.smith@abc.com>\r\n" +
                "To: Joe Shmoe <sip:joe.shmoe@abc.com>\r\n\r\n";
            var original = (SipRequest)SipMessage.Parse(str);
            var cloned = original.DeepClone();

            original.Method = "REGISTER";

            Assert.That(cloned.ToString(), Does.Contain("INVITE"));
            Assert.That(original.Method, Does.Contain("REGISTER"));
        }
    }
}