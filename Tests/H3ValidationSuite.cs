using NUnit.Framework;
using H3Unity;

namespace H3Unity.Tests
{
    public class H3ValidationSuite
    {
        [Test]
        public void FromLatLng_ToLatLng_RoundTrip_IsConsistent()
        {
            var original = H3.FromLatLng(40.0, -74.0, 9);
            var latlng = H3.ToLatLng(original);
            var roundtrip = H3.FromLatLng(
                H3Utils.RadsToDegs(latlng.lat),
                H3Utils.RadsToDegs(latlng.lng),
                9
            );

            Assert.AreEqual(original, roundtrip, "Round-trip index mismatch");
        }

        [Test]
        public void ToParent_ThenToChildren_ShouldContainOriginal()
        {
            var index = H3.FromLatLng(40, -74, 9);
            var parent = H3.ToParent(index, 5);
            var children = H3.ToChildren(parent, 9);

            Assert.Contains(index, children, "Parent/child hierarchy broken");
        }

        [Test]
        public void Disk_Center_IsInOutput()
        {
            var index = H3.FromLatLng(35, -90, 8);
            var disk = H3.Disk(index, 1);

            Assert.Contains(index, disk, "Origin not found in disk output");
        }

        [Test]
        public void InvalidHex_ShouldThrow()
        {
            Assert.Throws<H3Exception>(() =>
            {
                var h3 = H3Utils.StringToH3("INVALID_HEX");
                var latlng = H3.ToLatLng(h3);
            });
        }
    }
}
