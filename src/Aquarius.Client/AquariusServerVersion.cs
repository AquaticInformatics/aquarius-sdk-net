using System;
using System.Linq;

namespace Aquarius.Client
{
    public class AquariusServerVersion
    {
        public static AquariusServerVersion Create(string apiVersion)
        {
            return new AquariusServerVersion(apiVersion);
        }

        private readonly ushort[] _versionComponents;

        private AquariusServerVersion(string apiVersion)
        {
            if (apiVersion == null)
                throw new ArgumentNullException(nameof(apiVersion));

            _versionComponents = apiVersion.Split('.').Select(ushort.Parse).ToArray();

            if (!_versionComponents.Any())
                throw new ArgumentOutOfRangeException(nameof(apiVersion), apiVersion);

            AdjustMajorVersion();
        }

        private void AdjustMajorVersion()
        {
            const int firstNgMajorVersion = 14;
            const int lastYearInCentury = 99;
            const int thisMillenium = 2000;

            if (_versionComponents[0] >= firstNgMajorVersion && _versionComponents[0] <= lastYearInCentury)
            {
                _versionComponents[0] += thisMillenium;
            }
        }

        public override string ToString()
        {
            return string.Join(".", _versionComponents);
        }

        public bool IsLessThan(AquariusServerVersion other)
        {
            for (var i = 0; i < _versionComponents.Length; ++i)
            {
                if (i >= other._versionComponents.Length)
                    return false;

                if (_versionComponents[i] < other._versionComponents[i])
                    return true;

                if (_versionComponents[i] > other._versionComponents[i])
                    return false;
            }

            return _versionComponents.Length < other._versionComponents.Length;
        }

        public int Compare(AquariusServerVersion other)
        {
            if (IsLessThan(other))
                return -1;

            if (other.IsLessThan(this))
                return 1;

            return 0;
        }
    }
}

