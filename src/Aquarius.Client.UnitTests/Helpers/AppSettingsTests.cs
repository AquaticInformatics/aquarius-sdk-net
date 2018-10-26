using System;
using Aquarius.Helpers;
using FluentAssertions;
using NUnit.Framework;

#if AUTOFIXTURE4
using AutoFixture;
#else
using Ploeh.AutoFixture;
#endif

namespace Aquarius.UnitTests.Helpers
{
    [TestFixture]
    public class AppSettingsTests
    {
        private IFixture _fixture;

        [SetUp]
        public void ForEachTest()
        {
            _fixture = new Fixture();
            AppSettings.Reload();
        }

        [Test]
        public void Get_WithNoSettings_ReturnsDefault()
        {
            var expected = _fixture.Create<string>();
            var actual = AppSettings.Get("dummyName", expected);

            actual.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void Get_WithEnvironmentSetting_ReturnsEnvironmentValue()
        {
            const string settingName = "MySetting";
            var expected = _fixture.Create<string>();

            SetEnvironmentVariable(settingName, expected);

            var actual = AppSettings.Get(settingName, _fixture.Create<string>());

            actual.ShouldBeEquivalentTo(expected);
        }

        private void SetEnvironmentVariable(string name, string value)
        {
            Environment.SetEnvironmentVariable(AppSettings.GetSettingKey(name), value);

            AppSettings.Reload(); // To latch the new environment variable
        }

        [Test]
        public void Get_WithTimespanEnvironmentValue_ReturnsExpectedValue()
        {
            const string settingName = "Timeout";
            var expected = TimeSpan.FromMinutes(2);

            SetEnvironmentVariable(settingName, "00:02:00");

            var actual = AppSettings.Get<TimeSpan?>(settingName, null);

            actual.ShouldBeEquivalentTo(expected);
        }
    }
}
