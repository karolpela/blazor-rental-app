using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using RentalApp.Shared.Models;
using RentalApp.Shared.Models.Equipment;
using RentalApp.Shared.Models.Equipment.Skates;

namespace RentalApp.Client.Pages
{
    public partial class NewRental
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; } = default!;

        [Inject]
        protected NavigationManager NavigationManager { get; set; } = default!;

        protected RentalApp.Shared.Models.Rental rental = new RentalApp.Shared.Models.Rental();

        protected List<Person> clients = new List<Person>();
        
        protected List<IceSkates> equipment = new List<IceSkates>();

        protected bool insuranceWanted = false;

        protected string pesel = "09328402943";
        
        protected List<ProtectiveGear> protectiveGear = new List<ProtectiveGear>();
        IEnumerable<int> selectedGear = new int[] { 1, 2 };

    }
}