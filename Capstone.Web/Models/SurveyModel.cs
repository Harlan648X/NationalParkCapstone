using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Models
{
    public class SurveyModel
    {
        public int SurveyId { get; set; }

        [Required(ErrorMessage = "*")]
        public string ParkCode { get; set; }

        [Required(ErrorMessage = "*")]
        [EmailAddress(ErrorMessage = "Not a valid email")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "*")]
        public string State { get; set; }

        [Required(ErrorMessage = "*")]
        public string ActivityLevel { get; set; }

        public string ParkName { get; set; }


        public static List<SelectListItem> ActivityLevels { get; } = new List<SelectListItem>()
        {
            new SelectListItem() {Text = "Select Activity Level", Value = "" },
            new SelectListItem() {Text = "sedenetary", Value = "sedenetary" },
            new SelectListItem() {Text = "active", Value = "active" },
            new SelectListItem() {Text = "extremly active", Value = "extremly active" },
            new SelectListItem() {Text = "inactive", Value = "inactive" },
        };

        public static List<SelectListItem> ParkCodes { get; } = new List<SelectListItem>()
        {
            new SelectListItem() {Text = "Select Park", Value = "" },
            new SelectListItem() {Text = "Cuyahoga Valley National Park", Value = "CVNP" },
            new SelectListItem() {Text = "Everglades National Park", Value = "ENP" },
            new SelectListItem() {Text = "Grand Canyon National Park", Value = "GCNP" },
            new SelectListItem() {Text = "Glacier National Park", Value = "GNP" },
            new SelectListItem() {Text = "Great Smoky Mountains National Park", Value = "GSMNP" },
            new SelectListItem() {Text = "Grand Teton National Park", Value = "GTNP" },
            new SelectListItem() {Text = "Mount Rainier National Park", Value = "MRNP" },
            new SelectListItem() {Text = "Rocky Mountain National Park", Value = "RMNP" },
            new SelectListItem() {Text = "Yellowstone National Park", Value = "YNP" },
            new SelectListItem() {Text = "Yosemite National Park", Value = "YNP2" },
        };

    }

    //public enum ParkCode
    //{
    //    CVNP
    //    ENP
    //    GCNP
    //    GNP
    //    GSMNP
    //    GTNP
    //    MRNP
    //    RMNP
    //    YNP
    //    YNP2
    //}

    public enum State
    {
        [Description("Alabama")]
        AL,

        [Description("Alaska")]
        AK,

        [Description("Arkansas")]
        AR,

        [Description("Arizona")]
        AZ,

        [Description("California")]
        CA,

        [Description("Colorado")]
        CO,

        [Description("Connecticut")]
        CT,

        [Description("D.C.")]
        DC,

        [Description("Delaware")]
        DE,

        [Description("Florida")]
        FL,

        [Description("Georgia")]
        GA,

        [Description("Hawaii")]
        HI,

        [Description("Iowa")]
        IA,

        [Description("Idaho")]
        ID,

        [Description("Illinois")]
        IL,

        [Description("Indiana")]
        IN,

        [Description("Kansas")]
        KS,

        [Description("Kentucky")]
        KY,

        [Description("Louisiana")]
        LA,

        [Description("Massachusetts")]
        MA,

        [Description("Maryland")]
        MD,

        [Description("Maine")]
        ME,

        [Description("Michigan")]
        MI,

        [Description("Minnesota")]
        MN,

        [Description("Missouri")]
        MO,

        [Description("Mississippi")]
        MS,

        [Description("Montana")]
        MT,

        [Description("North Carolina")]
        NC,

        [Description("North Dakota")]
        ND,

        [Description("Nebraska")]
        NE,

        [Description("New Hampshire")]
        NH,

        [Description("New Jersey")]
        NJ,

        [Description("New Mexico")]
        NM,

        [Description("Nevada")]
        NV,

        [Description("New York")]
        NY,

        [Description("Oklahoma")]
        OK,

        [Description("Ohio")]
        OH,

        [Description("Oregon")]
        OR,

        [Description("Pennsylvania")]
        PA,

        [Description("Rhode Island")]
        RI,

        [Description("South Carolina")]
        SC,

        [Description("South Dakota")]
        SD,

        [Description("Tennessee")]
        TN,

        [Description("Texas")]
        TX,

        [Description("Utah")]
        UT,

        [Description("Virginia")]
        VA,

        [Description("Vermont")]
        VT,

        [Description("Washington")]
        WA,

        [Description("Wisconsin")]
        WI,

        [Description("West Virginia")]
        WV,

        [Description("Wyoming")]
        WY
    }

    //public enum ActivityLevel
    //{
    //    inactive,
    //    sedenetary, 
    //    active,
    //    [Display(Name="Extremely Active")]
    //    extremly_active
    //}


}