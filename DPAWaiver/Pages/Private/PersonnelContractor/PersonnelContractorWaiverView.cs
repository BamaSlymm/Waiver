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
    public class PersonnelContractorWaiverView
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
        [Display(Name = "Descibe the scope of work to be performed:")]
        public string ScopeofWork {get; set;}

        [Required]
        [Display(Name = "Contractor Type:")]
        public string ContractorType {get; set;}

        [Required]
        [Display(Name = "Hourly Rate")]
        public decimal HourlyRate {get; set;}

        [Required]
        [Column(TypeName="DECIMAL(13,2)")]
        [Display(Name = "Cost Estimate")]
        [RegularExpression(@"^\d+(\.\d{0,2})?$")]
        [Range(0, 9999999999999999.99)]
        public decimal? CostEstimate { get ; set;}

        [Display(Name = "Total estimated number of hours:")]
        public decimal? EstimatedNumberOfHours {get;set;}

        [Required]
        [Display(Name = "How do you currently receive this service?")]
        public string SPAtype { get; set; }

        [Required]
        [Display(Name = "Enter State Price Agreement Number:")]
        public decimal? SPAnumber {get; set;}

        [Display(Name = "Please Describe Other for SPA:")]
        public string SPAotherDescription {get; set;}

        [Required]
        [Display(Name = "Total estimated number of FTE:")]
        public decimal? EstimatedNumberofFTE {get;set;}

        [Required]
        [Display(Name = "Expected duration of contract (numeric in months):")]
        public decimal? ContractDuration {get; set;}

        [Required]
        [Display(Name = "Anticipated Expenditure (must include mark up rate)")]
        public decimal? AnticipatedExpediture {get; set;}

        [Display(Name = "Please detail justification for request.")]
        public string DetailJustification {get;set;}

       [Display(Name = "Additional Comments")]
        public string AdditionalComments {get;set;}

        public WaiverStatus Status {get;set;}

        public PersonnelContractorWaiverView()
        {
        }


        public PersonnelContractorWaiverView(PersonnelContractorWaiver other)
        {
            this.CopyFromPersonnelContractorWaiver(other);
        }
        
        public void CopyFromPersonnelContractorWaiver(PersonnelContractorWaiver other) {
            this.OtherFirstName = other.OtherFirstName ;
            this.OtherLastName = other.OtherLastName ;
            this.projectName = other.projectName ;
            this.SubmittedOn = other.SubmittedOn ;
            this.ScopeofWork = other.ScopeofWork;
            this.ContractorType = other.ContractorType;
            this.HourlyRate = other.HourlyRate;
            this.CostEstimate = other.CostEstimate ;
            this.EstimatedNumberOfHours = other.EstimatedNumberOfHours;
            this.SPAtype = other.SPAtype;
            this.SPAnumber = other.SPAnumber;
            this.SPAotherDescription = other.SPAotherDescription;
            this.EstimatedNumberofFTE = other.EstimatedNumberofFTE ;
            this.ContractDuration = other.ContractDuration;
            this.AnticipatedExpediture = other.AnticipatedExpediture;
            this.DetailJustification = other.DetailJustification;
            this.AdditionalComments = other.AdditionalComments;
            this.Status = other.Status;
        }

    }

}