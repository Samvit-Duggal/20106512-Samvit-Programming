
using Xunit;
using HospitalManagement.Models;
using HospitalManagement.Services;

namespace HospitalManagement.Tests
{
    public class StaffManagerTests
    {
        [Fact]
        public void SearchStaff_Found()
        {
            StaffManager mgr = new StaffManager();

            Doctor d = new Doctor("John", 101, "Cardiology", "Heart");
            mgr.AddStaff(d);

            bool result = mgr.SearchStaff(101);

            Assert.True(result);
        }

        [Fact]
        public void SearchStaff_NotFound()
        {
            StaffManager mgr = new StaffManager();

            Doctor d = new Doctor("John", 101, "Cardiology", "Heart");
            mgr.AddStaff(d);

            bool result = mgr.SearchStaff(999);

            Assert.False(result);
        }

        [Fact]
        public void SearchStaff_EmptyList()
        {
            StaffManager mgr = new StaffManager();

            bool result = mgr.SearchStaff(101);

            Assert.False(result);
        }
    }
}
