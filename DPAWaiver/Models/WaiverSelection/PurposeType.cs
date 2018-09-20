using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DPAWaiver.Models.WaiverSelection
{
    public class PurposeType
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int sortOrder { get; set; }
        [Required]
        public bool isDeletable { get; set; }
        [Required]
        public bool isDisabled { get; set; }
        [Required]
        [JsonIgnore] 
        public Purpose purpose { get; set; }

        public PurposeType(int ID, string name, int sortOrder, bool isDeletable, bool isDisabled)
        {
            this.ID = ID;
            this.Name = name;
            this.sortOrder = sortOrder;
            this.isDeletable = isDeletable;
            this.isDisabled = isDisabled;
        }

        public PurposeType()
        {
        }

        public void Update(PurposeType other)
        {
            if (other == null)
            {
                return;
            }
            this.ID = other.ID;
            this.Name = other.Name;
            this.sortOrder = other.sortOrder;
            this.isDeletable = other.isDeletable;
            this.isDisabled = other.isDisabled;
        }

        public ICollection<PurposeSubtype> purposeSubtypes { get; set; }

    }

    public static class ServiceTypes
    {
        public const int DataEntry = 1;
        public const int Design = 2;
        public const int Mail = 3;
        public const int PrintCopy = 4;
        public const int Microfilm = 5;
        public const int Scanning = 6;

    }

    public static class PersonnelServiceTypes
    {
        public const int StateEmployee = 7;
        public const int ThirdPartyContractor = 8;

    }
}
