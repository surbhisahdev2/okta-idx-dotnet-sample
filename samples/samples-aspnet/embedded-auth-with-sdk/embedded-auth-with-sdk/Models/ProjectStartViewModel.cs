using Okta.Idx.Sdk;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace embedded_auth_with_sdk.Models
{
    public class ProjectStartViewModel 
    {

        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name = "UseCase")]
        public string UseCase { get; set; }

        [Display(Name = "Implementation")]
        public string Implementation { get; set; }

        [Display(Name = "User")]
        public string User { get; set; }


    }
}