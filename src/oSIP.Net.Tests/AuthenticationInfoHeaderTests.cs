﻿using NUnit.Framework;

namespace oSIP.Net.Tests
{
    [TestFixture]
    public class AuthenticationInfoHeaderTests
    {
        [Test]
        public void Shall_stringify_header()
        {
            var header = new AuthenticationInfoHeader
            {
                AuthenticationType = "Basic",
                QopOptions = "\"a\"",
                NextNonce = "\"b\"",
                RspAuth = "\"c\"",
                CNonce = "\"d\"",
                NonceCount = "0000000e",
                Snum = "\"f\"",
                Srand = "\"g\"",
                TargetName = "\"h\"",
                Realm = "\"i\"",
                Opaque = "\"j\""
            };

            Assert.That(
                header.ToString(),
                Is.EqualTo(
                    "Basic qop=\"a\", nextnonce=\"b\", rspauth=\"c\", cnonce=\"d\", nc=0000000e, " +
                    "snum=\"f\", srand=\"g\", targetname=\"h\", realm=\"i\", opaque=\"j\""));
        }

        [Test]
        public void Shall_parse_header()
        {
            const string str =
                "Basic qop=\"a\", nextnonce=\"b\", rspauth=\"c\", cnonce=\"d\", nc=0000000e, " +
                "snum=\"f\", srand=\"g\", targetname=\"h\", realm=\"i\", opaque=\"j\"";

            Assert.That(AuthenticationInfoHeader.TryParse(str, out AuthenticationInfoHeader header), Is.True);
            Assert.That(header.AuthenticationType, Is.EqualTo("Basic"));
            Assert.That(header.QopOptions, Is.EqualTo("\"a\""));
            Assert.That(header.NextNonce, Is.EqualTo("\"b\""));
            Assert.That(header.RspAuth, Is.EqualTo("\"c\""));
            Assert.That(header.CNonce, Is.EqualTo("\"d\""));
            Assert.That(header.NonceCount, Is.EqualTo("0000000e"));
            Assert.That(header.Snum, Is.EqualTo("\"f\""));
            Assert.That(header.Srand, Is.EqualTo("\"g\""));
            Assert.That(header.TargetName, Is.EqualTo("\"h\""));
            Assert.That(header.Realm, Is.EqualTo("\"i\""));
            Assert.That(header.Opaque, Is.EqualTo("\"j\""));
        }

        [Test]
        public void Shall_clone_header()
        {
            var original = AuthenticationInfoHeader.Parse("Basic qop=\"auth\"");
            var cloned = original.DeepClone();

            original.AuthenticationType = "Digest";
            original.QopOptions = null;
            original.CNonce = "\"abc\"";

            Assert.That(cloned.ToString(), Is.EqualTo("Basic qop=\"auth\""));
            Assert.That(original.ToString(), Is.EqualTo("Digest cnonce=\"abc\""));
        }
    }
}