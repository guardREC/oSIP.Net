﻿using NUnit.Framework;

namespace oSIP.Net.Tests
{
    [TestFixture]
    public class ViaHeaderTests
    {
        [Test]
        public void Shall_stringify_header()
        {
            var header = new ViaHeader
            {
                Version = "2.0",
                Protocol = "UDP",
                Host = "foo.bar.com",
                Port = "1234",
                Comment = "a comment",
                Parameters =
                {
                    new GenericParameter("foo", "bar")
                }
            };

            Assert.That(header.ToString(), Is.EqualTo("SIP/2.0/UDP foo.bar.com:1234;foo=bar (a comment)"));
        }

        [Test]
        public void Shall_parse_header()
        {
            const string str = "SIP/2.0/UDP foo.bar.com:1234;foo=bar (a comment)";

            Assert.That(ViaHeader.TryParse(str, out ViaHeader header), Is.True);
            Assert.That(header.Version, Is.EqualTo("2.0"));
            Assert.That(header.Protocol, Is.EqualTo("UDP"));
            Assert.That(header.Host, Is.EqualTo("foo.bar.com"));
            Assert.That(header.Port, Is.EqualTo("1234"));
            Assert.That(header.Comment, Is.EqualTo("a comment"));
            Assert.That(header.Parameters[0].Name, Is.EqualTo("foo"));
            Assert.That(header.Parameters[0].Value, Is.EqualTo("bar"));
        }

        [Test]
        public void Shall_clone_header()
        {
            ViaHeader original = ViaHeader.Parse("SIP/2.0/UDP foo.bar.com:1234 (a comment)");
            ViaHeader cloned = original.DeepClone();

            original.Version = "1.1";
            original.Protocol = "TCP";
            original.Host = "qwerty.dvorak.com";
            original.Port = "5678";
            original.Comment = "another comment";
            original.Parameters.Add(new GenericParameter("foo", "bar"));

            Assert.That(cloned.ToString(), Is.EqualTo("SIP/2.0/UDP foo.bar.com:1234 (a comment)"));
            Assert.That(original.ToString(), Is.EqualTo("SIP/1.1/TCP qwerty.dvorak.com:5678;foo=bar (another comment)"));
        }
    }
}