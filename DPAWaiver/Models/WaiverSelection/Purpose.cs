using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DPAWaiver.Models.WaiverSelection
{
    public class Purpose
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


        public Purpose(int ID, string name, int sortOrder, bool isDeletable, bool isDisabled)
        {
            this.ID = ID;
            this.Name = name;
            this.sortOrder = sortOrder;
            this.isDeletable = isDeletable;
            this.isDisabled = isDisabled;

        }

        public Purpose()
        {
        }

        public void Update(Purpose other)
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

        [JsonIgnore]
        public ICollection<PurposeType> purposeTypes { get; set; }
    }


    public static class Purposes
    {
        public const int Service = 1;
        public const int Personnel = 2;
        public const int Equipment = 3;
        public const int Software = 4;

    }
}