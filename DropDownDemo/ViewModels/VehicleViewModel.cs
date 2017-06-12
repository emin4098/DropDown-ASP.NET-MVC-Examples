using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DropDownDemo.Models;

namespace DropDownDemo.ViewModels
{
    public class VehicleViewModel
    {
        public IEnumerable<Vehicle> AllVehicles { get; set; }

        public int SelectedYear { get; set; }

        public IEnumerable<Vehicle> SelectedVehicles { get; set; }

        public IEnumerable<SelectListItem> GetVehicleYearSelectList(int defaultYear = 0)
        {
            return AllVehicles
                .Distinct(new VehicleYearComparer())
                .OrderBy(e => e.Year)
                .Select((e, i) => new SelectListItem
                {
                    Text = e.Year.ToString(),
                    Value = e.Year.ToString(),
                    Selected = e.Year == defaultYear
                });
        }
    }

    public class VehicleYearComparer : IEqualityComparer<Vehicle>
    {
        public bool Equals(Vehicle x, Vehicle y)
        {
            return x.Year.Equals(y.Year);
        }

        public int GetHashCode(Vehicle obj)
        {
            return obj.Year.GetHashCode();
        }
    }
}