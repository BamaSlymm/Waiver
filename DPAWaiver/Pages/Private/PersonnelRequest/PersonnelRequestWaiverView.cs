/*
 * Copyright (c) 2017 Google Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not
 * use this file except in compliance with the License. You may obtain a copy of
 * the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations under
 * the License.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using System.ComponentModel.DataAnnotations.Schema;

namespace DPAWaiver.Models.Waivers 
{
    public class PersonnelRequestWaiverView
    {

        
        [Display(Name = "Waiver Owner First Name")]
        public string OtherFirstName { get; set; }

        [Display(Name = "Waiver Owner Last Name")]
        public string OtherLastName { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public string projectName {get;set;}

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Submitted Date")]
        public DateTime? SubmittedOn { get; set; }

        [Required]
        [Column(TypeName="DECIMAL(13,2)")]
        [Display(Name = "Cost Estimate")]
        [RegularExpression(@"^\d+(\.\d{0,2})?$")]
        [Range(0, 9999999999999999.99)]
        public decimal? CostEstimate { get ; set;}

        
        [Display(Name= "Employee Type")]
        public string employeeType {get; set;}

        [Required]
        [Display(Name = "Describe the job duties:")]
        public string JobDuties {get;set;}

        [Required]
        [Display(Name = "Total estimated number of Staff:")]
        public decimal? EstimatedNumberofStaff {get;set;}

        
        [Display(Name = "Upload State Position Description:")]
        public string positionFile {get; set;}

        
        [Display(Name = "Total estimated number of FTE:")]
        public decimal? EstimatedNumberofFTE {get;set;}

        
        [Display(Name = "Requested Classification (One waiver request per classification):")]        
        public string RequestedClassification {get; set;}

        [Required]
        [Display(Name = "Requested Loaded Salary:")]        
        public decimal? RequestedSalary {get; set;}

        [Display(Name = "Please detail justification for request.")]
        public string DetailJustification {get;set;}

       [Display(Name = "Additional Comments")]
        public string AdditionalComments {get;set;}

        public WaiverStatus Status {get;set;}

        public PersonnelRequestWaiverView()
        {
        }


        public PersonnelRequestWaiverView(PersonnelRequestWaiver other)
        {
            this.CopyFromPersonnelRequestWaiver(other);
        }
        
        public void CopyFromPersonnelRequestWaiver(PersonnelRequestWaiver other) {
            this.OtherFirstName = other.OtherFirstName ;
            this.OtherLastName = other.OtherLastName ;
            this.projectName = other.projectName ;
            this.SubmittedOn = other.SubmittedOn ;
            this.CostEstimate = other.CostEstimate ;
            this.EstimatedNumberofStaff = other.EstimatedNumberofStaff;
            this.JobDuties = other.JobDuties;
            this.EstimatedNumberofFTE = other.EstimatedNumberofFTE ;
            this.positionFile = other.positionFile;
            this.RequestedClassification = other.RequestedClassification;
            this.RequestedSalary = other.RequestedSalary;
            this.DetailJustification = other.DetailJustification;
            this.AdditionalComments = other.AdditionalComments;
            this.Status = other.Status;
        }

    }

}